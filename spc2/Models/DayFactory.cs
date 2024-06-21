namespace spc2.Models;

public class DayFactory
{
    public static IDay GetDay(int dayNumber)
    {
        return dayNumber switch
        {
            1 => new Day1(),
            2 => new Day2(),
            3 => new Day3(),
            4 => new Day4(),
            _ => throw new ArgumentException("day not found"),
        };
    }
 }