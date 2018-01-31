namespace IndustryDataService.Models
{
    public class IndependentDistributionNetworkOperator
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public string Area { get; set; }
        public string Licensee { get; set; }
        public string MarketParticipantId { get; set; }
    }
}