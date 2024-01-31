using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Domain.Entities
{
    public class Itinerary : BaseEntity
    {
        public Guid PackageId { get; set; }
        public int Day { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;





        #region Navigational Properties
        //public IEnumerable<Itinerary> Itineraries { get; set; } = null!;
        [ForeignKey(nameof(PackageId))]
        public Package Package { get; set; } = null!;
        #endregion Navigational Properties
    }
}
