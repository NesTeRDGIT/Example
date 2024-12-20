using Abstraction.CQRS.Query.OfCollectionQuery;

namespace EmailService.Application.Use.ClientQuery.GetMessageListItem
{
    /// <summary>
    /// Обработчик запроса списка сообщений
    /// </summary>
    public interface IGetMessageListItemQueryHandler : ICollectionQueryHandler<GetMessageListItemQuery, MessageProjection>;
}
