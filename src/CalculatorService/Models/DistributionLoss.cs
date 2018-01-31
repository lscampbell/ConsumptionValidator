using System;

namespace CalculatorService.Models
{
    public class DistributionLoss
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public float LossAdjustmentFactor { get; set; }
    }
}