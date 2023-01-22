using System.Diagnostics;

namespace BackgroundWorkerBlazorConsole;

public class MyBackgroundService2 : BackgroundService
{
    private readonly ILogger<MyBackgroundService2> _logger;

    public MyBackgroundService2(ILogger<MyBackgroundService2> logger)
    {
        _logger = logger;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var activity = new Activity("OP2");
        activity.Start();
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation(new Bogus.DataSets.Company().CompanyName());
            await Task.Delay(Random.Shared.Next(10, 1000), stoppingToken);
        }
    }
}

public class MyBackgroundService3 : BackgroundService
{
    private readonly ILogger<MyBackgroundService3> _logger;

    public MyBackgroundService3(ILogger<MyBackgroundService3> logger)
    {
        _logger = logger;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var activity = new Activity("OP3");
        activity.Start();
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation(new Bogus.DataSets.Commerce().ProductName());
            await Task.Delay(Random.Shared.Next(1000, 5000), stoppingToken);
        }
    }
}