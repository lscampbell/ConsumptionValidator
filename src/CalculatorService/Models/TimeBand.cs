using System;

namespace CalculatorService.Models
{
    public class TimeBand
    {
        public string Type { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}