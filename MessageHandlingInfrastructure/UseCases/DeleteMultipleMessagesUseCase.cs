using MessageHandlingCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageHandlingInfrastructure.UseCases
{
    public class DeleteMultipleMessagesUseCase
    {
        private readonly IMessageService _messageService;

        public DeleteMultipleMessagesUseCase(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public int Execute(List<int> messageIds)
        {
            return _messageService.DeleteMultipleMessages(messageIds);

        }
    }
}
