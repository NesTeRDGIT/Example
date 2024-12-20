using EmailService.Application.Use.ClientQuery.GetStatus;
using EmailService.Domain.OfMessage;

namespace EmailService.Application.Interactor.ClientQuery.GetStatus
{
    public class GetStatusQueryHandler : IGetStatusQueryHandler
    {
        public Task<GetStatusResponse> HandleAsync(GetStatusQuery query)
        {
            return Task.FromResult(new GetStatusResponse
            {
                Statuses = Status.GetAll().Select(x=> new StatusProjection
                {
                    Value = x.Value,
                    Name = x.Name
                }).ToList()
            });
        }
    }
}
