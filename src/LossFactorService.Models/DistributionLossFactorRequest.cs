using System;

namespace LossFactorService.Models
{
    public class DistributionLossFactorRequest
    {
        public int LLF { get; set; }
        public string Area { get; set; }
        public string Date { get; set; }
    }
}