namespace BackgroundWorkerBlazorConsole;

public class MyLogProvider : ILoggerProvider
{
    private readonly State _state;

    public MyLogProvider(State state)
    {
        _state = state;
    }
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new MyLogger(_state);
    }
}