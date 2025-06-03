

namespace AutoDexApi.Dtos
{
    public class MotorcycleCreateDto
    {
        public string? Name { get; set; }
        public string? Mark { get; set; }
        public int YearManufacture { get; set; }
        public string? Type { get; set; }
        public string? ImageUrl { get; set; }
        
        public string? Engine { get; set; }
        public int Power { get; set; }
        public int MaximumSpeed { get; set; }
        public string? FuelType { get; set; }
        public string? Transmission { get; set; }

        public string EngineDisplacement { get; set; }
        public string TypeHandlebar { get; set; }
        public string BrakeType { get; set; }
        
    }
}