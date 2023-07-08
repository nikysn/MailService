using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailService.API.MailService.DAL.Entities
{
    public enum MailResult
    {
        OK,
        Failed
    }

    public class MailLog
    {
        /// <summary>
        /// Уникальный идентификатор почтового лога
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Тема письма
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Тело письма
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Дата и время создания почтового лога.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Результат отправки письма.
        /// </summary>
        [EnumDataType(typeof(MailResult))]
        [Column(TypeName = "varchar")]
        public MailResult Result { get; set; } = MailResult.OK;
        /// <summary>
        /// Сообщение об ошибке при неудачной отправке письма.
        /// </summary>
        public string FailedMessage { get; set; } = string.Empty;
        /// <summary>
        /// Список получателей письма (разделенных запятыми).
        /// </summary>
        public string Recipients { get; set; }

        /// <summary>
        /// Конструктор для автоматической фиксации даты и времени создания письма
        /// </summary>
        public MailLog()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}


