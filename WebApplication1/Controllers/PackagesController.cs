﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultinationalTourAndTravels.Application;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;

namespace MultinationalTourAndTravels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PackagesController : ControllerBase
    {
        private readonly IPackageCostingService packageService;

        public PackagesController(IPackageCostingService packageService)
        {
            this.packageService = packageService;
        }


        [HttpPost]
        public async Task<APIResponse<int>> AddPackage([FromForm] PackageRequest model) =>
            await packageService.AddPackage(model);



        [AllowAnonymous]
        [HttpGet("compactPackage/{packageId:guid}")]
        public async Task<APIResponse<CompactPackage>> GetCompactPackageById(Guid packageId) =>
            await packageService.GetCompactPackageById(packageId);


        [AllowAnonymous]
        [HttpGet("display-packages")]
        public async Task<APIResponse<IEnumerable<DisplayingPackage>>> GetDisplayingpackages() =>
            await packageService.GetDisplayingpackages();



        [AllowAnonymous]
        [HttpGet("display-packages/pagewize/{pageNo:int}/{total:int}")]
        public async Task<APIResponse<IEnumerable<DisplayingPackage>>> GetDisplayingPackagesPageWize(int pageNo, int total) =>
            await packageService.GetDisplayingPackagesPageWize(pageNo, total);



        [AllowAnonymous]
        [HttpGet("all-packages")]
        public async Task<APIResponse<IEnumerable<AllPackageResponse>>> GetAllPackages() =>
            await packageService.GetAllPackages();


        [HttpPut("status")]
        public async Task<APIResponse<int>> UpdatePackageStatus(UpdateStatus model) =>
            await packageService.UpdatePackageStatus(model);



        [HttpPut]
        public async Task<APIResponse<int>> UpdatePackage(UpdatePackageRequest model) =>
            await packageService.UpdatePackage(model);


        [HttpGet("{id:guid}")]
        public async Task<APIResponse<PackageResponse>> PackageById(Guid id) =>
            await packageService.PackageById(id);
    }
}
