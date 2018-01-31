using System;

namespace SupplyPointService.Models
{
    public class SupplyCapacity
    {
        public int Id { get; set; }
        public string Mpan { get; set; }
        public string SupplyPointRef { get; set; }
        public DateTime EffectiveDate { get; set; }
        public int AvailableCapacity { get; set; }
    }
}