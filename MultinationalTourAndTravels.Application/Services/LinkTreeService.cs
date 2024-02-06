using MultinationalTourAndTravels.Application.Abstractions.IRepository;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Services
{
    public class LinkTreeService : ILinkTreeService
    {
        private readonly ILinkTreeRepository linkTreeRepository;

        public LinkTreeService(ILinkTreeRepository linkTreeRepository)
        {
            this.linkTreeRepository = linkTreeRepository;
        }
        public async Task<APIResponse<int>> AddLinkTrees(LinkTreeRequest model)
        {
            var linkTree = new LinkTree()
            {
                Facebbook = model.Facebook,
                Google = model.Google,
                Instagram = model.Instagram,
                Twitter = model.Twitter,
                Youtube = model.youtube,
                Whatsapp = model.Whatsapp
            };


            var res = await linkTreeRepository.AddAsync(linkTree);

            if (res > 0)
                return APIResponse<int>.SuccessResponse("Links added", result:res);

            return APIResponse<int>.ErrorResponse();
        }



        public async Task<APIResponse<LinkTree>> GetLinks()
        {
            var links = (await linkTreeRepository.GetAllAsync()).FirstOrDefault();

            if (links is not null)
                return APIResponse<LinkTree>.SuccessResponse(result: links);

            return APIResponse<LinkTree>.ErrorResponse();
        }

        public async Task<APIResponse<int>> UpdateLinkTrees(LinkTree model)
        {
            var linktree = await linkTreeRepository.GetByIdAsync(model.Id);

            if (linktree is null)
                return APIResponse<int>.ErrorResponse();

            linktree.Youtube = model.Youtube;
            linktree.Instagram = model.Instagram;
            linktree.Facebbook = model.Facebbook;
            linktree.Twitter = model.Twitter;
            linktree.Whatsapp = model.Whatsapp;
            linktree.Google = model.Google;
            linktree.UpdatedOn = DateTime.Now;

            var res = await linkTreeRepository.UpdateAsync(linktree);

            if (res > 0)
                return APIResponse<int>.SuccessResponse("Links updated succssfully", result: res);

            return APIResponse<int>.ErrorResponse();
        }
    }
}
