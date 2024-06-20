namespace Models;

public class Day1 : IDay
{
    private List<TimeOnly> _releaseTimes { get; } =
    [
        new TimeOnly(1, 0, 0),
        new TimeOnly(6, 0, 0),
        new TimeOnly(13, 0, 0),
        new TimeOnly(16, 30, 0),
        new TimeOnly(20, 0, 0),
        new TimeOnly(1, 0, 0),
    ];

    public Interval GetCurrentInterval(DateTime now)
    {
        DateOnly nowDateOnly = DateOnly.FromDateTime(now);
        TimeOnly nowTimeOnly = TimeOnly.FromDateTime(now);
        for (int i = 0; i < _releaseTimes.Count - 1; i++)
        {
            TimeOnly t1 = _releaseTimes[i];
            TimeOnly t2 = _releaseTimes[i + 1];

            DateTime d1 = new(nowDateOnly, t1, DateTimeKind.Utc);

            if (t2 < t1)
            {
                if (nowTimeOnly < t2)
                {
                    d1 = d1.AddDays(-1);
                }
                else
                {
                    nowDateOnly = nowDateOnly.AddDays(1);
                }
            }
            DateTime d2 = new(nowDateOnly, t2, DateTimeKind.Utc);

            if (d1 <= now && now < d2)
            {
                DateTime actualStart = d1.TimeOfDay == new TimeSpan(6, 0, 0) ? new DateTime(DateOnly.FromDateTime(d1), new TimeOnly(12, 0)) : d1;

                return new Interval(d1, d2, actualStart);
            }
        }

        throw new ArgumentException("Could not find a valid time");
    }
}
