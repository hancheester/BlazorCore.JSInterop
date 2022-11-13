using Microsoft.JSInterop;

namespace BlazorCore.JSInterop.Geolocation;

internal abstract class GeolocationEventInfo
{
	private readonly Func<GeolocationResult, Task> _locationResultCallback;

	public GeolocationEventInfo(Func<GeolocationResult, Task> locationResultCallback)
	{
		_locationResultCallback = locationResultCallback;
	}

	[JSInvokable("GeolocationEvent")]
	public virtual async Task GeolocationEvent(GeolocationResult args)
	{
		if (_locationResultCallback is not null)
		{
			await _locationResultCallback(args);
		}
	}
}