using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultinationalTourAndTravels.Application;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;

namespace MultinationalTourAndTravels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SliderController : ControllerBase
    {
        private readonly ISlideService slideService;

        public SliderController(ISlideService slideService)
        {
            this.slideService = slideService;
        }


        [HttpPost]
        public async Task<APIResponse<SliderResponse>> AddSlides([FromForm] SliderRequest model) =>
             await slideService.AddSlideFiles(model);


        [HttpGet("all-slides")]
        public async Task<APIResponse<IEnumerable<SliderResponse>>> GetAllSlides() =>
            await slideService.GetAllSlides();



        [AllowAnonymous]
        [HttpGet("active-slides")]
        public async Task<APIResponse<IEnumerable<SliderResponse>>> GetActiveSlides() =>
            await slideService.GetActiveSlides();




        [HttpPut("change-status")]
        public async Task<APIResponse<int>> ChangeSlideStatus(SlideStatusRequest model) =>
            await slideService.ChangeSlideStatus(model);



        [HttpDelete("{id:guid}")]
        public async Task<APIResponse<SliderResponse>> DeleteSlide(Guid id) =>
            await slideService.DeleteSlide(id);
    }
}
