using EmailService.Application.Persistence.QueryObject.ClientQuery;
using EmailService.Application.Use.ClientQuery.GetMessageListItem;
using SqlServer.EF.EmailService.Context;

namespace SqlServer.EF.EmailService.QueryObject.ClientQuery
{
    public class GetMessageListItemQueryObject : IGetMessageListItemQueryObject
    {
        private readonly EmailServiceContext emailServiceContext;

        public GetMessageListItemQueryObject(EmailServiceContext emailServiceContext)
        {
            this.emailServiceContext = emailServiceContext ?? throw new ArgumentNullException(nameof(emailServiceContext));
        }

        public async Task<List<MessageProjection>> GetAsync(LightReadParams<MessageProjection> lightReadParams, string email)
        {
            return await GetMessageProjections(email).Apply(lightReadParams).ToListAsync();
        }

        public async Task<long> CountAsync(LightReadParams<MessageProjection> lightReadParams, string email)
        {
            return await GetMessageProjections(email).ApplyFilter(lightReadParams).CountAsync();
        }

        internal IQueryable<MessageProjection> GetMessageProjections(string email)
        {
            var query = emailServiceContext.Messages
                .SelectMany(x => x.Recipients
                    .Select(r => new
                    {
                        x.Id,
                        x.CreatedDate, 
                        StatusName = x.Status.Name, 
                        StatusValue = x.Status.Value, 
                        x.ProcessedDate, 
                        x.Comment, 
                        x.ExternalId, 
                        Email = r.Email.Value
                    }));

            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(x => x.Email.Contains(email));
            }

            return query.GroupBy(x => new { x.Id, x.CreatedDate, x.StatusName, x.StatusValue, x.ProcessedDate, x.Comment, x.ExternalId })
                .Select(x => new MessageProjection
                {
                    Id = x.Key.Id,
                    CreatedDate = x.Key.CreatedDate,
                    StatusValue = x.Key.StatusValue,
                    StatusName = x.Key.StatusName,
                    ProcessedDate = x.Key.ProcessedDate,
                    Comment = x.Key.Comment,
                    ExternalId = x.Key.ExternalId,
                    Email = x.Count() == 1 ? x.Max(r=>r.Email) : "(несколько)"
                });
        }
    }
}
