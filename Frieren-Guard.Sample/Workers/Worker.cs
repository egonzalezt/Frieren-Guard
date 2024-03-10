namespace Frieren_Guard.Sample.Workers;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IHealthCheckNotifier _healthCheckNotifier;

    public Worker(ILogger<Worker> logger, IHealthCheckNotifier healthCheckNotifier)
    {
        _logger = logger;
        _healthCheckNotifier = healthCheckNotifier;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _logger.LogInformation("Checking health status");
                bool isServiceHealthy = CheckServiceHealth();
                if (!isServiceHealthy)
                {
                    _logger.LogWarning("Service is not healthy");
                    await _healthCheckNotifier.ReportUnhealthyServiceAsync(nameof(Worker), "ExampleService is not healthy.", stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while checking service health.");
            }

            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }
    }

    private bool CheckServiceHealth()
    {
        var random = new Random();
        return random.Next(10) > 4;
    }
}