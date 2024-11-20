using MessageHandlingCore.Interfaces;
using MessageHandlingCore.Models;
using MessageHandlingInfrastructure.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MessageHandlingAPI.Controllers
{
    [Produces("application/json")]
    [ResponseCache(NoStore = true)]
    [Route("api/messages")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public IActionResult SubmitMessage([FromBody] SubmitMessageRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (string.IsNullOrEmpty(request.SenderName) || string.IsNullOrEmpty(request.ReceiverName) || string.IsNullOrEmpty(request.Content))
                {
                    return BadRequest("One or more of the parameters is empty");
                }
                SubmitMessageUseCase submitMessageUseCase = new SubmitMessageUseCase(_messageService);
                var response = submitMessageUseCase.Execute(request);
                return Ok(response);

            }
            
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                });

            }

        }

        [HttpGet("{receiver}")]
        public IActionResult GetMessages(string receiver)
        {
            try
            {
                GetMessagesUseCase getMessagesUseCase = new GetMessagesUseCase(_messageService);
                var response = getMessagesUseCase.Execute(receiver);
                return Ok(response);

            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                });
            }

        }
        [HttpGet("range/{receiver}")]
        public IActionResult GetMessagesByRange(string receiver, [FromQuery] int start, [FromQuery] int end)
        {
            try
            {
               
                GetMessagesByRangeUseCase getMessagesByRangeUseCase = new GetMessagesByRangeUseCase(_messageService);
                var response = getMessagesByRangeUseCase.Execute(receiver, start, end);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                });
            }   

        }

        [HttpDelete("{messageId}")]
        public IActionResult DeleteMessage(int messageId)
        {
            try
            {
                DeleteMessageUseCase deleteMessageUseCase = new DeleteMessageUseCase(_messageService);
                deleteMessageUseCase.Execute(messageId);
                return Ok($"Message deleted");

            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                });
            }

        }

        [HttpDelete("bulk-delete")]
        public IActionResult DeleteMultipleMessages([FromBody] List<int> messageIds)
        {
            try
            {
                DeleteMultipleMessagesUseCase deleteMultipleMessagesUseCase = new DeleteMultipleMessagesUseCase(_messageService);
                var deletedMessagesCount = deleteMultipleMessagesUseCase.Execute(messageIds);
                return Ok($"{deletedMessagesCount} messages deleted" );
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                });
            }
        }



    }
}
