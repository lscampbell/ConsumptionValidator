namespace CalculatorService.Models
{
    public class EnergyBand
    {
        public string Band { get; set; }
        public float PencePerKwh { get; set; }
        public int Kwh { get; set; }
        public float EnergyCost { get; set; }
        public int Count { get; set; }
    }
}