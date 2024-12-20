using Abstraction.CQRS.Command;

namespace EmailService.Application.Use.Command.AddMessage
{
    /// <summary>
    /// Команда добавления сообщения
    /// </summary>
    public class AddMessageCommand : ICommand<AddMessageCommandResponse>
    {
        /// <summary>
        /// Сообщения
        /// </summary>
        public List<MessageProjection> Messages { get; set; }
    }
}
