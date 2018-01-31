using System;
namespace TuosLossService.Models
{
    public class TuosCharge
    {
        public int Id { get; set; }
        public string MarketParticipantId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Charge { get; set; }
    }
}