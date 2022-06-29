using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Infrastructure.Services.MessageQueue
{
    public class QueueMessage
    {
        public string EventDescription { get; set; } = string.Empty;
        public DateTime EventTime { get; set; } = DateTime.Now;
    }
}
