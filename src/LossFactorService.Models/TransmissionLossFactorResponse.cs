using System.Collections.Generic;

namespace LossFactorService.Models
{
    public class TransmissionLossFactorResponse
    {
        public float Factor { get; set; }
        public bool Success { get; set; }
        public IEnumerable<dynamic> Errors { get; set; }
    }
}