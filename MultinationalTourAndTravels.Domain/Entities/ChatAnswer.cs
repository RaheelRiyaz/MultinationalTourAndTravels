using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Domain.Entities
{
    public class ChatAnswer : BaseEntity
    {
        public Guid QuestionId { get; set; }
        public string Answer { get; set; } = null!;
    }
}
