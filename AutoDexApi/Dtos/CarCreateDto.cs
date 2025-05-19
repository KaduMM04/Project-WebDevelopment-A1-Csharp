

namespace AutoDexApi.Dtos
{
    public class CarCreateDto
    {
        public string? Name { get; set; }
        public string? Mark { get; set; }
        public int YearManufacture { get; set; }
        public string? Type { get; set; }
        public string? ImageUrl { get; set; }
        
        public string Doors { get; set; }
        public string Traction { get; set; }
        public string TypeSteering { get; set; }

    }
}