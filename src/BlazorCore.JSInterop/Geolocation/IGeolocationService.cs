namespace BlazorCore.JSInterop.Geolocation;

public interface IGeolocationService : IAsyncDisposable
{
    Task GetCurrentPositionAsync(Func<GeolocationResult, Task> locationResultCallback, bool highAccuracy = false, TimeSpan? timeout = null, TimeSpan? cacheTime = null);
}
