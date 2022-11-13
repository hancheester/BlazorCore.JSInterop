namespace BlazorCore.JSInterop.Geolocation;

public sealed class GeolocationError
{
	public GeolocationPositionErrorCodes ErrorCode { get; set; }
	public string ErrorMessage { get; set; }
}