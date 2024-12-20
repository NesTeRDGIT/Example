namespace EmailService.Application.Use.Command.AddMessage
{
    /// <summary>
    /// Проекция сообщения
    /// </summary>
    public class MessageProjection
    {
        /// <summary>
        /// Тип содержимого(text - текст, html - код html)
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Содержимое
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Имя отправителя
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// Тема письма
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Получатель
        /// </summary>
        public List<RecipientProjection> Recipients { get; set; } = new();

        /// <summary>
        /// Вложения
        /// </summary>
        public List<AttachmentProjection> Attachments { get; set; } = new();
    }
}
