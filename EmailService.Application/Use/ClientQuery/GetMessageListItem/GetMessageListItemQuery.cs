using Abstraction.CQRS.Query.OfCollectionQuery;

namespace EmailService.Application.Use.ClientQuery.GetMessageListItem
{
    /// <summary>
    /// Запрос списка сообщений
    /// </summary>
    public class GetMessageListItemQuery : CollectionQuery<MessageProjection>
    {
        /// <summary>
        /// Параметры чтения
        /// </summary>
        //public LightReadParams<MessageProjection> LightReadParams { get; set; }

        /// <summary>
        /// Поиск по Email
        /// </summary>
        public string Email { get; set; }
    }
}
