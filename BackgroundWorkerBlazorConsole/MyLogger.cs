using System.Diagnostics;

namespace BackgroundWorkerBlazorConsole;

public class MyLogger : ILogger
{
    private readonly State _state;

    public MyLogger(State state)
    {
        _state = state;
    }
    public IDisposable BeginScope<TState>(TState state) => default!;

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        var message = $"{DateTimeOffset.Now:HH:mm:ss.fff} - {formatter(state, exception)}";

        var logEvent = new LogEvent(message, Activity.Current?.OperationName ?? "");
        _state.AddEventMessage(logEvent);
    }
}