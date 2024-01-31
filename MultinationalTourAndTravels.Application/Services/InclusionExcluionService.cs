using MultinationalTourAndTravels.Application.Abstractions.IRepository;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Services
{
    public class InclusionExcluionService : IInclusionsService
    {
        private readonly IInclusionsRepository inclusionsRepository;
        private readonly IExclusionsRepository exclusionsRepository;

        public InclusionExcluionService(IInclusionsRepository inclusionsRepository ,IExclusionsRepository exclusionsRepository)
        {
            this.inclusionsRepository = inclusionsRepository;
            this.exclusionsRepository = exclusionsRepository;
        }


        public async Task<APIResponse<InclusionRequest>> AddInclusion(InclusionRequest model)
        {
            var inclusion = new Inclusion()
            {
                Description = model.Description,
                PackageId = model.PackageId
            };

            var res = await inclusionsRepository.AddAsync(inclusion);
            if (res > 0)
                return APIResponse<InclusionRequest>.SuccessResponse(result: model);

            return APIResponse<InclusionRequest>.ErrorResponse();
        }



        public async Task<APIResponse<ExclusionRequest>> AddExclusion(ExclusionRequest model)
        {
            var exclusion = new Exlusion()
            {
                Description = model.Description,
                PackageId = model.PackageId
            };

            var res = await exclusionsRepository.AddAsync(exclusion);
            if (res > 0)
                return APIResponse<ExclusionRequest>.SuccessResponse(result: model);

            return APIResponse<ExclusionRequest>.ErrorResponse();
        }



        public async Task<APIResponse<IEnumerable<InclusionOrExclusionResponse>>> ViewInclusions(Guid packageId)
        {
            var inclusions = await inclusionsRepository.ViewInclusions(packageId);

            return APIResponse<IEnumerable<InclusionOrExclusionResponse>>.SuccessResponse(result: inclusions);
        }



        public async Task<APIResponse<IEnumerable<InclusionOrExclusionResponse>>> ViewExclusions(Guid packageId)
        {
            var exclusions = await exclusionsRepository.ViewExclusions(packageId);

            return APIResponse<IEnumerable<InclusionOrExclusionResponse>>.SuccessResponse(result: exclusions);
        }



        public async Task<APIResponse<int>> DeleteExclusion(Guid id)
        {
            var res = await exclusionsRepository.DeleteAsync(id);

            if (res > 0)
                return APIResponse<int>.SuccessResponse("Inclusion removed for this package",result:res);


            return APIResponse<int>.ErrorResponse();
        }



        public async Task<APIResponse<int>> DeleteInclusion(Guid id)
        {
            var res = await inclusionsRepository.DeleteAsync(id);

            if (res > 0)
                return APIResponse<int>.SuccessResponse("Exclusion removed for this package",result:res);


            return APIResponse<int>.ErrorResponse();
        }


        public async Task<APIResponse<Exlusion>> UpdateExclusion(InclusionExclusionUpdateRequest model)
        {
            var exclusion = await exclusionsRepository.GetByIdAsync(model.Id);

            if (exclusion is null)
                return APIResponse<Exlusion>.ErrorResponse();

            exclusion.Description = model.Description;
            exclusion.UpdatedOn = DateTime.Now;

            var res = await exclusionsRepository.UpdateAsync(exclusion);

            if (res > 0)
                return APIResponse<Exlusion>.SuccessResponse("Exclusion Updated successfully", result: exclusion);

            return APIResponse<Exlusion>.ErrorResponse();
        }


        public async Task<APIResponse<Inclusion>> UpdateInclusion(InclusionExclusionUpdateRequest model)
        {
            var inclusion = await inclusionsRepository.GetByIdAsync(model.Id);

            if (inclusion is null)
                return APIResponse<Inclusion>.ErrorResponse();

            inclusion.Description = model.Description;
            inclusion.UpdatedOn = DateTime.Now;

            var res = await inclusionsRepository.UpdateAsync(inclusion);

            if (res > 0)
                return APIResponse<Inclusion>.SuccessResponse("Exclusion Updated successfully", result: inclusion);

            return APIResponse<Inclusion>.ErrorResponse();
        }



        public async Task<APIResponse<Inclusion>> GetInclusionById(Guid id)
        {
            var inclusion = await inclusionsRepository.GetByIdAsync(id);
            if (inclusion is null)
                return APIResponse<Inclusion>.ErrorResponse();

            return APIResponse<Inclusion>.SuccessResponse(result: inclusion);
        }



        public async Task<APIResponse<Exlusion>> GetExclusionById(Guid id)
        {
            var exclusion = await exclusionsRepository.GetByIdAsync(id);
            if (exclusion is null)
                return APIResponse<Exlusion>.ErrorResponse();

            return APIResponse<Exlusion>.SuccessResponse(result: exclusion);
        }
    }
}
