using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AutoDexApi.Models
{
    public class Car : Vehicle
    {
        
        public string Doors { get; set; }
        public string Traction { get; set; }
     
    }
}