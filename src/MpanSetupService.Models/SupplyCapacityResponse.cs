using System.Collections.Generic;

namespace MpanSetupService.Models
{
    public class SupplyCapacityResponse
    {
        public Models.SupplyCapacity Value { get; set; }
        public bool Success { get; set; }
        public IEnumerable<dynamic> Errors { get; set; }
    }
}