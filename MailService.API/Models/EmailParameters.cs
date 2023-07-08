namespace MailService.API.Models
{
    public class EmailParameters
    {
        /// <summary>
        /// Тема письма
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Текст письма
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Список адресатов
        /// </summary>
        public List<string> Recipients { get; set; }
    }
}
