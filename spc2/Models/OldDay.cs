// namespace Models;


// public abstract class Day
// {
//     private TimeSpan _lastUpdate;
//     protected virtual List<TimeSpan> _releaseTimes { get; }

//     public virtual int DayNumber { get; }

//     protected virtual TimeSpan GetLatestReleaseTime(DateTime now)
//     {
//         return new TimeSpan();
//     }

//     public virtual string GetReleaseString()
//     {
//         return GetLatestReleaseTime(DateTime.UtcNow).ToString("hhmm");
//     }

//     public virtual bool ShouldUpdate()
//     {
//         var releaseTime = GetLatestReleaseTime(DateTime.UtcNow);
//         if (_lastUpdate != releaseTime)
//         {
//             _lastUpdate = releaseTime;
//             return true;
//         }

//         return false;
//     }
// }