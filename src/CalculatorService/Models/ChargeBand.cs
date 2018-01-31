using System;

namespace CalculatorService.Models
{
    public class ChargeBand
    {
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public float PencePerKwh { get; set; }
    }
}