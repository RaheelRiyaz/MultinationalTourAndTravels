using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Domain.Entities
{
    public class PackageDestination : BaseEntity
    {
        public Guid PackageId { get; set; }
        public string Name { get; set; } = null!;
        public string Stay { get; set; } = null!;






        #region Navigational Properties
        [ForeignKey(nameof(PackageId))]
        public Package Package { get; set; } = null!;
        #endregion Navigational Properties
    }
}
