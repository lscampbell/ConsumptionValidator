using System;

namespace TotalsService.Models
{
    public class EnergyRow
    {
        public int Id { get; set; }
        public string Mpan { get; set; }
        public string SupplyPointRef { get; set; }
        public DateTime Date { get; set; }
        public string Band { get; set; }
        public float PencePerKwh { get; set; }
        public int Kwh { get; set; }
        public decimal EnergyCost { get; set; }
        public int Count { get; set; }
        public DateTime Created { get; set; }
    }
}