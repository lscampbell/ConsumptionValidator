using System.Collections.Generic;

namespace CalculatorService.Models
{
    public class CalculatorResponse
    {
        public dynamic Reply { get; set; }
        public bool Success { get; set; }
        public IEnumerable<dynamic> Errors { get; set; }
    }
}