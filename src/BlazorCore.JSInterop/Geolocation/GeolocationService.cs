using Microsoft.JSInterop;

namespace BlazorCore.JSInterop.Geolocation;

public sealed class GeolocationService : IGeolocationService
{
    private const int DefaultTimeOut = 5000;
    private const int DefaultCacheTime = 0;

    private readonly IJSRuntime _jsRuntime;
    private IJSObjectReference _geoJs;
    private List<DotNetObjectReference<GeolocationEventWatcherInfo>> _dotNetObjectReferences;

    public GeolocationService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
        _dotNetObjectReferences = new List<DotNetObjectReference<GeolocationEventWatcherInfo>>();
    }

    public async Task GetCurrentPositionAsync(Func<GeolocationResult, Task> locationResultCallback, bool highAccuracy = false, TimeSpan? timeout = null, TimeSpan? cacheTime = null)
    {
        await CheckJsObjectAsync();

        var info = new GeolocationEventCurrentPositionInfo(locationResultCallback);
        var dotnetRef = DotNetObjectReference.Create<GeolocationEventCurrentPositionInfo>(info);
        info.DotNetObjectReference = dotnetRef; //Store ref to self dispose.

        await _geoJs.InvokeVoidAsync("getCurrentPosition", dotnetRef,
            highAccuracy,
            timeout?.TotalMilliseconds ?? DefaultTimeOut,
            cacheTime?.TotalMilliseconds ?? DefaultCacheTime);
    }

    public async ValueTask DisposeAsync()
    {
        if (_geoJs is not null)
        {
            if (_dotNetObjectReferences.Any())
            {
                await _geoJs.InvokeVoidAsync("dispose",
                    (object)_dotNetObjectReferences.Select(s => s.Value.HandlerId).Distinct().ToArray());
            }

            await _geoJs.DisposeAsync();
        }

        foreach (var item in _dotNetObjectReferences)
        {
            item.Dispose();
        }
    }

    private async Task CheckJsObjectAsync()
    {
        if (_geoJs is null)
        {
            _geoJs = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/BlazorCore.JsInterop/geo.js");
        }
    }
}
