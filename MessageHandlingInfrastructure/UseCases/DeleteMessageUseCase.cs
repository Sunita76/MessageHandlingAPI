using MessageHandlingCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageHandlingInfrastructure.UseCases
{
    public class DeleteMessageUseCase
    {
        private readonly IMessageService _messageService;

        public DeleteMessageUseCase(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public void Execute(int messageId)
        {
            _messageService.DeleteMessage(messageId);

        }
    }
}
