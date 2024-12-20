using Abstraction.DDD.OfValueObject;

namespace EmailService.Domain.OfMessage
{
    /// <summary>
    /// Получатель
    /// </summary>
    public class Recipient : ValueObject<Recipient>
    {
        private Recipient()
        {

        }

        public Recipient(string name, EmailAddress email) : this()
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Name = name ?? string.Empty;
        }

        /// <summary>
        /// Имя получателя
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public EmailAddress Email { get; }

        protected override int GetValueHashCode()
        {
            return HashCode.Combine(Email);
        }

        protected override bool CompareValues(Recipient other)
        {
            return (Email) == (other.Email);
        }
    }
}
