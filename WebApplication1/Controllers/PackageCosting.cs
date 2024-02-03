using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultinationalTourAndTravels.Application;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;

namespace MultinationalTourAndTravels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageCosting : ControllerBase
    {
        private readonly IPackageCosting packageService;

        public PackageCosting(IPackageCosting packageService)
        {
            this.packageService = packageService;
        }


        [HttpPost]
        public async Task<APIResponse<int>> AddPackageCosting(PackageCostingRequest model) =>
            await packageService.AddPackageCosting(model);



        [HttpGet("{packageId:guid}")]
        public async Task<APIResponse<IEnumerable<PackageCostingClientResponse>>> PackageCostings(Guid packageId) =>
            await packageService.PackageCostings(packageId);
    }
}
