using System;

namespace UtilitiesService.Models
{
    public class DistributionLoss
    {
        public int Id { get; set; } 
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string MarketParticipantId { get; set; }
        public string LLF { get; set; }
        public float Factor { get; set; }
    }
}