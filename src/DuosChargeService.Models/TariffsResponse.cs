using System.Collections.Generic;

namespace DuosChargeService.Models
{
    public class TariffsResponse
    {
        public Tariff Charges { get; set; }
        public bool Success { get; set; }
        public IEnumerable<dynamic> Errors { get; set; }
    }
}