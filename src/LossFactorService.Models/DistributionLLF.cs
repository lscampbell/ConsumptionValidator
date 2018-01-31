using System;

namespace LossFactorService.Models
{
    public class DistributionLLF
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public float LossAdjustmentFactor { get; set; }
    }
}
