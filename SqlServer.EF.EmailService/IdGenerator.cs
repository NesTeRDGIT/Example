using Abstraction.DDD.OfEntity;
using EmailService.Domain;
using EmailService.Domain.OfMessage;
using Microsoft.EntityFrameworkCore;
using SqlServer.EF.EmailService.Context;

namespace SqlServer.EF.EmailService
{
    /// <summary>
    /// Генератор ID
    /// </summary>
    public class IdGenerator : EntityIdGeneratorBase, IIdGenerator 
    {
        private readonly DbContextOptions<EmailServiceContext> options;

        public IdGenerator(DbContextOptions<EmailServiceContext> options)
        {
            this.options = options;
            AddKeyParameter(typeof(MessageId), "MessageHiLo");
        }

        public async Task<TEntityId> NewIdAsync<TEntityId>() where TEntityId : IEntityId
        {
            await using var context = new EmailServiceContext(options);
            return await NewId<TEntityId>(context);
        }
    }
}
