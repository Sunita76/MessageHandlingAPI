using MessageHandlingCore.Interfaces;
using MessageHandlingCore.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MessageHandlingInfrastructure.Repositories
{
    public class MessageRepository : IMessageService
    {
        private readonly MessageDbContext context;
        public MessageRepository(MessageDbContext context)
        {
            this.context = context;
        }
        public int AddMessage(string receiverName, string senderName, string content)
        {
            Message message = new Message
            {
                ReceiverName = receiverName.Trim(),
                SenderName = senderName.Trim(),
                Content = content,
                SentDate = DateTime.UtcNow,
                IsFetched = false

            };
            context.Messages.Add(message);
            context.SaveChanges();
            return message.Id;

        }

        public List<Message> GetNewMessages(string receiverName)
        {
            string trimmedReceiverName = receiverName.Trim();
            var messages = context.Messages.Where(message => (message.ReceiverName == trimmedReceiverName) && !message.IsFetched).ToList();
            foreach(var message in messages)
            {
                message.IsFetched = true;
            }
            context.SaveChanges();

            return messages;
        }

        public List<Message> GetMessagesByRange(string receiverName, int start, int end)
        {
            string trimmedReceiverName = receiverName.Trim();
            List<Message> messages = context.Messages
                 .Where(message => message.ReceiverName == trimmedReceiverName)
                 .OrderBy(message => message.ReceiverName)
                 .ThenBy(message => message.SentDate)
                 .Skip(start)
                 .Take(end - start + 1)
                 .ToList();
            return messages;
        }
        public void DeleteMessage(int messageId)
        {
           var message = context.Messages.Where(message => message.Id == messageId).SingleOrDefault();
           
            if (message != null)
            {
                context.Messages.Remove(message);
                context.SaveChanges();
            }

            else
                throw new Exception($"The message with the id {messageId} is not found");
        }
        public int DeleteMultipleMessages(List<int> messageIds)
        {
            if (messageIds == null || !messageIds.Any())
            {
                return 0;
            }
           
            var parameters = messageIds.Select((id, index) => new SqlParameter($"@p{index}", id)).ToArray();
            var sql = $"DELETE FROM Messages WHERE Id IN ({string.Join(", ", parameters.Select(p => p.ParameterName))})";

            // Execute the raw SQL with parameters
            var rowsAffected = context.Database.ExecuteSqlRaw(sql, parameters);


            return rowsAffected;
        }
       

    }
}
