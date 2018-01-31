using System;//from ww  w  . j  a  v  a2s .  c o  m
using System.Globalization;
using UtilitiesService.Models;

namespace UtilitiesService
{
    public class StringTo
    {
        public Maybe<TimeSpan> StartTime { get; set; }
        public Maybe<TimeSpan> EndTime { get; set; }
        public void SetMultiplier(int i) => ReCalculate(i);
        public void ResetMultiplier() => Multiplier = 0;
        static int Multiplier = 0;
        public void TimeSpanSE(string startTime = "00:00:00", string endTime = "00:30:00")
        {
            StartTime = TimeSpan(startTime);
            EndTime = TimeSpan(endTime);
        }
        void ReCalculate(int newValue)
        {
            Multiplier = newValue;
            StartTime = TimeSpan(StartTime.Result.ToString("hh:mm:ss"));
            EndTime = TimeSpan(EndTime.Result.ToString("hh:mm:ss"));
        }
        void Up30()
        {
            Multiplier = 1;
            StartTime = TimeSpan(StartTime.Result.ToString("hh:mm:ss"));
            EndTime = TimeSpan(EndTime.Result.ToString("hh:mm:ss"));
        }
        public Maybe<TimeSpan> TimeSpan(string timeString = "00:00:00")
        {
            string format;
            TimeSpan interval;
            CultureInfo culture = null;

            // Parse hour:minute value with custom format specifier.
            format = "h\\:mm\\:ss";
            culture = CultureInfo.CurrentCulture;
            return
                System.TimeSpan.TryParseExact(timeString, format, culture, TimeSpanStyles.AssumeNegative, out interval)
            ?
                new Maybe<TimeSpan>
                {
                    Complete = true,
                    Result = interval.Add(System.TimeSpan.FromMinutes(30 * Multiplier)),
                    Message = $"'{0}' ({1}) --> {2}"
                }
            :
                new Maybe<TimeSpan>
                {
                    Complete = false,
                    Message = $"Unable to parse '{timeString}' using format {format}"
                };
        }
    }
}