namespace Abstraction.CQRS.Query.OfCollectionQuery
{
    /// <summary>
    /// Обработчик запроса коллекции
    /// </summary>
    /// <typeparam name="TQuery">Тип ответа</typeparam>
    /// <typeparam name="TResponse">Тип запроса</typeparam>
    /// <typeparam name="TItem">Тип элемента возвращаемой коллекции</typeparam>
    public interface ICollectionQueryHandler<TQuery, TResponse, TItem> : IQueryHandler<TQuery, TResponse>
        where TQuery : CollectionQuery<TItem, TResponse>
        where TResponse : CollectionResponse<TItem>;

    /// <summary>
    /// Обработчик запроса коллекции
    /// </summary>
    /// <typeparam name="TQuery">Тип ответа</typeparam>
    /// <typeparam name="TItem">Тип элемента возвращаемой коллекции</typeparam>
    public interface ICollectionQueryHandler<TQuery, TItem> : IQueryHandler<TQuery, CollectionResponse<TItem>>
        where TQuery : CollectionQuery<TItem>;
}
