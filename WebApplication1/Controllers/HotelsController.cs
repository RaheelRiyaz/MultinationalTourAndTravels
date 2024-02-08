using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultinationalTourAndTravels.Application;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Enums;

namespace MultinationalTourAndTravels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelsService hotelsService;

        public HotelsController(IHotelsService hotelsService)
        {
            this.hotelsService = hotelsService;
        }


        [HttpPost]
        public async Task<APIResponse<int>> AddHotel([FromForm] HotelRequest model) =>
            await hotelsService.AddHotel(model);



        [HttpGet]
        public async Task<APIResponse<IEnumerable<HotelResponse>>> ViewHotels() =>
            await hotelsService.ViewHotels();



        [HttpGet("packageType/{packageType:int}")]
        public async Task<APIResponse<IEnumerable<HotelResponse>>> ViewHotels(PackageType packageType) =>
            await hotelsService.ViewHotelsByPackageType(packageType);


        [HttpGet("hotels-pagewize/{pageNo:int}/{total:int}")]
        public async Task<APIResponse<IEnumerable<HotelResponse>>> ViewHotelsPageWize(int pageNo, int total) =>
            await hotelsService.ViewHotelsPageWize(pageNo, total);



        [HttpDelete("{id:guid}")]
        public async Task<APIResponse<HotelResponse>> DeleteHotel(Guid id) =>
            await hotelsService.DeleteHotel(id);
    }
}
