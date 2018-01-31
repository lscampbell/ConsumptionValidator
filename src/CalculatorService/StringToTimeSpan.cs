using System;
namespace CalculatorService
{
    public class StringToTimeSpan
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public StringToTimeSpan(string start = "00:00:00", string end = "00:00:00")
        {
            StartTime = TimeSpan.Parse(start);
            EndTime = TimeSpan.Parse(end);
        }
    }
}