
using MessageHandlingCore.Models;
using MessageHandlingInfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Xunit;

namespace MessageHandlingTest
{
    public class MessageRepositoryTests
    {
        private readonly MessageDbContext _context;
        private readonly MessageRepository _repository;

        public MessageRepositoryTests()
        {
            // Setting up in-memory database options
            var options = new DbContextOptionsBuilder<MessageDbContext>()
                .UseInMemoryDatabase(databaseName: "MessageTestDb")
                .Options;

            _context = new MessageDbContext(options);
            
            _context.Messages.AddRange(new List<Message>
            {
            new Message { ReceiverName = "Sunita", SenderName = "Anita", Content = "Hello Sunita", SentDate = new System.DateTime(2024,11,12), IsFetched = false },
            new Message { ReceiverName = "Sunita", SenderName = "Vijay", Content = "Message from Vijay", SentDate = new System.DateTime(2024,11,10), IsFetched = false },
            new Message { ReceiverName = "Sunita", SenderName = "Aksh", Content = "Message from aksh", SentDate = new System.DateTime(2024,11,10), IsFetched = false }

            });
            _context.SaveChanges();
            _repository = new MessageRepository(_context);

        }
        [Fact]
        public void GetMessageByReceiverTest()
        { // Arrange
            var receiver = "Sunita";
                        
            // Act
            var result = _repository.GetNewMessages(receiver);

            // Assert
            Assert.NotNull(result);
            Assert.All(result, message => Assert.Equal(receiver, message.ReceiverName));
        }

        [Fact]
        public void MessageDoesNotExistTest()
        { // Arrange
            var receiver = "Ritu";

            // Act
            var result = _repository.GetNewMessages(receiver);

            // Assert
            Assert.Empty(result);
           
        }

        [Fact]
        public void GetMessagesByRangeTest()
        { // Arrange
            var receiver = "Sunita";

            // Act
            var result = _repository.GetMessagesByRange(receiver,0,2);

            // Assert
            Assert.Equal(3, result.Count);

        }
        [Fact]
        public void SubmitNewMessageTest()
        { // Arrange
            _repository.AddMessage("Anita", "Vijay", "New Message from Anita");
            // Act
            var result = _repository.GetNewMessages("Anita");

            // Assert
            Assert.Single(result);
           

        }
        [Fact]
        public void DeleteMessage_WhenMessageExistsTest()
        {
            // Arrange
            var message = new Message { SenderName = "Test", ReceiverName = "Testing", Content = "Test Message" };
            _context.Messages.Add(message);
            _context.SaveChanges();

            // Act
            var id = _repository.GetNewMessages("Testing")[0].Id;
            _repository.DeleteMessage(id);

            // Assert
            var deletedMessage = _context.Messages.Find(id);
            Assert.Null(deletedMessage); // Message should no longer exist in the database
        }
    }
}