using EmailService.Domain.OfMessage;
using EmailService.Domain.OfMessage.OfAttachment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SqlServer.EF.EmailService.Context.Config
{
    public class MessageConfig : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable(nameof(Message),b=>b.HasComment("Таблица электронных писем")).HasRowVersion();

            builder.HasKey(t => t.Id);
            builder.Property(x => x.Id).HasConversion(x => x.Value, l => new MessageId(l)).IsRequired().ValueGeneratedNever().HasComment("Первичный ключ");

            builder.Property(x => x.CreatedDate).IsRequired().HasComment("Дата создания");
            builder.OwnsOne(x => x.Status, bs =>
            {
                bs.Property(x => x.Value).IsRequired().HasComment("Код статуса");
                bs.Property(x => x.Name).IsRequired().HasComment("Наименование статуса");
            }).Navigation(x => x.Status).IsRequired();


            builder.Property(x => x.Subject).IsRequired().HasComment("Тема письма");
            builder.Property(x => x.SenderName).IsRequired().HasComment("Имя отправителя");

            builder.OwnsOne(x => x.Body, bs =>
            {
                bs.OwnsOne(x => x.ContentType, bc =>
                {
                    bc.Property(x => x.Value).IsRequired().HasComment("Код типа содержимого");
                    bc.Property(x => x.Name).IsRequired().HasComment("Наименование типа содержимого");
                }).Navigation(x => x.ContentType).IsRequired();

                bs.OwnsOne(x => x.Content, bc =>
                {
                    bc.Property(x => x.Value).IsRequired().HasComment("Содержимое");
                }).Navigation(x => x.Content).IsRequired();

            }).Navigation(x => x.Body).IsRequired();

            builder.Property(x => x.ProcessedDate).IsRequired(false).HasComment("Дата обработки");
            builder.Property(x => x.ExternalId).IsRequired().HasConversion(x=>x.Value, s => new ExternalId(s)).HasComment("Внешний идентификатор");
            builder.Property(x => x.Comment).IsRequired().HasComment("Комментарий");


            builder.OwnsMany(x => x.Recipients, br =>
            {
                br.InitOwnsManyTable("Таблица получателей");

                br.Property(x => x.Name).IsRequired().HasComment("Имя получателя");
                br.OwnsOne(x => x.Email, eb =>
                {
                    eb.Property(x => x.Value).IsRequired().HasComment("Электронный адрес");
                }).Navigation(x => x.Email).IsRequired();
            });

            builder.OwnsMany(x => x.Attachments, br =>
            {
                br.InitOwnsManyTable("Таблица вложений");
                br.HasEntityId(x => x.Id);

                br.Property(x => x.Id).IsRequired().HasConversion(x => x.Value, v => new AttachmentId(v)).HasComment("Идентификатор в рамках сообщения");
                br.Property(x => x.FileName).IsRequired().HasComment("Имя файла");
                br.Property(x => x.Data).IsRequired().HasComment("Данные");
            });
        }
    }
}
