namespace IndustryDataService.Models
{
    public class DistributionNetworkOperator
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public string Area { get; set; }
        public string Operator { get; set; }
        public string MarketParticipantId { get; set; }
        public string GSPGroupId { get; set; }
    }
}