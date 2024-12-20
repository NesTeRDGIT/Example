using EmailService.Application.Persistence.QueryObject;
using EmailService.Domain.OfMessage;

namespace EmailService.Application.Interactor.Query.GetMessage
{
    public class GetMessageQueryHandler : IGetMessageQueryHandler
    {
        private readonly IGetMessageQueryObject getMessageQueryObject;

        public GetMessageQueryHandler(IGetMessageQueryObject getMessageQueryObject)
        {
            this.getMessageQueryObject = getMessageQueryObject ?? throw new ArgumentNullException(nameof(getMessageQueryObject));
        }

        public async Task<GetMessageResponse> HandleAsync(GetMessageQuery query)
        {
            ArgumentNullException.ThrowIfNull(query, nameof(query));
            ArgumentNullException.ThrowIfNull(query.Id, nameof(query.Id));


            return new GetMessageResponse
            {
                Messages = await getMessageQueryObject.GetAsync(query.Id.Select(x => new MessageId(x)).ToList())
            };
        }
    }
}
