using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Caching.Memory;
using Models;
using Service;

namespace spc2.Controllers;

[Route("api/")]
[ApiController]
public class SpcController(IMemoryCache memoryCache, IConvectiveOutlookService convectiveOutlookService) : ControllerBase
{
    private readonly IMemoryCache _memoryCache = memoryCache;
    private readonly IConvectiveOutlookService _convectiveOutlookService = convectiveOutlookService;

    [HttpGet("day/{dayNumber}")]
    public async Task<string> GetSPCStatus(int dayNumber, double lat, double lon)
    {
        List<MultiPolygon> polygons = await _convectiveOutlookService.GetPolygonsAsync(dayNumber);

        foreach (MultiPolygon multiPolygon in polygons)
        {
            if (multiPolygon.Polygons.Any(p => p.PointInPolygon(new Point(lat, lon))))
            {
                return multiPolygon.Name;
            }
        }

        return "NONE";
    }
}
