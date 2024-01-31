using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public string? ResetCode { get; set; } 
        public DateTime? ResetExpirationDate { get; set; } 
        public string Password { get; set; } = null!;
    }
}
