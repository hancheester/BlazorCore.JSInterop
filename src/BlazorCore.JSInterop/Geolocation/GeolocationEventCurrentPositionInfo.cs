using Microsoft.JSInterop;

namespace BlazorCore.JSInterop.Geolocation;

internal sealed class GeolocationEventCurrentPositionInfo : GeolocationEventInfo
{
	internal DotNetObjectReference<GeolocationEventCurrentPositionInfo> DotNetObjectReference { get; set; }

	public GeolocationEventCurrentPositionInfo(Func<GeolocationResult, Task> locationResultCallback)
		: base(locationResultCallback)
	{
	}

	[JSInvokable("GeolocationEvent")]
	public override async Task GeolocationEvent(GeolocationResult args)
	{
		await base.GeolocationEvent(args);

		if (DotNetObjectReference is not null) 
		{
			DotNetObjectReference.Dispose();
		}
	}
}