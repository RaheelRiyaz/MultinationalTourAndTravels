using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Domain.Entities
{
    public class LinkTree : BaseEntity
    {
        public string Facebbook { get; set; } = string.Empty;
        public string Instagram { get; set; } = string.Empty;
        public string Whatsapp { get; set; } = string.Empty;
        public string Youtube { get; set; } = string.Empty;
        public string Google { get; set; } = string.Empty;
        public string Twitter { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
