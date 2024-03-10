using Frieren_Guard.Sample.Workers;
using Frieren_Guard.Extensions;
using Frieren_Guard.Sample;
var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddHostedService<IdleWorker>();
builder.Services.AddFrierenGuardServices(builder.Configuration);
builder.Services.AddHttpClient();


builder.Services.AddSingleton((serviceProvider) =>
{
    var apiUri = new Uri("https://example.com/");
    return new ApiHealthCheck(serviceProvider.GetRequiredService<IHttpClientFactory>(), apiUri);
});
builder.Services.AddLogging((loggingBuilder) => loggingBuilder
    .SetMinimumLevel(LogLevel.Trace)
    .AddConsole()
);

builder.Services.AddHealthChecks().AddCheck<ApiHealthCheck>("api_check");

var host = builder.Build();
host.Run();
