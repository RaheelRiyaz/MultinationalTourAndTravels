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
    public class PackageDestinationService : IPackageDestinationService
    {
        private readonly IPackageDestination packageDestination;
        private readonly IDestinationDetailsRepository destinationDetailsRepository;

        public PackageDestinationService(IPackageDestination packageDestination,IDestinationDetailsRepository destinationDetailsRepository)
        {
            this.packageDestination = packageDestination;
            this.destinationDetailsRepository = destinationDetailsRepository;
        }


        public async Task<APIResponse<DestinationRequest>> AddDestination(DestinationRequest model)
        {
            var destination = new PackageDestination() { PackageId = model.PackageId ,Name = model.Name, Stay = model.Stay};

            var res = await packageDestination.AddAsync(destination);

            if (res > 0)
                return APIResponse<DestinationRequest>.SuccessResponse("Destination added successfully", result: model);

            return APIResponse<DestinationRequest>.ErrorResponse();
        }



        public async Task<APIResponse<DestinationDetailRequest>> AddDestinationDetails(DestinationDetailRequest model)
        {
            var destinationDetails = new DestinationDetails() { HotelId = model.HotelId , DestinationId = model.DestinationId , PackageType = model.PackageType};

            var res = await destinationDetailsRepository.AddAsync(destinationDetails);

            if(res > 0)
                return APIResponse<DestinationDetailRequest>.SuccessResponse("Destination details added",result: model);

            return APIResponse<DestinationDetailRequest>.ErrorResponse(); 
        }
    }
}
