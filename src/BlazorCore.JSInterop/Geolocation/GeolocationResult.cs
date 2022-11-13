namespace BlazorCore.JSInterop.Geolocation;

public sealed class GeolocationResult
{
	public GeolocationCoordinates? Coordinates { get; set; }
	public GeolocationError? Error { get; set; }
	public bool IsSuccess => Error is null && Coordinates is not null;
	public DateTime TimeStamp { get; set; }
}