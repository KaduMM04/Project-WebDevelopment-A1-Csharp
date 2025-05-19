
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoDexApi.Models
{
    public class VehicleInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Engine { get; set; }
        public int Power { get; set; }
        public double Acceleration { get; set; }
        public int MaximumSpeed { get; set; }
        public string? FuelType { get; set; }
        public string? Transmission { get; set; }
        
        public int? VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

    }
}