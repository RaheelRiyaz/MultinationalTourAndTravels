using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Domain.Entities
{
    public class Package : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Days { get; set; }
        public int Nights { get; set; }
        public double StartingPrice { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
