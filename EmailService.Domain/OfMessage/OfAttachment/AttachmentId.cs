using Abstraction.DDD.OfEntity;

namespace EmailService.Domain.OfMessage.OfAttachment
{
    /// <summary>
    /// Идентификатор вложения
    /// </summary>
    public class AttachmentId : EntityId<AttachmentId>
    {
        public AttachmentId(long value)
        {
            Value = value;
        }
    }
}
