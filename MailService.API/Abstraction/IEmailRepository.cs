using MailService.API.MailService.DAL.Entities;

namespace MailService.API.Abstraction
{
    public interface IEmailRepository
    {
        /// <summary>
        /// Добавляет информацию о почтовом логе в репозиторий.
        /// </summary>
        /// <param name="mailLog">Почтовый лог для добавления</param>
        /// <returns></returns>
        Task AddMailLogAsync(MailLog mailLog);
        /// <summary>
        /// Получает все почтовые логи из репозитория.
        /// </summary>
        /// <returns>Коллекция почтовых логов</returns>
        Task<IEnumerable<MailLog>> GetAllMailLogs();
    }
}
