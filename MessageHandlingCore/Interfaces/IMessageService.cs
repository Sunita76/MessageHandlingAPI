using MessageHandlingCore.Models;


namespace MessageHandlingCore.Interfaces
{
    public interface IMessageService
    {
        int AddMessage(string receiverName, string senderName, string content);
        List<Message> GetNewMessages(string receiverName);
        List<Message> GetMessagesByRange(string receiverName, int start, int end);

        void DeleteMessage(int messageId);
        int DeleteMultipleMessages(List<int> messageIds);
    }
}
