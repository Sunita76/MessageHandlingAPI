namespace MessageHandlingInfrastructure.UseCases
{
    public class SubmitMessageRequest
    {
        public string ReceiverName { get; set; }
        public string SenderName { get; set; }
        public string Content { get; set; }
       
    }
}
