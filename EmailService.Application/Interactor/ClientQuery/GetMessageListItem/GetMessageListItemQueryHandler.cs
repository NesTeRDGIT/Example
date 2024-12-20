using Abstraction.CQRS.Query.OfCollectionQuery;
using EmailService.Application.Persistence.QueryObject.ClientQuery;
using EmailService.Application.Use.ClientQuery.GetMessageListItem;

namespace EmailService.Application.Interactor.ClientQuery.GetMessageListItem
{
    public class GetMessageListItemQueryHandler(IGetMessageListItemQueryObject getMessageListItemQueryObject) : IGetMessageListItemQueryHandler
    {
        private readonly IGetMessageListItemQueryObject getMessageListItemQueryObject = getMessageListItemQueryObject ?? throw new ArgumentNullException(nameof(getMessageListItemQueryObject));

        public async Task<CollectionResponse<MessageProjection>> HandleAsync(GetMessageListItemQuery query)
        {
            ArgumentNullException.ThrowIfNull(query, nameof(query));
            ArgumentNullException.ThrowIfNull(query.LightReadParams, nameof(query.LightReadParams));

            return query.QueryingPaginationMetadata
                ? new CollectionResponse<MessageProjection>(await getMessageListItemQueryObject.GetAsync(query.LightReadParams, query.Email), await getMessageListItemQueryObject.CountAsync(query.LightReadParams, query.Email))
                : new CollectionResponse<MessageProjection>(await getMessageListItemQueryObject.GetAsync(query.LightReadParams, query.Email));
        }
    }
}
