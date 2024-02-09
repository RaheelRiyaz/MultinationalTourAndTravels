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
    public class LinkTreesController : ControllerBase
    {
        private readonly ILinkTreeService linkTreeService;

        public LinkTreesController(ILinkTreeService linkTreeService)
        {
            this.linkTreeService = linkTreeService;
        }

        [HttpPost]
        public async Task<APIResponse<int>> AddLinks(LinkTreeRequest model) =>
            await linkTreeService.AddLinkTrees(model);



        [HttpGet]
        [AllowAnonymous]
        public async Task<APIResponse<LinkTree>> GetLinks() =>
            await linkTreeService.GetLinks();

        [HttpPut]
        public async Task<APIResponse<int>> UpdateLinkTrees(LinkTree model) =>
            await linkTreeService.UpdateLinkTrees(model);
    }
}
