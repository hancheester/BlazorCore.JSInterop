using Microsoft.JSInterop;

namespace BlazorCore.JSInterop.BrowserDate;

public class BrowserDateService : IBrowserDateService
{
	private readonly IJSRuntime _jSRuntime;

	public BrowserDateService(IJSRuntime jSRuntime)
	{
		_jSRuntime = jSRuntime;
	}

	public async Task<DateTime> GetBrowserDateTimeAsync()
	{
		return await _jSRuntime.InvokeAsync<DateTime>("eval", "(new Date()).toJSON();");
	}
}