using System.Reflection;
using EmailService.Application.Persistence.Repository;
using EmailService.Domain.OfMessage;
using Microsoft.EntityFrameworkCore;

namespace SqlServer.EF.EmailService.Context
{
    /// <summary>
    /// Контекст БД MsSQL для сервиса отправки почты
    /// </summary>
    public class EmailServiceContext : DbContext, IUnitOfWork
    {
        public EmailServiceContext()
        {

        }

        public EmailServiceContext(DbContextOptions<EmailServiceContext> options) : base(options)
        {
        }

        public virtual DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasSequence<long>("MessageHiLo").StartsAt(1).IncrementsBy(1);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<OptionalDateWithTime>().HaveConversion<OptionalDateWithTimeConverter>();
            configurationBuilder.Properties<DateWithTime>().HaveConversion<DateWithTimeConverter>();
        }

        public Task CommitAsync(CancellationToken cancellationToken = default)
        {
            return SaveChangesAsync(cancellationToken);
        }
    }
}
