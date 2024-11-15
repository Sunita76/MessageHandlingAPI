using MessageHandlingCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageHandlingInfrastructure.UseCases
{
    public class SubmitMessageUseCase
    {
        private readonly IMessageService _messageService;

        public SubmitMessageUseCase(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public int Execute(SubmitMessageRequest request)
        {
            int response = _messageService.AddMessage(request.ReceiverName, request.SenderName, request.Content);
            return response;
        }
    }
}
