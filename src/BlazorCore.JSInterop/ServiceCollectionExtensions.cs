using BlazorCore.JSInterop.Geolocation;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorCore.JSInterop;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBlazorCoreJsInterop(this IServiceCollection services)
    {
        services.AddTransient<IGeolocationService, GeolocationService>();

        return services;
    }
}
