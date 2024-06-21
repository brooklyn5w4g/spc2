namespace spc2.Models;

public interface IDay
{
    Interval GetCurrentInterval(DateTime now);
}