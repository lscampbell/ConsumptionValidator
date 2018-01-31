using System;

namespace CalculatorService.Models
{
    public class CombinedProfileLosses
    {
        public string DuosBand { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Kwh { get; set; }
        public float DuosChargePerKwh { get; set; }
        public float DuosUnitCharge { get; set; }
        public float TLoss { get; set; }
        public float TLossFactor { get; set; }
        public float DLoss { get; set; }
        public float DLossFactor { get; set; }
    }
}