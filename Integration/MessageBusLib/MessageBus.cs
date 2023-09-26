using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MessageBusLib
{
    public class MessageBus : IMessageBus
    {
        public string ConnectionString = "Endpoint=sb://normanservice.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=YDxuGX15gWhNKMmC4MsMFtdP2IItpgt6h+ASbEiWqwk=";
        public async Task PublishMessage(object message, string topicName)
        {
            var serviceBus = new ServiceBusClient(ConnectionString);
            var sender = serviceBus.CreateSender(topicName);

            var messageJson = JsonConvert.SerializeObject(message);

            var theMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(messageJson))
            {

                CorrelationId = Guid.NewGuid().ToString(),
            };

            await sender.SendMessageAsync(theMessage);
            await serviceBus.DisposeAsync();

        }
    }
}
