using System.Collections.Generic;

namespace MpanSetupService.Models
{
    public class CompleteMpanResponse
    {
        public IEnumerable<MpanMeta> CompleteMpans { get; set; }
        public bool Success { get; set; }
        public IEnumerable<dynamic> Errors { get; set; }
    }
}