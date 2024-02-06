using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Domain.Entities
{
    public class Booking : BaseEntity
    {
        public Guid PackageId { get; set; }
        public DateTime TravelDate { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Contact { get; set; } = null!;
        public int NoOfAdults { get; set; }
        public int NoOfChildrens { get; set; }
        public bool IsVerified { get; set; } = false;




        #region Navigational Properties
        [ForeignKey(nameof(PackageId))]
        public Package Package { get; set; } = null!;
        #endregion Navigational Properties
    }
}
