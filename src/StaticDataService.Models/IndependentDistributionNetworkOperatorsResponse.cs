using System.Collections.Generic;

namespace StaticDataService.Models
{
    public class IndependentDistributionNetworkOperatorsResponse
    {
        public IEnumerable<IndependentDistributionNetworkOperators> Operators { get; set; }
        public bool Success { get; set; }
        public IEnumerable<dynamic> Errors { get; set; }
    }
}
