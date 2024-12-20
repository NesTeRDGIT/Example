namespace Abstraction.CQRS.Query.OfCollectionQuery
{
    /// <summary>
    /// Ответ на запрос коллекции
    /// </summary>
    /// <typeparam name="TItem">Тип элемента возвращаемой коллекции</typeparam>
    public class CollectionResponse<TItem> : IResponse
    {
        public CollectionResponse()
        {
        }

        public CollectionResponse(IList<TItem> data)
        {
            Data = data;
        }

        public CollectionResponse(IList<TItem> data, long totalCount) : this(data)
        {
            Metadata = new Metadata(totalCount);
        }

        /// <summary>
        /// Данные
        /// </summary>
        public IList<TItem> Data { get; set; }

        /// <summary>
        /// Метаданные
        /// </summary>
        public Metadata Metadata { get; set; } = new();
    }
}
