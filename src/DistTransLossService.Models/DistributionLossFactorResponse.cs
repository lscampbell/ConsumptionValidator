using System.Collections.Generic;

namespace DistTransLossService.Models
{
    public class DistributionLossFactorResponse
    {
        public IEnumerable<Distribution> Factors { get; set; }
        public bool Success { get; set; }
        public IEnumerable<dynamic> Errors { get; set; }
    }
}