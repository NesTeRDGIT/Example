namespace EmailService.Application.Use.ClientQuery.GetMessageListItem
{
    /// <summary>
    /// Проекция сообщения
    /// </summary>
    public class MessageProjection
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Код статуса
        /// </summary>
        public string StatusValue { get; set; }

        /// <summary>
        /// Наименование статуса
        /// </summary>
        public string StatusName { get; set; }

        /// <summary>
        /// Дата обработки
        /// </summary>
        public DateTime? ProcessedDate { get; set; }

        /// <summary>
        /// Адрес получателя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Внешний идентификатор
        /// </summary>
        public string ExternalId { get; set; }
    }
}
