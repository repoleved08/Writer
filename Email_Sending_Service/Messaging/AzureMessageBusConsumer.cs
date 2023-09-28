using Azure.Messaging.ServiceBus;
using Email_Sending_Service.Models;
using Email_Sending_Service.Services;
using Newtonsoft.Json;
using System.Text;

namespace Email_Sending_Service.Messaging
{
    public class AzureMessageBusConsumer : IAzureMessagingInterface
    {
        private readonly IConfiguration _configuration;
        private readonly string ConnectionString;
        private readonly string QueueName;
        private readonly ServiceBusProcessor _processor;
        private readonly EmailSendService _emailSendService;

        public AzureMessageBusConsumer(IConfiguration configuration)
        {

            _configuration = configuration;
            
            ConnectionString = _configuration.GetSection("ServiceBus:ConnectionString").Get<string>();
            QueueName = _configuration.GetSection("QueueTopic:RegU").Get<string>();

            var serviceBusClient = new ServiceBusClient(ConnectionString);
            _processor = serviceBusClient.CreateProcessor(QueueName);
            _emailSendService = new EmailSendService();
        }

        public async Task Start()
        {
            _processor.ProcessMessageAsync += OnRegistration;
            _processor.ProcessErrorAsync += ErrHandler;
            await _processor.StartProcessingAsync();
        }

        public async Task Stop()
        {
            await _processor.StopProcessingAsync();
            await _processor.DisposeAsync();
        }

        private Task ErrHandler(ProcessErrorEventArgs args)
        {
            throw new NotImplementedException();
        }

        private async Task OnRegistration(ProcessMessageEventArgs args)
        {
            var msg = args.Message;
            var body = Encoding.UTF8.GetString(msg.Body);
            var usrMsg = JsonConvert.DeserializeObject<UserMessage>(body);
            //TODO SEND MSG
            try
            {
                await args.CompleteMessageAsync(msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
