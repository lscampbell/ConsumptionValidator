using System;

namespace CalculatorService.Models
{
    public class ProfileRow
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Kwh { get; set; }
    }
}