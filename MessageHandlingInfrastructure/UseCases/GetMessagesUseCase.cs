using MessageHandlingCore.Interfaces;
using MessageHandlingCore.Models;


namespace MessageHandlingInfrastructure.UseCases
{
    public class GetMessagesUseCase
    {
        private readonly IMessageService _messageService;

        public GetMessagesUseCase(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public GetMessagesResponse Execute(string receiverName)
        {
            var newMessages = _messageService.GetNewMessages(receiverName);
            return new GetMessagesResponse
            {
                Messages = newMessages.Select(message => new Message
                {
                    Id = message.Id,
                    ReceiverName = message.ReceiverName,
                    SenderName = message.SenderName,
                    Content = message.Content,
                    SentDate = message.SentDate,
                    IsFetched = message.IsFetched
                }).ToList()


            };
        }

    }
}
