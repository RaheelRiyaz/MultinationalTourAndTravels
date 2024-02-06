using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IServices
{
    public interface ILinkTreeService 
    {
        Task<APIResponse<int>> AddLinkTrees(LinkTreeRequest model);
        Task<APIResponse<int>> UpdateLinkTrees(LinkTree model);
        Task<APIResponse<LinkTree>> GetLinks();
    }
}
