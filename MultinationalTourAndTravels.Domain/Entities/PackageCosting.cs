using MultinationalTourAndTravels.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Domain.Entities
{
    public class PackageCosting : BaseEntity
    {
        public Guid PackageId { get; set; }
        public PackageType PackageType { get; set; }
        public PackageCostingType PackageCostingType { get; set; }
        public double Rate { get; set; }



        #region Navigational Properties
        [ForeignKey(nameof(PackageId))]
        public Package Package { get; set; } = null!;
        #endregion Navigational Properties
    }
}
