using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageHandlingCore.Models
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(150)]
        [Required(ErrorMessage = "Receiver name is required.")]
        public string ReceiverName { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Sender name is required.")]
        public string SenderName { get; set; }
        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; } 
        public DateTime SentDate { get; set; } = DateTime.UtcNow;
        public bool IsFetched { get; set; } = false;

    }
}
