namespace MailService.API.Models
{
    public class MailRequest
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
        /// Список адресатов письма
        /// </summary>
        public string[] Recipients { get; set; }
    }
}
