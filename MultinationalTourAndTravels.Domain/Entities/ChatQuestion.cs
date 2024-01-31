using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Domain.Entities
{
    public class ChatQuestion : BaseEntity
    {
        public string Question { get; set; } = null!;
        public bool Show { get; set; } = true;
    }
}
