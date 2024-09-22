using System.Reflection;

namespace WorkerService.ContatoCreateEventConsumer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var projectName = GetProjectName();

            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation($"{projectName} em execução às: {DateTimeOffset.Now}");
                }
                await Task.Delay(10000, stoppingToken);
            }
        }

        public static string? GetProjectName()
        {
            return Assembly.GetExecutingAssembly().GetName().Name;
        }
    }
}
