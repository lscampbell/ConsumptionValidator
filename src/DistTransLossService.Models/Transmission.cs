using System;

namespace DistTransLossService.Models
{
    public class Transmission
    {
        public int Id { get; set; }
        public DateTime EffectiveDate { get; set; }
        public float Factor { get; set; }
    }
} 