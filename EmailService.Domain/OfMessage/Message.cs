using Abstraction.DDD.OfEntity;
using Abstraction.Exception;
using EmailService.Domain.OfMessage.OfAttachment;
using EmailService.Domain.OfMessage.OfEmailBody;

namespace EmailService.Domain.OfMessage
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public class Message : AggregateRoot<MessageId>
    {
        private readonly RecipientCollection recipientCollection;
        private readonly List<Recipient> recipients;
        private readonly AttachmentCollection attachmentCollection;
        private readonly List<Attachment> attachments;

        private Message()
        {
            Status = Status.New;
            Comment = string.Empty;
            ExternalId = ExternalId.Default;
            ProcessedDate = null;
            recipients = new List<Recipient>();
            recipientCollection = new RecipientCollection(recipients);
            attachments = new List<Attachment>();
            attachmentCollection = new AttachmentCollection(attachments);
        }

        public Message(MessageId id, DateTime createdDate, string senderName, string subject, EmailBody body, IList<Recipient> recipients) : this()
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            SenderName = senderName ?? string.Empty;
            Subject = subject ?? string.Empty;
            Body = body ?? throw new ArgumentNullException(nameof(body));
            Recipients.Replace(recipients ?? throw new ArgumentNullException(nameof(recipients)));
            CreatedDate = createdDate;
        }

        /// <summary>
        /// Получатели
        /// </summary>
        // ReSharper disable once ConvertToAutoProperty
        public RecipientCollection Recipients => recipientCollection;

        /// <summary>
        /// Вложения
        /// </summary>
        // ReSharper disable once ConvertToAutoProperty
        public AttachmentCollection Attachments => attachmentCollection;

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreatedDate { get; }

        /// <summary>
        /// Имя отправителя
        /// </summary>
        public string SenderName { get; }

        /// <summary>
        /// Тема письма
        /// </summary>
        public string Subject { get; }

        /// <summary>
        /// Тело письма
        /// </summary>
        public EmailBody Body { get; }

        /// <summary>
        /// Статус
        /// </summary>
        public Status Status { get; private set; }

        /// <summary>
        /// Внешний идентификатор
        /// </summary>
        public ExternalId ExternalId { get; private set; }

        /// <summary>
        /// Дата обработки
        /// </summary>
        public DateTime? ProcessedDate { get; private set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; private set; }

        /// <summary>
        /// Успешная обработка сообщения
        /// </summary>
        /// <param name="processedDate">Дата обработки</param>
        /// <param name="externalId">Внешний идентификатор</param>
        /// <param name="comment">Комментарий</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Success(DateTime processedDate, ExternalId externalId, string comment)
        {
            if (Status != Status.New)
            {
                throw new InvalidOperationDomainException(
                    $"Только сообщение со статусом: \"{Status.New.Name}\" может быть переведено в статус: \"{Status.Sent.Name}\"");
            }
            Comment = comment ?? string.Empty;
            ExternalId = externalId ?? throw new ArgumentNullException(nameof(externalId));
            ProcessedDate = processedDate;
            Status = Status.Sent;
        }

        /// <summary>
        /// Ошибка обработки сообщения
        /// </summary>
        /// <param name="processedDate">Дата обработки</param>
        /// <param name="externalId">Внешний идентификатор</param>
        /// <param name="comment">Комментарий</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Failure(DateTime processedDate, ExternalId externalId, string comment)
        {
            if (Status != Status.New)
            {
                throw new InvalidOperationDomainException(
                    $"Только сообщение со статусом: \"{Status.New.Name}\" может быть переведено в статус: \"{Status.Error.Name}\"");
            }

            ExternalId = externalId ?? throw new ArgumentNullException(nameof(externalId));
            Comment = comment ?? string.Empty;
            ProcessedDate = processedDate;
            Status = Status.Error;
        }
    }
}