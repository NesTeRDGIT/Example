using System.Text.RegularExpressions;
using Abstraction.DDD.OfValueObject;
using Abstraction.Exception;

namespace EmailService.Domain.OfMessage
{
    /// <summary>
    /// Адрес электронной почты
    /// </summary>
    public class EmailAddress : BaseEmail
    {
        public EmailAddress(string value): base(value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new NoValueDomainException("Адрес электронной почты не может быть пустым");
            }
        }
    }


    /// <summary>
    /// Email
    /// </summary>
    public class BaseEmail : ValueObject<BaseEmail>
    {
        private readonly string pattern = @"^([\w!#$%&'*+\-\/=?\^_`{|}~\.а-яА-ЯеЁ]+)"
                                          + "@"
                                          + @"([\w\-а-яА-ЯеЁ]+|[\w\-\.а-яА-ЯеЁ]+[\w\-а-яА-ЯеЁ]+)\.([\wа-яА-ЯеЁ]+)$";

        public BaseEmail(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (value != string.Empty && !Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
                throw new BadValueDomainException("Недопустимый формат email", nameof(value), value);

            Value = value;
        }

        /// <summary>
        /// Значение
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Значение отсутствует
        /// </summary>
        public static BaseEmail Default => new(string.Empty);

        protected override int GetValueHashCode()
        {
            return Value.GetHashCode();
        }

        protected override bool CompareValues(BaseEmail other)
        {
            return Value == other.Value;
        }
    }
}
