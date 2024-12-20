using EmailService.Application.Persistence.Repository;
using EmailService.Domain.OfMessage;
using Microsoft.EntityFrameworkCore;
using SqlServer.EF.EmailService.Context;

namespace SqlServer.EF.EmailService.Repository
{
    public class MessageRepository : IMessageRepository
    {
        public async Task AddAsync(Message message, IUnitOfWork unitOfWork)
        {
            var emailServiceContext = GetDbContext(unitOfWork);
            await emailServiceContext.Messages.AddAsync(message);
        }

        public Task RemoveAsync(Message message, IUnitOfWork unitOfWork)
        {
            var emailServiceContext = GetDbContext(unitOfWork);
            return Task.FromResult(emailServiceContext.Messages.Remove(message));
        }

        public Task UpdateAsync(Message message, IUnitOfWork unitOfWork)
        {
            return Task.CompletedTask;
        }

        public async Task<IList<Message>> GetAsync(Specification<Message> specification, IUnitOfWork unitOfWork)
        {
            var emailServiceContext = GetDbContext(unitOfWork);
            return await emailServiceContext.Messages.Where(specification.ToExpression()).ToListAsync();
        }

        public async Task<bool> ExistAsync(Specification<Message> specification, IUnitOfWork unitOfWork)
        {
            var emailServiceContext = GetDbContext(unitOfWork);
            return await emailServiceContext.Messages.AnyAsync(specification.ToExpression());
        }

        private EmailServiceContext GetDbContext(IUnitOfWork unitOfWork)
        {
            var ctx = unitOfWork as EmailServiceContext;
            if (ctx == null)
                throw new InvalidCastException("Объект unitOfWork не соответствует реализации репозитория. Ожидается объект типа EmailServiceContext");
            return ctx;
        }

    }
}
