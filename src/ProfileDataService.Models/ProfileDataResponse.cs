using System.Collections.Generic;

namespace ProfileDataService.Models
{
    public class ProfileDataResponse
    {
        public IEnumerable<ProfileRow> ProfileRows { get; set; }
        public bool Success { get; set; }
        public IEnumerable<dynamic> Errors { get; set; }
    }
}
