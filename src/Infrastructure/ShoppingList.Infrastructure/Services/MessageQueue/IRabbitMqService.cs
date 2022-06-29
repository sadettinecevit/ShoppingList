using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Infrastructure.Services.MessageQueue
{
    public interface IRabbitMqService
    {
        IConnectionFactory GetRabbirMqConnectionFactory();
        void Puslish(QueueMessage message);
    }
}


