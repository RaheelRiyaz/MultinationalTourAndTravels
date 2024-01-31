using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IServices
{
    public interface IInclusionsService
    {
        Task<APIResponse<InclusionRequest>> AddInclusion(InclusionRequest model);
        Task<APIResponse<ExclusionRequest>> AddExclusion(ExclusionRequest model);
        Task<APIResponse<Exlusion>> UpdateExclusion(InclusionExclusionUpdateRequest model);
        Task<APIResponse<Inclusion>> UpdateInclusion(InclusionExclusionUpdateRequest model);
        Task<APIResponse<int>> DeleteExclusion(Guid id);
        Task<APIResponse<int>> DeleteInclusion(Guid id);
        Task<APIResponse<IEnumerable<InclusionOrExclusionResponse>>> ViewInclusions(Guid packageId);
        Task<APIResponse<IEnumerable<InclusionOrExclusionResponse>>> ViewExclusions(Guid packageId);

        Task<APIResponse<Inclusion>> GetInclusionById(Guid id);
        Task<APIResponse<Exlusion>> GetExclusionById(Guid id);
    }
}
