using System;

namespace DuosLossService.Models
{
    public class Tariff
    {
        public int Id { get; set; }
        public string MarketParticipantId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LLF { get; set; }
        public string Name { get; set; }
        public float Red { get; set; }
        public float Amber { get; set; }
        public float Green { get; set; }
        public float Fixed { get; set; }
        public float Capacity { get; set; }
        public float ExceededCapacity { get; set; }
    }
}