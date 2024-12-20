using Abstraction.DDD.OfEntity;
using Abstraction.Exception;

namespace EmailService.Domain.OfMessage.OfAttachment
{
    /// <summary>
    /// Вложение
    /// </summary>
    public class Attachment : Entity<AttachmentId>
    {
        private Attachment(){}
        public Attachment(AttachmentId id, string filename, byte[] data) : this()
        {
            ArgumentNullException.ThrowIfNull(nameof(data));
            if (string.IsNullOrEmpty(filename))
            {
                throw new NoValueDomainException("Имя файла не может быть пустым");
            }
            if (data.Length == 0)
            {
                throw new NoValueDomainException("Данные файла не могут быть пустыми");
            }
            Id  = id ?? throw new ArgumentNullException(nameof(id));
            FileName = string.IsNullOrEmpty(filename) ? throw new NoValueDomainException("Имя файла не может быть пустым") : filename;
            Data = data;
        }

        /// <summary>
        /// Имя файла
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Данные
        /// </summary>
        public byte[] Data { get; }
    }
}
