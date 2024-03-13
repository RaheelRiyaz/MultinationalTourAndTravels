using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultinationalTourAndTravels.Application;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;

namespace MultinationalTourAndTravels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageDestinationController : ControllerBase
    {
        private readonly IPackageDestinationService packageDestinationService;

        public PackageDestinationController(IPackageDestinationService packageDestinationService)
        {
            this.packageDestinationService = packageDestinationService;
        }



        [HttpPost]
        public async Task<APIResponse<DestinationRequest>> AddDestination(DestinationRequest model) =>
            await packageDestinationService.AddDestination(model);



        [HttpPost("details")]
        public async Task<APIResponse<DestinationDetailRequest>> AddDestinationDetails(DestinationDetailRequest model) =>
           await packageDestinationService.AddDestinationDetails(model);
    }
}
