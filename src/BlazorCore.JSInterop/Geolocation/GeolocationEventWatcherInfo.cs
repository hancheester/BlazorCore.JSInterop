namespace BlazorCore.JSInterop.Geolocation;

internal sealed class GeolocationEventWatcherInfo : GeolocationEventInfo
{
	public int HandlerId { get; set; }

	public GeolocationEventWatcherInfo(Func<GeolocationResult, Task> locationResultCallback)
		: base(locationResultCallback)
	{
	}
}