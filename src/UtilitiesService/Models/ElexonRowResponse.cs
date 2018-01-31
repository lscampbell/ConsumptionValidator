using System.Collections.Generic;
using ElexonImportService.Models;

namespace UtilitiesService.Models
{
    public class DistributionLossFactorResponse
    {
        public IEnumerable<ElexonRow> Factors { get; set; }
        public bool Success { get; set; }
        public IEnumerable<dynamic> Errors { get; set; }
    }
}