using System.Diagnostics;

namespace BackgroundWorkerBlazorConsole;


public class MyBackgroundService1 : BackgroundService
{
    private readonly ILogger<MyBackgroundService1> _logger;

    public MyBackgroundService1(ILogger<MyBackgroundService1> logger)
    {
        _logger = logger;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var activity = new Activity("OP1");
        activity.Start();
        while (!stoppingToken.IsCancellationRequested)
        {
            
            _logger.LogInformation(new Bogus.DataSets.Address().Country());
            await Task.Delay(Random.Shared.Next(100, 4000), stoppingToken);
        }
    }
}