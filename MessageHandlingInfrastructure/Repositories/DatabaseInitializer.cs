using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageHandlingInfrastructure.Repositories
{
     public class DatabaseInitializer
        {
            public static void Initialize(MessageDbContext context)
            {

                context.Database.EnsureCreated();
              
            }
        }
}
