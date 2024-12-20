namespace Abstraction.CQRS.Command
{
    /// <summary>
    /// Команда, возвращающая результат
    /// </summary>
    public interface ICommand<TResponse>
        where TResponse : IResponse
    {
    }

    /// <summary>
    /// Команда
    /// </summary>
    public interface ICommand
    {
    }
}
