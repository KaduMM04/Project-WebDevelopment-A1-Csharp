
using System.Security.AccessControl;

namespace AutoDexApi.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Mark { get; set;}
        public int YearManufacture { get; set; }
        public string? type { get; set; }
        public string? ImageUrl { get; set; }

        public VehicleInfo Infos { get; set; } = new VehicleInfo();
        
    }
}