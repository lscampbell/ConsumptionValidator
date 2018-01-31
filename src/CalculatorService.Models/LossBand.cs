namespace CalculatorService.Models
{
    public class LossBand
    {
        public string Band { get; set; }
        public float PencePerKwh { get; set; }
        public float TLossFactor { get; set; }
        public float TLossKwh { get; set; }
        public float DLossFactor { get; set; }
        public float DLossKwh { get; set; }
        public int Count { get; set; }
    }
}