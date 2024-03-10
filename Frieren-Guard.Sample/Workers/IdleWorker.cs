namespace Frieren_Guard.Sample.Workers;

using Frieren_Guard.Events;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class IdleWorker : BackgroundService
{
    private readonly SystemStatusMonitor _statusMonitor;
    private readonly ILogger<IdleWorker> _logger;

    public IdleWorker(SystemStatusMonitor statusMonitor, ILogger<IdleWorker> logger)
    {
        _statusMonitor = statusMonitor;
        _statusMonitor.SystemStatusChanged += OnSystemStatusChanged;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(2000, stoppingToken);
        }
    }

    private void OnSystemStatusChanged(object sender, SystemStatusChangedEvent e)
    {
        HealthReport newHealthReport = e.HealthReport;
        _logger.LogInformation("New state of the system: {status}", newHealthReport.Status);
    }
}