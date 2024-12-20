namespace Abstraction.CQRS.Query
{
    /// <summary>
    /// Запрос
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    // ReSharper disable once UnusedTypeParameter
    public interface IQuery<TResponse>
        where TResponse : IResponse
    {
    }
}
