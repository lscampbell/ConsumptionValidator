using System;
namespace CustomerService.Models
{
    public class ContractBand
    {
        public int Id { get; set; }
        public string Mpan { get; set; }
        public string SupplyPointRef { get; set; }
        public string Customer { get; set; }
        public DateTime Date { get; set; }
        public float PencePerKwh { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Name { get; set; }
    }
}
