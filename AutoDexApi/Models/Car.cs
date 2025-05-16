
namespace AutoDexApi.Models
{
    public class Car : Vehicle
    {
        public int Id { get; set; }
        public string Doors { get; set; }
        public string Traction { get; set; }
        public string TypeSteering { get; set; }
    }
}