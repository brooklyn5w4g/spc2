using Microsoft.AspNetCore.Mvc;
using spc2.Models;
using spc2.Service;

namespace spc2.Controllers;

[Route("api/")]
[ApiController]
public class SpcController(IConvectiveOutlookService convectiveOutlookService) : ControllerBase
{
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
