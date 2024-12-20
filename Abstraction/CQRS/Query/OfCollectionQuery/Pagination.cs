namespace Abstraction.CQRS.Query.OfCollectionQuery
{
    /// <summary>
    /// Данные о постраничном выводе
    /// </summary>
    public class Pagination
    {
        public Pagination(long totalCount)
        {
            TotalCount = totalCount;
        }

        /// <summary>
        /// Общее количество элементов в исходной коллекции
        /// </summary>
        public long TotalCount { get; }
    }
}
