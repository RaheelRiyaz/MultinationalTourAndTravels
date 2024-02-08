using Microsoft.AspNetCore.Http;
using MultinationalTourAndTravels.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.RRModels
{
    public record ItineraryRequest
        (
        Guid PackageId,
        //[IsFileImage("image/jpeg", "image/png", ErrorMessage = "Please provide a jpeg or png file")]
        IFormFile? File, 
        string Title,string 
        Description,
        int Day
        );

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
