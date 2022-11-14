using Microsoft.JSInterop;

namespace BlazorCore.JSInterop.BrowserColorTheme;

internal sealed class BrowserThemeEventInfo
{
	private readonly Func<BrowserColorThemes, Task> _browserThemeChangedEventCallback;
	internal string EventId { get; }

	public BrowserThemeEventInfo(Func<BrowserColorThemes, Task> browserThemeChangedEventCallback, string eventId)
	{
		_browserThemeChangedEventCallback = browserThemeChangedEventCallback;
		EventId = eventId;
	}

	[JSInvokable("BrowserThemeChanged")]
	public async Task BrowserThemeChanged(int colorTheme)
	{
		if (_browserThemeChangedEventCallback is not null)
		{
			await _browserThemeChangedEventCallback((BrowserColorThemes)colorTheme);
		}
	}
}