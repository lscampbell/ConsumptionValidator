using System.Collections.Generic;

namespace MpanSetupService.Models
{
    public class ChargeBandsResponse
    {
        public IEnumerable<ChargeBand> ChargeBands { get; set; }
        public bool Success { get; set; }
        public IEnumerable<dynamic> Errors { get; set; }
    }
}