using MessageHandlingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageHandlingInfrastructure.UseCases
{
    public class GetMessagesResponse
    {
        public List<Message> Messages { get; set; }

    }
}
