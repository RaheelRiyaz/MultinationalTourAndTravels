using Microsoft.AspNetCore.Authorization;
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
    public class InclusionExclusionsController : ControllerBase
    {
        private readonly IInclusionsService service;

        public InclusionExclusionsController(IInclusionsService service)
        {
            this.service = service;
        }


        [HttpPost("/api/inclusion")]
        public async Task<APIResponse<InclusionRequest>> AddInclusion(InclusionRequest model) =>
            await service.AddInclusion(model);


        [HttpPost("/api/exclusion")]
        public async Task<APIResponse<ExclusionRequest>> AddExclusion(ExclusionRequest model) =>
           await service.AddExclusion(model);



        [AllowAnonymous]
        [HttpGet("/api/inclusions/{packageId:guid}")]
        public async Task<APIResponse<IEnumerable<InclusionOrExclusionResponse>>> ViewIncclusions(Guid packageId)=>
            await service.ViewInclusions(packageId);



        [AllowAnonymous]
        [HttpGet("/api/exclusions/{packageId:guid}")]
        public async Task<APIResponse<IEnumerable<InclusionOrExclusionResponse>>> ViewExclusions(Guid packageId) =>
            await service.ViewExclusions(packageId);


        [HttpDelete("/api/inclusion/{id:guid}")]
        public async Task<APIResponse<int>> DeleteInclusion(Guid id) =>
            await service.DeleteInclusion(id);


        [HttpDelete("/api/exclusion/{id:guid}")]
        public async Task<APIResponse<int>> DeleteExclusion(Guid id) =>
           await service.DeleteExclusion(id);


        [HttpPut("/api/inclusion")]
        public async Task<APIResponse<Inclusion>> UpdateInclusion(InclusionExclusionUpdateRequest model)=>
            await service.UpdateInclusion(model);


        [HttpPut("/api/exclusion")]
        public async Task<APIResponse<Exlusion>> UpdateExclusion(InclusionExclusionUpdateRequest model) =>
            await service.UpdateExclusion(model);


        [HttpGet("/api/inclusion/{id:guid}")]
        public async Task<APIResponse<Inclusion>> GetInclusionById(Guid id) =>
            await service.GetInclusionById(id);


        [HttpGet("/api/exclusion/{id:guid}")]
        public async Task<APIResponse<Exlusion>> GetExclusionById(Guid id) =>
          await service.GetExclusionById(id);
    }
}
