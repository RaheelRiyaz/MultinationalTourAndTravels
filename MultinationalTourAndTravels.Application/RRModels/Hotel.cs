using Microsoft.AspNetCore.Http;
using MultinationalTourAndTravels.Application.Validators;
using MultinationalTourAndTravels.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.RRModels
{

    public class HotelRequest
    {

        [Required]
        public string Name { get; set; } = string.Empty;


        [Required]
        public string Address { get; set; } = string.Empty;


        [Range(1, 3, ErrorMessage = "Packagetype must be between 1 and 3")]
        public PackageType PackageType { get; set; }


       [Range(1,6,ErrorMessage ="Stars must be between 1 and 6")]
        public Star Stars { get; set; }


        public string Description { get; set; } = string.Empty;

        [Required]
        [IsFileImage("image/jpeg", "image/png", ErrorMessage = "Please provide a jpeg or png file")]
        public IFormFile File { get; set; } = null!;
    }



    public class HotelResponse
    {
        public Guid HotelId  { get; set; }
        public Guid FileId  { get; set; }
        public string FilePath { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PackageType { get; set; } = null!;
        public Star Stars { get; set; }
    }


    public class DestinationHotel
    {
        public Guid DestinationId { get; set; }
        public Guid HotelId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
