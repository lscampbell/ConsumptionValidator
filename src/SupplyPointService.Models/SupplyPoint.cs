namespace SupplyPointService.Models
{
    public class SupplyPoint
    {
        public int Id { get; set; }
        public string Mpan { get; set; }
        public string SupplyPointRef { get; set; }
        public string SiteId { get; set; }
        public string SiteName { get; set; }
        public string AccountId { get; set; }
        public string SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string MarketParticipantId { get; set; }
        public string MeterSerialNumber { get; set; }
    }
}