using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultinationalTourAndTravels.Application;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;

namespace MultinationalTourAndTravels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItineraryController : ControllerBase
    {
        private readonly IItineraryService itineraryService;

        public ItineraryController(IItineraryService itineraryService)
        {
            this.itineraryService = itineraryService;
        }



        [HttpPost]
        public async Task<APIResponse<ItineraryResponse>> AddItinerary([FromForm] ItineraryRequest model) =>
            await itineraryService.AddItinerary(model);


        [HttpGet("package/{packageId:guid}")]
        public async Task<APIResponse<IEnumerable<ItineraryResponse>>> PackageItineraries(Guid packageId) =>
            await itineraryService.PackageItineraries(packageId);


        [HttpDelete("{id:guid}")]
        public async Task<APIResponse<int>> DeleteItinerary(Guid id) =>
            await itineraryService.DeleteItinerary(id);
    }
}
