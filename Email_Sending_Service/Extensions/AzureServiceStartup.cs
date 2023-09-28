using Email_Sending_Service.Messaging;

namespace Email_Sending_Service.Extensions
{
    public static class AzureServiceStartup
    {
        public static IAzureMessagingInterface serviceBusConsumerInstance { get; set; }
        public static IApplicationBuilder UseAure(this IApplicationBuilder app)
        {
            serviceBusConsumerInstance = app.ApplicationServices.GetService<IAzureMessagingInterface>();

            var HostLifetime = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            HostLifetime.ApplicationStarted.Register(OnStart);
            HostLifetime.ApplicationStopping.Register(OnStop);

            return app;
        }

        private static void OnStop()
        {
            serviceBusConsumerInstance.Stop();
        }

        private static void OnStart()
        {
            serviceBusConsumerInstance.Start();
        }
    }
}
