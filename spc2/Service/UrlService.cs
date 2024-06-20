

namespace spc2;


public interface IUrlService
{
    string GetUrl(int dayNumber, DateTime actualStart, DateTime now);
}
public class UrlService : IUrlService
{
    public string GetUrl(int dayNumber, DateTime actualStart, DateTime now)
    {
        return $"https://www.spc.noaa.gov/products/outlook/archive/{now.Year}/day{dayNumber}otlk_{now:yyyyMMdd}_{actualStart:HHmm}_cat.lyr.geojson";
    }
}
