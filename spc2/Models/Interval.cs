namespace spc2.Models;

public class Interval
{
    public Interval(DateTime start, DateTime end)
    {
        Start = start;
        ActualStart = start;
        End = end;
    }
    public Interval(DateTime start, DateTime end, DateTime actualStart)
    {
        Start = start;
        End = end;
        ActualStart = actualStart;
    }

    public DateTime Start { get; }
    public DateTime ActualStart { get; }
    public DateTime End { get; }
}
