namespace SsExample.Code;

public class AutoRefreshHelper : IDisposable
{
    private CancellationTokenSource debounceToken = null;
    private bool disposed = false;

    public string LastRefreshTime { get; set; } = "";
    public string RefreshTimeFormat { get; set; } = "M/d/y h:mm:ss tt";
    public TimeSpan RefreshInterval { get; set; } = new TimeSpan(0, 5, 0);
    public TimeSpan RefreshDuration { get; set; } = new TimeSpan(8, 0, 0);
    public int CurrentInterval { get; set; } = 0;
    public int MaxRefreshCount => (int)(RefreshDuration.TotalSeconds / RefreshInterval.TotalSeconds);

    // Based on https://stackoverflow.com/a/18336993/12189828
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing) { debounceToken?.Cancel(); }

            // Indicate that the instance has been disposed.
            disposed = true;
        }
    }


    public async Task RefreshAsync(Func<CancellationToken, Task> func)
    {
        try
        {
            // Cancel previous task
            if (debounceToken != null)
            {
                debounceToken.Cancel();
                LastRefreshTime = "";
            }

            // Assign new token
            debounceToken = new CancellationTokenSource();

            // Debounce delay
            await Task.Delay((int)RefreshInterval.TotalMilliseconds, debounceToken.Token);

            // Throw if canceled
            debounceToken.Token.ThrowIfCancellationRequested();

            // Increment refresh count
            CurrentInterval += 1;

            // Run function
            if (CurrentInterval <= MaxRefreshCount)
            {
                LastRefreshTime = DateTime.Now.ToString(RefreshTimeFormat);
                await func(debounceToken.Token);
            }
            else
            {
                debounceToken.Cancel();
            }
        }
        catch (TaskCanceledException) { }
    }
}
