namespace Abstraction.CQRS.Query.OfCollectionQuery
{
    /// <summary>
    /// Метаданные
    /// </summary>
    public class Metadata
    {
        public Metadata()
        {
            Pagination = null;
        }

        public Metadata(long totalCount)
        {
            Pagination = new Pagination(totalCount);
        }

        /// <summary>
        /// Данные о постраничном выводе
        /// </summary>
        public Pagination Pagination { get; set; }
    }
}
