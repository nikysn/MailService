namespace MailService.API.Models
{
    public class EmailSenderSettings
    {
        /// <summary>
        /// Сервер для отправки почты 
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// Порт для отправки почты
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// Флаг, указывающий на необходимость использования SSL при отправке почты
        /// </summary>
        public bool EnableSsl { get; set; }
        /// <summary>
        /// Имя пользователя для авторизации при отправке почты
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Пароль для авторизации при отправке почты
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Email адрес отправителя
        /// </summary>
        public string Sender { get; set; }
    }
}
