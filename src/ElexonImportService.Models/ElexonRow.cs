using System;

namespace ElexonImportService.Models
{
    public class ElexonRow
    {
        public int Id { get; set; } 
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string MarketParticipantId { get; set; }
        public string LLF { get; set; }
        public float Factor { get; set; }
    }
}