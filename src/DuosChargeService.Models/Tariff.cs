namespace DuosChargeService.Models
{
    public class Tariff
    {
        public float Red { get; set; }
        public float Amber { get; set; }
        public float Green { get; set; }
        public float Fixed { get; set; }
        public float Capacity { get; set; }
        public float ExceededCapacity { get; set; }
    }
}