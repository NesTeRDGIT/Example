namespace Abstraction.CQRS.Command
{
    /// <summary>
    /// Обработчик команды
    /// </summary>
    /// <typeparam name="TCommand">Команда</typeparam>
    /// <typeparam name="TResponse">Результат</typeparam>
    // ReSharper disable once TypeParameterCanBeVariant
    public interface ICommandHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
        where TResponse : IResponse
    {
        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="command">Команда</param>
        /// <returns>Результат</returns>
        Task<TResponse> HandleAsync(TCommand command);
    }

    /// <summary>
    /// Обработчик команд
    /// </summary>
    /// <typeparam name="TCommand">Команда</typeparam>
    // ReSharper disable once TypeParameterCanBeVariant
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="command">Команда</param>
        Task HandleAsync(TCommand command);
    }
}
