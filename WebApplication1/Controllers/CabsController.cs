using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultinationalTourAndTravels.Application;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;

namespace MultinationalTourAndTravels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabsController : ControllerBase
    {
        private readonly ICabService cabService;

        public CabsController(ICabService cabService)
        {
            this.cabService = cabService;
        }

        [HttpPost]
        public async Task<APIResponse<int>> AddNewCab([FromForm] CabRequest model) =>
            await cabService.AddNewCab(model);

        [HttpGet("all-cabs")]
        public async Task<APIResponse<IEnumerable<CabResponse>>> GetAllCabs() =>
            await cabService.GetAllCabs();



        [HttpDelete(("{cabId:guid}"))]
        public async Task<APIResponse<int>> DeleteCab(Guid cabId) =>
            await cabService.DeleteCab(cabId);
    }
}
