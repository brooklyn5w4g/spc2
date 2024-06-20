public class Day4 : IDay
{
    private static readonly SingleCentralDayCalculator _dayCalculator = new SingleCentralDayCalculator(new TimeOnly(4, 0));

    public Interval GetCurrentInterval(DateTime now)
    {
        return _dayCalculator.GetInterval(now);
    }
}