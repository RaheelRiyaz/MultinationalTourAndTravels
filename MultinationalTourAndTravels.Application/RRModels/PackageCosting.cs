using MultinationalTourAndTravels.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.RRModels
{

    public record PackageCostingResponse(string PackageType,PackageCostingType PackageCostingType,Guid Id,double Rate);

    public class PackageCostingRequest
    {
        public Guid PackageId { get; set; }

        [Range(1,3)]
        public PackageType PackageType { get; set; }
        public double Rate { get; set; }
        [Range(1,4)]
        public PackageCostingType PackageCostingType { get; set; }
    }

    public class PackageCostings
    {
        public Guid Id { get; set; }
        public Guid PackageId { get; set; }
        public string PackageCosting { get; set; } = null!;
        public double Rate { get; set; }
    }

    public class PackageCostingDBResponse : PackageCostings
    {
        public string Package { get; set; } = null!;
      
    }

    public class PackageCostingClientResponse 
    {
        public string Package { get; set; } = null!;
        public IEnumerable<PackageCostings> PackageCostings { get; set; } = null!;
    }


}
