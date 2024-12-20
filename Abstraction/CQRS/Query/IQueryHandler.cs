namespace Abstraction.CQRS.Query
{
    /// <summary>
    /// Обработчик запроса
    /// </summary>
    // ReSharper disable once TypeParameterCanBeVariant
    public interface IQueryHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
        where TResponse : IResponse
    {
        /// <summary>
        /// Выполнить запрос
        /// </summary>
        /// <param name="query">Запрос</param>
        /// <returns>Результат</returns>
        Task<TResponse> HandleAsync(TQuery query);
    }
}
