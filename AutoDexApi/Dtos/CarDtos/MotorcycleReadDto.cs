using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDexApi.Dtos.MotorcycleDtos
{
    public class MotorcycleReadDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Mark { get; set; }
        public int YearManufacture { get; set; }
        public string? Type { get; set; }
        public string? ImageUrl { get; set; }

        public string EngineDisplacement { get; set; }
        public string TypeHandlebar { get; set; }
        public string BrakeType { get; set; }

    }
}