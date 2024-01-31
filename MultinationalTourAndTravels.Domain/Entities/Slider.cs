using MultinationalTourAndTravels.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Domain.Entities
{
    public class Slider : BaseEntity
    {
        public string? Description { get; set; }
        public ShowSlide ShowSlide { get; set; }
    }
}
