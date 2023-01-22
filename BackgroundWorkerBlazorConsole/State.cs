namespace BackgroundWorkerBlazorConsole;

public class State
{
    public event Func<LogEvent, Task>? OnChange;

    public void AddEventMessage(LogEvent message)
    {
        OnChange?.Invoke(message);
    }
}