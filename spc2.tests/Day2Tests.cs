using System.Globalization;
using spc2.Models;

namespace spc2.tests;

public class Day2Tests
{
    [Theory]
    [InlineData("2024-06-12T20:18:00Z", "2024-06-12T20:00:00Z")]
    [InlineData("2024-06-13T00:18:00Z", "2024-06-12T20:00:00Z")]
    [InlineData("2024-06-12T23:18:00Z", "2024-06-12T20:00:00Z")]
    [InlineData("2024-06-12T19:18:00Z", "2024-06-12T16:30:00Z")]
    [InlineData("2024-06-12T16:18:00Z", "2024-06-12T13:00:00Z")]
    [InlineData("2024-06-12T12:00:00Z", "2024-06-12T06:00:00Z")]
    [InlineData("2024-06-12T05:18:00Z", "2024-06-12T01:00:00Z")]

    public void Day2_WhenGivenNow_ReturnsCorrectForStart(string nowString, string expectedString)
    {
        DateTime now = DateTime.Parse(nowString, null, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);
        DateTime expected = DateTime.Parse(expectedString, null, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);

        IDay day = new Day1();

        Interval i = day.GetCurrentInterval(now);

        Assert.Equal(expected, i.Start);
    }

    [Theory]
    [InlineData("2024-06-12T20:18:00Z", "2024-06-12T20:00:00Z")]
    [InlineData("2024-06-13T00:18:00Z", "2024-06-12T20:00:00Z")]
    [InlineData("2024-06-12T23:18:00Z", "2024-06-12T20:00:00Z")]
    [InlineData("2024-06-12T19:18:00Z", "2024-06-12T16:30:00Z")]
    [InlineData("2024-06-12T16:18:00Z", "2024-06-12T13:00:00Z")]
    [InlineData("2024-06-12T05:18:00Z", "2024-06-12T01:00:00Z")]
    // different
    [InlineData("2024-06-12T12:00:00Z", "2024-06-12T12:00:00Z")]
    [InlineData("2024-06-12T06:18:00Z", "2024-06-12T12:00:00Z")]
    [InlineData("2024-06-12T12:18:00Z", "2024-06-12T12:00:00Z")]

    public void Day1_WhenGivenNow_ReturnsCorrectForActualStart(string nowString, string expectedString)
    {
        DateTime now = DateTime.Parse(nowString, null, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);
        DateTime expected = DateTime.Parse(expectedString, null, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);

        IDay day = new Day1();

        Interval i = day.GetCurrentInterval(now);

        Assert.Equal(expected, i.ActualStart);
    }

    [Theory]
    [InlineData("2024-06-12T20:18:00Z", "2024-06-13T01:00:00Z")]
    [InlineData("2024-06-13T00:18:00Z", "2024-06-13T01:00:00Z")]
    [InlineData("2024-06-13T01:18:00Z", "2024-06-13T06:00:00Z")]
    [InlineData("2024-06-13T06:18:00Z", "2024-06-13T13:00:00Z")]
    [InlineData("2024-06-13T13:18:00Z", "2024-06-13T16:30:00Z")]
    [InlineData("2024-06-13T16:38:00Z", "2024-06-13T20:00:00Z")]
    public void Day1_WhenGivenNow_ReturnsCorrectForEnd(string nowString, string expectedString)
    {
        DateTime now = DateTime.Parse(nowString, null, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);
        DateTime expected = DateTime.Parse(expectedString, null, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);

        IDay day = new Day1();

        Interval i = day.GetCurrentInterval(now);

        Assert.Equal(expected, i.End);
    }
}