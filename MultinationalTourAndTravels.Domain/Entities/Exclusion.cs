using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Domain.Entities
{
    public class Exlusion : BaseEntity
    {
        public Guid PackageId { get; set; }
        public string Description { get; set; } = null!;




        #region Navigational properties
        [ForeignKey(nameof(PackageId))]
        [JsonIgnore]
        public Package Package { get; set; } = null!;
        #endregion Navigational properties
    }
}
