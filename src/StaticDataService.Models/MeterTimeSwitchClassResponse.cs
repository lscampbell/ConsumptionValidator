using System.Collections.Generic;

namespace StaticDataService.Models
{
    public class MeterTimeSwitchClassResponse
    {
        public IEnumerable<MeterTimeSwitchClass> MeterTimeSwitchClasses { get; set; }
        public bool Success { get; set; }
        public IEnumerable<dynamic> Errors { get; set; }
    }
}
