namespace CalculatorService.Models
{
    public class CalculatorRequest
    {
        public string MarketParticipantId { get; set; }
        public string Date { get; set; }
        public string SupplyPoint { get; set; }
        public string LLF { get; set; }
    }
}