using spc2.Models;

namespace spc2.Service;

public class SingleCentralDayCalculator(TimeOnly centralReleaseTimeOnly)
{
    private readonly TimeOnly _centralReleaseTimeOnly = centralReleaseTimeOnly;

    private static readonly TimeZoneInfo _centralTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");

    public Interval GetInterval(DateTime now)
    {
        DateTime centralTime = TimeZoneInfo.ConvertTimeFromUtc(now, _centralTimeZone);
        DateOnly dateOnly = DateOnly.FromDateTime(centralTime);
        TimeOnly timeOnly = TimeOnly.FromDateTime(centralTime);

        if (timeOnly > _centralReleaseTimeOnly)
        {
            DateTime start = TimeZoneInfo.ConvertTimeToUtc(new DateTime(dateOnly, _centralReleaseTimeOnly), _centralTimeZone);
            DateTime end = TimeZoneInfo.ConvertTimeToUtc(new DateTime(dateOnly.AddDays(1), _centralReleaseTimeOnly));
            return new Interval(start, end);
        }
        else
        {
            DateTime start = TimeZoneInfo.ConvertTimeToUtc(new DateTime(dateOnly.AddDays(-1), _centralReleaseTimeOnly), _centralTimeZone);
            DateTime end = TimeZoneInfo.ConvertTimeToUtc(new DateTime(dateOnly, _centralReleaseTimeOnly));
            return new Interval(start, end);
        }
    }
}