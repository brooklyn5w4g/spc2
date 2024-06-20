using Microsoft.Extensions.Caching.Memory;
using Models;
using spc2;

namespace Service;

public interface IConvectiveOutlookService
{
    Task<List<MultiPolygon>> GetPolygonsAsync(int dayNumber);
}

public class ConvectiveOutlookService(IUrlService urlService, IMemoryCache memoryCache) : IConvectiveOutlookService
{
    private readonly IUrlService _urlService = urlService;
    private readonly IMemoryCache _memoryCache = memoryCache;

    public async Task<List<MultiPolygon>> GetPolygonsAsync(int dayNumber)
    {
        string dayKey = $"day{dayNumber}";

        if (_memoryCache.TryGetValue(dayKey, out List<MultiPolygon> polygons))
        {
            return polygons;
        }

        DateTime now = DateTime.UtcNow;
        IDay day = DayFactory.GetDay(dayNumber);

        Interval interval = day.GetCurrentInterval(now);

        string url = _urlService.GetUrl(dayNumber, interval.ActualStart, now);

        Console.WriteLine(url);

        List<MultiPolygon> multiPolygons = await GetPolygonsFromUrl(url);

        multiPolygons.Sort();

        return _memoryCache.Set(dayKey, multiPolygons, interval.End - now);
    }

    private static async Task<List<MultiPolygon>> GetPolygonsFromUrl(string url)
    {
        using HttpClient httpClient = new HttpClient();
        Root root = await httpClient.GetFromJsonAsync<Root>(url) ?? throw new HttpRequestException("Failed to get stuff");

        return root.features.Select(f => new MultiPolygon()
        {
            Name = f.properties.LABEL,
            Polygons = f.geometry.coordinates.Select(c => new Polygon(c.First().Select(p => new Point(p[1], p[0])).ToList())).ToList()
        }).ToList();
    }
}
