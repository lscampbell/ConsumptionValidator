using System;

namespace MpanSetupService.Models
{
    public class ChargeBand
    {
        public string Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public float PencePerKwh { get; set; }
    }
}