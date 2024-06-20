public class Day2 : IDay
{
    private static readonly TimeOnly _firstReleaseTime = new TimeOnly(1, 0);
    private static readonly TimeOnly _secondReleaseTime = new TimeOnly(17, 30);

    private static readonly TimeZoneInfo _centralTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");

    public Interval GetCurrentInterval(DateTime now)
    {
        DateTime centralTime = TimeZoneInfo.ConvertTimeFromUtc(now, _centralTimeZone);
        TimeOnly centralTimeOnly = TimeOnly.FromDateTime(centralTime);

        DateOnly nowDateOnly = DateOnly.FromDateTime(now);
        TimeOnly nowTimeOnly = TimeOnly.FromDateTime(now);

        if (_firstReleaseTime < centralTimeOnly && nowTimeOnly < _secondReleaseTime)
        {
            DateTime start = TimeZoneInfo.ConvertTimeToUtc(new DateTime(nowDateOnly, _firstReleaseTime), _centralTimeZone);
            DateTime end = new DateTime(nowDateOnly, _secondReleaseTime);
            return new Interval(start, end);
        }
        else
        {
            DateOnly startDate = nowDateOnly;
            DateOnly endDate = nowDateOnly;

            if (nowTimeOnly > _secondReleaseTime)
            {
                endDate = nowDateOnly.AddDays(1);
            }
            else
            {
                startDate = nowDateOnly.AddDays(-1);
            }

            DateTime start = new DateTime(startDate, _secondReleaseTime);
            DateTime end = TimeZoneInfo.ConvertTimeToUtc(new DateTime(endDate, _firstReleaseTime), _centralTimeZone);

            return new Interval(start, end);
        }
    }
}