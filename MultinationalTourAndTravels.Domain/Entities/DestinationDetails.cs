using MultinationalTourAndTravels.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Domain.Entities
{
    public class DestinationDetails : BaseEntity
    {
        public Guid DestinationId { get; set; }
        public PackageType PackageType { get; set; }
        public Guid HotelId { get; set; }






        #region Navigational Properties
        [ForeignKey(nameof(DestinationId))]
        public PackageDestination PackageDestination { get; set; } = null!;

        [ForeignKey(nameof(HotelId))]
        public Hotel Hotel { get; set; } = null!;
        #endregion Navigational Properties
    }
}
