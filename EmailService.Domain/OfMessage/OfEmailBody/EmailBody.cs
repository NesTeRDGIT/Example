using Abstraction.DDD.OfValueObject;

namespace EmailService.Domain.OfMessage.OfEmailBody
{
    /// <summary>
    /// Тело письма
    /// </summary>
    public class EmailBody : ValueObject<EmailBody>
    {
        private EmailBody()
        {

        }

        public EmailBody(ContentType contentType, Content content):this()
        {
            ContentType = contentType ?? throw new ArgumentNullException(nameof(contentType));
            Content = content ?? throw new ArgumentNullException(nameof(content));
        }

        /// <summary>
        /// Тип содержимого
        /// </summary>
        public ContentType ContentType { get; }

        /// <summary>
        /// Содержимое
        /// </summary>
        public Content Content { get; }


        protected override int GetValueHashCode()
        {
            return HashCode.Combine(ContentType, Content);
        }

        protected override bool CompareValues(EmailBody other)
        {
            return (Content, ContentType) == (other.Content, other.ContentType);
        }
    }
}
