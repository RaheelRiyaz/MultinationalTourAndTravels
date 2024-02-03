using MultinationalTourAndTravels.Application.Abstractions.IRepository;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using MultinationalTourAndTravels.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Services
{
    public class CabService : ICabService
    {
        private readonly ICabRepository cabRepository;
        private readonly IFileService fileService;

        public CabService(ICabRepository cabRepository ,IFileService fileService)
        {
            this.cabRepository = cabRepository;
            this.fileService = fileService;
        }


        public async Task<APIResponse<int>> AddNewCab(CabRequest model)
        {
            var cab = new Cab()
            {
                CabType = model.CabType,
                Description = model.Description,
                Name = model.Name,
                Price = model.Price,
            };


            if(model.File is not null)
            {
                await fileService.AddFile(model.File, AppModule.Cabs, cab.Id);
            }

            var res = await cabRepository.AddAsync(cab);

            if (res > 0)
                return APIResponse<int>.SuccessResponse("Cab added successfully",result: res);

            return APIResponse<int>.ErrorResponse();
        }

        public async Task<APIResponse<int>> DeleteCab(Guid cabId)
        {
            //var cab = await cabRepository.GetAllAsyn
            var res = await cabRepository.DeleteAsync(cabId);

            if (res > 0)
                return APIResponse<int>.SuccessResponse("Cab deeleted successfully", result: res);

            return APIResponse<int>.ErrorResponse();
        }

        public async Task<APIResponse<IEnumerable<CabResponse>>> GetAllCabs()
        {
            var cabs = await cabRepository.GetAllCabs();

            return APIResponse<IEnumerable<CabResponse>>.SuccessResponse(result: cabs);
        }
    }
}
