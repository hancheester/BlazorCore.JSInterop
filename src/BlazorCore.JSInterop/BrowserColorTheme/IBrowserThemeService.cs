﻿namespace BlazorCore.JSInterop.BrowserColorTheme;

public interface IBrowserThemeService : IAsyncDisposable
{
	/// <summary>
	/// Browser color scheme queries to return actual `prefers-color-scheme`.
	/// </summary>
	/// <returns>Async Task</returns>
	Task<BrowserColorThemes> GetBrowserColorThemeAsync();

	/// <summary>
	/// Adds event listener for `prefers-color-scheme` HTML event for the Browser.
	/// </summary>
	/// <param name="colorThemeChangeCallback"></param>
	/// <returns>Async Task</returns>
	Task<string> RegisterColorThemeChangeAsync(Func<BrowserColorThemes, Task> colorThemeChangeCallback);

	/// <summary>
	/// Removes event listener for `prefers-color-scheme` HTML event for the Browser.
	/// </summary>
	/// <param name="eventId">Event id from <see cref="RegisterColorThemeChangeAsync"/></param>
	/// <returns>Async Task</returns>
	Task RemoveColorThemeChangeAsync(string eventId);
}