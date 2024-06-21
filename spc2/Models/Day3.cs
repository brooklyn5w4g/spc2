using spc2.Service;

namespace spc2.Models;

public class Day3 : IDay
{
    private static readonly SingleCentralDayCalculator _dayCalculator = new SingleCentralDayCalculator(new TimeOnly(2, 30));

    public Interval GetCurrentInterval(DateTime now)
    {
        return _dayCalculator.GetInterval(now);
    }
}