namespace Email_Sending_Service.Messaging
{
    public interface IAzureMessagingInterface
    {
        Task Start();

        Task Stop();
    }
}
