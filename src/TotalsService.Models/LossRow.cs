using System;

namespace TotalsService.Models
{
    public class LossRow
    {
        public int Id { get; set; }
        public string Mpan { get; set; }
        public string SupplyPointRef { get; set; }
        public DateTime Date { get; set; }
        public string Band { get; set; }
        public float PencePerKwh { get; set; }
        public float DLossKwh { get; set; }
        public float TLossKwh { get; set; }
        public int Count { get; set; }
        public DateTime Created { get; set; }
    }
}