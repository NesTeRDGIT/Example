using Abstraction.Exception;
using EmailService.Application.Persistence.Repository;
using EmailService.Application.Use.Command.AddMessage;
using EmailService.Domain;
using EmailService.Domain.OfMessage;
using EmailService.Domain.OfMessage.OfEmailBody;

namespace EmailService.Application.Interactor.Command.AddMessage
{
    public class AddMessageCommandHandler(IMessageRepository messageRepository, IUnitOfWork unitOfWork, IIdGenerator idGenerator) : IAddMessageCommandHandler
    {
        private readonly IMessageRepository messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
        private readonly IUnitOfWork unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        private readonly IIdGenerator idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));

        public async Task<AddMessageCommandResponse> HandleAsync(AddMessageCommand command)
        {
            ArgumentNullException.ThrowIfNull(command, nameof(command));
            ArgumentNullException.ThrowIfNull(command, nameof(command.Messages));

            var idResult = new List<MessageId>();
            foreach (var messageProjection in command.Messages)
            {
                var message = await CreateMessage(messageProjection);
                await messageRepository.AddAsync(message, unitOfWork);
                idResult.Add(message.Id);
            }

            await unitOfWork.CommitAsync();

            return new AddMessageCommandResponse
            {
                Id = idResult.Select(x => x.Value).ToList()
            };
        }


        private async Task<Message> CreateMessage(MessageProjection messageProjection)
        {
            ArgumentNullException.ThrowIfNull(messageProjection.Recipients, nameof(messageProjection.Recipients));
            ArgumentNullException.ThrowIfNull(messageProjection.Attachments, nameof(messageProjection.Attachments));

            var body = new EmailBody(ContentType.Get(messageProjection.ContentType), new Content(messageProjection.Content));
            var recipient = messageProjection.Recipients.Select(x => new Recipient(x.Name, new EmailAddress(x.Email))).ToList();

            if (recipient.Count > 10)
            {
                throw new InvalidOperationDomainException("Количество получателей не может превышать 10");
            }

            var messageId = await idGenerator.NewIdAsync<MessageId>();
            var message = new Message(messageId, DateTime.Now, messageProjection.SenderName, messageProjection.Subject, body, recipient);

            foreach (var messageProjectionAttachment in messageProjection.Attachments)
            {
                message.Attachments.Add(messageProjectionAttachment.FileName, messageProjectionAttachment.Data);
            }
            return message;
        }
    }
}
