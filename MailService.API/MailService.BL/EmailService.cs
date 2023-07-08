using MailService.API.Abstraction;
using MailService.API.MailService.DAL.Entities;
using MailService.API.Models;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Text;

namespace MailService.API.MailService.BL
{
    public class EmailService : IEmailService
    {
        private readonly EmailSenderSettings _emailSettings;
        private readonly IEmailRepository _emailRepository;
        private readonly ILogger<EmailService> _logger;
        private readonly SmtpClient _smtpClient;
        private MailLog _mailLog = new MailLog();

        public EmailService(ILogger<EmailService> logger, SmtpClient smtpClient, IEmailRepository emailRepository, IOptions<EmailSenderSettings> emailSettings)
        {
            _logger = logger;
            _smtpClient = smtpClient;
            _emailRepository = emailRepository;
            _emailSettings = emailSettings?.Value ?? new EmailSenderSettings();
        }

        public async Task SendMailAsync(MailRequest mailRequest)
        {
            try
            {
                if (string.IsNullOrEmpty(mailRequest.Subject))
                {
                    throw new ArgumentException("Тема не может быть нулевой или пустой.");
                }

                var message = new MailMessage
                {
                    From = new MailAddress(_emailSettings.Sender, _emailSettings.Sender),
                    Subject = mailRequest.Subject,
                    SubjectEncoding = Encoding.UTF8,
                    Body = mailRequest.Body,
                    BodyEncoding = Encoding.UTF8,
                    Sender = new MailAddress(_emailSettings.Sender, _emailSettings.Sender),
                    IsBodyHtml = true
                };

                foreach (var email in mailRequest.Recipients)
                {
                    message.To.Add(new MailAddress(email));
                }

                await _smtpClient.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Inititator}. Ошибка во время отправки Email", nameof(EmailService));

                _mailLog.Result = MailResult.Failed;
                _mailLog.FailedMessage = ex.Message;
            }
            finally
            {
                await CreateAndSaveMailLogAsync(mailRequest);
            }
        }

        public async Task<IEnumerable<MailLog>> GetMailLogsAsync()
        {
            return await _emailRepository.GetAllMailLogs();
        }

        private async Task CreateAndSaveMailLogAsync(MailRequest mailRequest)
        {
            _mailLog.Subject = mailRequest.Subject;
            _mailLog.Body = mailRequest.Body;
            _mailLog.Recipients = String.Join(",", mailRequest.Recipients);

            await _emailRepository.AddMailLogAsync(_mailLog);
        }
    }
}
