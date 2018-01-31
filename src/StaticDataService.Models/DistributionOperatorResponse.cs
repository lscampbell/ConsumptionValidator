using System.Collections.Generic;

namespace StaticDataService.Models
{
    public class DistributionOperatorResponse
    {
        public IEnumerable<DistributionNetworkOperator> Operators { get; set; }
        public bool Success { get; set; }
        public IEnumerable<dynamic> Errors { get; set; }
    }
}