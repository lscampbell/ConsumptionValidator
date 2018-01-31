using System;

namespace TotalsService.Models
{
    public class DuosRow
    {
        public int Id { get; set; }
        public string Mpan { get; set; }
        public string SupplyPointRef { get; set; }
        public DateTime Date { get; set; }
        public string Band { get; set; }
        public int Units { get; set; }
        public string UOM { get; set; }
        public float UnitCharge { get; set; }
        public decimal Charge { get; set; }
        public int Count { get; set; }
        public DateTime Created { get; set; }
    }
}