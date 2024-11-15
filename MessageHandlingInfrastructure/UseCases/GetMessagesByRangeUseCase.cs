using MessageHandlingCore.Interfaces;
using MessageHandlingCore.Models;


namespace MessageHandlingInfrastructure.UseCases
{
    public class GetMessagesByRangeUseCase
    {
        private readonly IMessageService _messageService;

        public GetMessagesByRangeUseCase(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public GetMessagesResponse Execute(string receiverName, int start, int end)
        {
            var messagesByRange = _messageService.GetMessagesByRange(receiverName, start, end);
            return new GetMessagesResponse
            {
                Messages = messagesByRange.Select(message => new Message
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
