using System.Diagnostics;
using System.Reflection;

namespace HostedService.ContatoCreateQueueConsumer
{
    public class Service : BackgroundService
    {
        protected async override Task ExecuteAsync(CancellationToken cancellingToken)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            while (!cancellingToken.IsCancellationRequested)
            {
                Debug.WriteLine($"[{assemblyName}] em execução...");
                await Task.Delay(5000, cancellingToken);
            }
        }
    }
}
