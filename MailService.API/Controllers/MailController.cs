using MailService.API.Abstraction;
using MailService.API.MailService.BL;
using MailService.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace MailService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public MailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        /// <summary>
        /// Отправляет электронное письмо.
        /// </summary>
        /// <param name="mailRequest">Запрос на отправку письма с деталями письма</param>
        /// <returns>Результат операции отправки письма</returns>
        [HttpPost("SendMail")]
        public async Task<ActionResult> SendMail(MailRequest mailRequest)
        {
            await _emailService.SendMailAsync(mailRequest);
            return Ok(mailRequest);
        }

        /// <summary>
        /// Получает все почтовые логи
        /// </summary>
        /// <returns>Коллекция почтовых логов.</returns>
        [HttpGet("GetMails")]
        public async Task<IActionResult> GetMailLogsAsync()
        {
            var mailLogs = await _emailService.GetMailLogsAsync();
            return Ok(mailLogs);
        }
    }
}
