using MailService.API.MailService.DAL.Entities;
using MailService.API.Models;

namespace MailService.API.Abstraction
{
    public interface IEmailService
    {
        /// <summary>
        /// Отправляет электронное письмо асинхронно.
        /// </summary>
        /// <param name="request">Запрос на отправку письма с деталями письма</param>
        /// <returns></returns>
        Task SendMailAsync(MailRequest request);
        /// <summary>
        /// Получает все почтовые логи асинхронно.
        /// </summary>
        /// <returns>Коллекция почтовых логов</returns>
        Task<IEnumerable<MailLog>> GetMailLogsAsync();
    }
}
