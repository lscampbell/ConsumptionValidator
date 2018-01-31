using System;

namespace DistTransLossService.Models
{
    public class DistributionLossFactorRequest
    {
        public string LLF { get; set; }
        public string MarketParticipantId { get; set; }
        public string Date { get; set; }
    }
}