namespace SupplyPointService.Models
{
    public class MeterPointAdministrationNumber
    {
        public int Id { get; set; }
        public string Mpan { get; set; }
        public string SupplyPointRef { get; set; }
        public string ProfileType { get; set; }
        public string MeterTimeSwitchCode { get; set; }
        public string LLF { get; set; }
        public string DistributionId { get; set; }
        public string UniqueIdentifer { get; set; }
        public string CheckDigit { get; set; }
    }
}