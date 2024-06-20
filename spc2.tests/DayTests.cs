using System.Globalization;

namespace spc2.tests;

public class DayTests
{
    [Theory]
    [InlineData("2024-06-12T20:18:00Z", "2024-06-12T20:00:00Z")]
    [InlineData("2024-06-13T00:18:00Z", "2024-06-12T20:00:00Z")]
    [InlineData("2024-06-12T23:18:00Z", "2024-06-12T20:00:00Z")]
    [InlineData("2024-06-12T19:18:00Z", "2024-06-12T16:30:00Z")]
    [InlineData("2024-06-12T16:18:00Z", "2024-06-12T13:00:00Z")]
    [InlineData("2024-06-12T12:00:00Z", "2024-06-12T06:00:00Z")]
    [InlineData("2024-06-12T05:18:00Z", "2024-06-12T01:00:00Z")]

    public void Day1_WhenGivenNow_ReturnsCorrectForStart(string nowString, string expectedString)
    {
        DateTime now = DateTime.Parse(nowString, null, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);
        DateTime expected = DateTime.Parse(expectedString, null, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);

        IDay day = new Day1();

        Interval i = day.GetCurrentInterval(now);

        Assert.Equal(expected, i.Start);
    }
}