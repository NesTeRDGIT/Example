using Abstraction.CQRS;

namespace EmailService.Application.Use.Command.AddMessage
{
    /// <summary>
    /// Результат добавления сообщения
    /// </summary>
    public class AddMessageCommandResponse : IResponse
    {
        /// <summary>
        /// Идентификаторы писем
        /// </summary>
        public List<long> Id { get; set; }
    }
}
