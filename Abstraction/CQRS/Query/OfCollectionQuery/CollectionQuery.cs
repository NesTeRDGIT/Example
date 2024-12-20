namespace Abstraction.CQRS.Query.OfCollectionQuery
{
    /// <summary>
    /// Запрос коллекции
    /// </summary>
    /// <typeparam name="TItem">Тип элемента возвращаемой коллекции</typeparam>
    /// <typeparam name="TResponse">Тип ответа</typeparam>
    public abstract class CollectionQuery<TItem, TResponse> : IQuery<TResponse>
        where TResponse : CollectionResponse<TItem>
    {
        /// <summary>
        /// Запрашивать метаданные пагинации
        /// </summary>
        public bool QueryingPaginationMetadata { get; set; }
    }

    /// <summary>
    /// Запрос коллекции
    /// </summary>
    /// <typeparam name="TItem">Тип элемента возвращаемой коллекции</typeparam>
    public abstract class CollectionQuery<TItem> : CollectionQuery<TItem, CollectionResponse<TItem>>;
}
