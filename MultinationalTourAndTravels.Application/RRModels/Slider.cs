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
    public record SliderRequest(
        [IsFileImage("image/jpeg", "image/png", ErrorMessage = "Please provide a jpeg or png file")]
        IFormFile File,
        string Description,
        ShowSlide ShowSlide);
    public class SlideStatusRequest 
    {
        public Guid Id { get; set; }


        [Range(1,2,ErrorMessage ="Please select number between 1 and 2")]
        public ShowSlide Status { get; set; }
    } 
    public class SliderResponse
    {
        public string FilePath { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string SlideStatus { get; set; } = null!;
        public Guid Id { get; set; }
    }
}
