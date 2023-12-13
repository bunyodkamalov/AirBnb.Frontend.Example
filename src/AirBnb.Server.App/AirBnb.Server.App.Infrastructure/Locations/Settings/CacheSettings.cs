namespace AirBnb.Server.App.Infrastructure.Locations.Settings;

public class CacheSettings
{
    public int AbsoluteExpirationInSeconds { get; set; }

    public int SlidingExpirationInSeconds { get; set; }
}
