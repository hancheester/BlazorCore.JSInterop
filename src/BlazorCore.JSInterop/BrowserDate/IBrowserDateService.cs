namespace BlazorCore.JSInterop.BrowserDate;

public interface IBrowserDateService
{
	/// <summary>
	/// Returns Date and time from browser client machine.
	/// </summary>
	/// <returns>Async Task</returns>
	Task<DateTime> GetBrowserDateTimeAsync();
}