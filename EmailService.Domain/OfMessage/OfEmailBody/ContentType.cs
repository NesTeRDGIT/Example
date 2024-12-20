using Abstraction.DDD.OfValueObject;

namespace EmailService.Domain.OfMessage.OfEmailBody
{
    /// <summary>
    /// Тип содержания письма
    /// </summary>
    public class ContentType : StaticReference<ContentType, string>
    {
        private ContentType(string value, string name)
        {
            Value = value;
            Name = name;
        }


        /// <summary>
        /// Текст
        /// </summary>
        public static ContentType Text => new("text", "Текст");

        /// <summary>
        /// Html
        /// </summary>
        public static ContentType Html => new("html", "Html");
    }
}
