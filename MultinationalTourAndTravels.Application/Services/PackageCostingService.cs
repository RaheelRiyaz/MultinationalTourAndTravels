using AutoMapper;
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
    public class PackageCostingService : IPackageCosting
    {
        private readonly IPackageCostingRepository packageCostingRepository;
        private readonly IMapper mapper;

        public PackageCostingService(IPackageCostingRepository packageCostingRepository,IMapper mapper)
        {
            this.packageCostingRepository = packageCostingRepository;
            this.mapper = mapper;
        }


        public async Task<APIResponse<int>> AddPackageCosting(PackageCostingRequest model)
        {
            var packageCosting = mapper.Map<PackageCosting>(model);

            var res = await packageCostingRepository.AddAsync(packageCosting);

            if (res > 0)
                return APIResponse<int>.SuccessResponse(message: "Costing added", result: res);


            return APIResponse<int>.ErrorResponse();
        }

        public async Task<APIResponse<IEnumerable<PackageCostingClientResponse>>> PackageCostings(Guid packageId)
        {
          var costings = (await packageCostingRepository.GetPackageCostings(packageId));

            var standard = costings.Where(_ => _.Package.ToLower() == "standard");
            var deluxe = costings.Where(_ => _.Package.ToLower() == "deluxe");
            var superDeluxe = costings.Where(_ => _.Package.ToLower() == "super deluxe");


            var standardCostings = new PackageCostingClientResponse()
            {
                Package = "Standard",
                PackageCostings = standard
            };

            var deluxeCostings = new PackageCostingClientResponse()
            {
                Package = "Deluxe",
                PackageCostings = deluxe
            };
            var superDeluxeCostings = new PackageCostingClientResponse()
            {
                Package = "Super Dulexe",
                PackageCostings = superDeluxe
            };

            List<PackageCostingClientResponse> response = new List<PackageCostingClientResponse>() { standardCostings,deluxeCostings,superDeluxeCostings};

            return APIResponse<IEnumerable<PackageCostingClientResponse>>.SuccessResponse(result: response);
        }
    }
}
