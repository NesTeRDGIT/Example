using Abstraction.DDD.OfEntity;

namespace EmailService.Domain.OfMessage
{
    /// <summary>
    /// Идентификатор сообщения
    /// </summary>
    public class MessageId : EntityId<MessageId>
    {
        public MessageId(long value)
        {
            Value = value;
        }
    }
}