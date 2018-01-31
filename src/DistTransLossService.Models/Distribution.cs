using System;
namespace DistTransLossService.Models
{
    public class Distribution
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string MarketParticipantId { get; set; }
        public string llf { get; set; }
        public float Factor { get; set; }
    }
}
