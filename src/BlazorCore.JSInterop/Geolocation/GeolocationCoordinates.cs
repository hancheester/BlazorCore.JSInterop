﻿namespace BlazorCore.JSInterop.Geolocation;

public sealed class GeolocationCoordinates
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Accuracy { get; set; }
    public double? Altitude { get; set; }
    public double? AltitudeAccuracy { get; set; }
    public double? Speed { get; set; }
    public double? Heading { get; set; }
}
