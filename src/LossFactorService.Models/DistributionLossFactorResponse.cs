using System.Collections.Generic;

namespace LossFactorService.Models
{
    public class DistributionLossFactorResponse
    {
        public IEnumerable<DistributionLLF> Factors { get; set; }
        public bool Success { get; set; }
        public IEnumerable<dynamic> Errors { get; set; }
    }
}