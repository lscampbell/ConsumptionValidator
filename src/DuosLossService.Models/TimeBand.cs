using System;

namespace DuosLossService.Models
{
    public class TimeBand
    {
        public int Id { get; set; }
        public string MarketParticipantId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ApplicableDays { get; set; }
        public string ApplicableMonths { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Band { get; set; }
    }
}