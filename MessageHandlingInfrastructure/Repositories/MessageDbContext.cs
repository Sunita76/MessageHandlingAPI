using MessageHandlingCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageHandlingInfrastructure.Repositories
{
    public class MessageDbContext : DbContext
    { 
        public DbSet<Message> Messages { get; set; }
        public MessageDbContext(DbContextOptions<MessageDbContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasIndex(m => new { m.ReceiverName, m.SentDate })  
                .HasDatabaseName("IX_Message_Receiver_SentDate"); 

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }
        public void Initialize()
        {
            DatabaseInitializer.Initialize(this);
        }


    }
}
