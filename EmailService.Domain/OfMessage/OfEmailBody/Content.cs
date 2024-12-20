using System.Text;
using Abstraction.DDD.OfValueObject;
using Abstraction.Exception;

namespace EmailService.Domain.OfMessage.OfEmailBody
{
    /// <summary>
    /// Содержания письма
    /// </summary>
    public class Content : ValueObject<Content>
    {
        private Content()
        {

        }
        public Content(string value) : this()
        {
            if (string.IsNullOrEmpty(value))
                throw new NoValueDomainException("Содержание письма не может быть пустым");
            Value = StringToBytes(value);
        }

        /// <summary>
        /// Значение
        /// </summary>
        public byte[] Value { get; private set; }

        /// <summary>
        /// Значение строкой
        /// </summary>
        public string ValueString => BytesToString(Value);

        private byte[] StringToBytes(string value)
        {
            return Encoding.Unicode.GetBytes(value);
        }

        private string BytesToString(byte[] value)
        {
            return Encoding.Unicode.GetString(value);
        }

        protected override int GetValueHashCode()
        {
            return Value.GetHashCode();
        }

        protected override bool CompareValues(Content other)
        {
            return Value == other.Value;
        }
    }
}
