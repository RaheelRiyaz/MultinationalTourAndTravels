﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultinationalTourAndTravels.Application;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;

namespace MultinationalTourAndTravels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly IPackageService packageService;

        public PackagesController(IPackageService packageService)
        {
            this.packageService = packageService;
        }


        [HttpPost]
        public async Task<APIResponse<int>> AddPackage([FromForm] PackageRequest model) =>
            await packageService.AddPackage(model);



        [HttpGet("compactPackage/{packageId:guid}")]
        public async Task<APIResponse<CompactPackage>> GetCompactPackageById(Guid packageId) =>
            await packageService.GetCompactPackageById(packageId);



        [HttpGet("display-packages")]
        public async Task<APIResponse<IEnumerable<DisplayingPackage>>> GetDisplayingpackages() =>
            await packageService.GetDisplayingpackages();



        [HttpGet("display-packages/pagewize/{pageNo:int}/{total:int}")]
        public async Task<APIResponse<IEnumerable<DisplayingPackage>>> GetDisplayingPackagesPageWize(int pageNo, int total) =>
            await packageService.GetDisplayingPackagesPageWize(pageNo, total);
    }
}
