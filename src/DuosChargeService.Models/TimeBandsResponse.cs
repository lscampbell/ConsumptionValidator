using System.Collections.Generic;

namespace DuosChargeService.Models
{
    public class TimeBandsResponse
    {
        public IEnumerable<TimeBand> TimeBands { get; set; }
        public bool Success { get; set; }
        public IEnumerable<dynamic> Errors { get; set; }
    }
}
