
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore.Query;

namespace AutoDexApi.Models
{
    public abstract class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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

 
    }
}