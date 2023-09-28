using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenderBus
{
    public class MessageBusService : ISenderBus
    {
        public string ConnectionString = "Endpoint=sb://normangeek1.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=UFdUXRCYhotzZQqnl6X9jaWIg29NpJQSV+ASbBsMvmc=";

        public async Task PublishMessage(object message, string queueTopic)
        {
            var serviceBus = new ServiceBusClient(ConnectionString);
            var sender = serviceBus.CreateSender(queueTopic);
            var jsonMessage = JsonConvert.SerializeObject(message);
            var messageToSend = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString(),
            };
            await sender.SendMessageAsync(messageToSend);
            // Cleaning
            await serviceBus.DisposeAsync();
        }
    }
}
