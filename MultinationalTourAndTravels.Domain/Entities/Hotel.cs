using MultinationalTourAndTravels.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Domain.Entities
{
    public class Hotel : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Star Stars { get; set; }
        public PackageType PackageType { get; set; }
        public string Address { get; set; } = null!;

    }
}
