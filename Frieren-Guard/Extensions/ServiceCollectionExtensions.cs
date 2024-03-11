namespace Frieren_Guard.Extensions;

using Frieren_Guard.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

public static class ServiceCollectionExtensions
{
    public static void AddFrierenGuardServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<SystemStatusMonitor>();
        services.AddSingleton<IHealthCheckNotifier, HealthCheckNotifier>();
        services.AddSingleton<IHealthCheckPublisher, HealthCheckPublisher>();
        var frierenGuardConfiguration = new FrierenGuardConfiguration();
        configuration.GetSection("FrierenGuardConfiguration").Bind(frierenGuardConfiguration);
        services.Configure<HealthCheckPublisherOptions>(options =>
        {
            options.Period = TimeSpan.FromMinutes(frierenGuardConfiguration.IntervalSeconds);
        });
    }
}
