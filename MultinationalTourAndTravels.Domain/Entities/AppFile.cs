using MultinationalTourAndTravels.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Domain.Entities
{
    public class AppFile : BaseEntity
    {
        public string FilePath { get; set; } = null!;
        public Guid? EntityId { get; set; }
        public AppModule AppModule { get; set; }
    }
}
