using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.RRModels
{
    public record ItineraryRequest(Guid PackageId,IFormFile? File, string Title,string Description,int Day);

    public class ItineraryResponse 
    {
        public Guid Id { get; set; }
        public Guid? FileId { get; set; }
        public string FilePath { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Day { get; set; }
    }
}
