using System;

namespace ProfileRowsService.Models
{
    public class ProfileRow
    {
        public int Id { get; set; }
        public string Mpan { get; set; }
        public string SupplyPointRef { get; set; }
        public DateTime Date { get; set; }
        public float Kwh { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}