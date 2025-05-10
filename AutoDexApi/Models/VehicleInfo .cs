
namespace AutoDexApi.Models
{
    public class VehicleInfo 
    {
        public int id { get; set; }
        public string? Engine { get; set;}
        public int Power { get; set;}
        public double Acceleration { get; set; }
        public int MaximumSpeed { get; set; }
        public string? FuelType { get; set;}
        public string Transmission { get; set; }

    }
}