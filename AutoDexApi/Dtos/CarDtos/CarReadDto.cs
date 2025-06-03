using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDexApi.Dtos.CarDtos
{
    public class CarReadDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Mark { get; set; }
        public int YearManufacture { get; set; }
        public string? Type { get; set; }
        public string? ImageUrl { get; set; }

        public string Doors { get; set; }
        public string Traction { get; set; }
    }
}