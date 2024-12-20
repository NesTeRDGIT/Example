using Abstraction.CQRS.Command;

namespace EmailService.Application.Use.Command.AddMessage
{
    /// <summary>
    /// Обработчик команды добавления сообщения
    /// </summary>
    public interface IAddMessageCommandHandler : ICommandHandler<AddMessageCommand, AddMessageCommandResponse>
    {
      
    }
}
