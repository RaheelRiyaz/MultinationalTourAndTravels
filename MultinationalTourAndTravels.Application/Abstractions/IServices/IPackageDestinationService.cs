using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IServices
{
    public interface IPackageDestinationService
    {
        Task<APIResponse<DestinationRequest>> AddDestination(DestinationRequest model);
        Task<APIResponse<DestinationDetailRequest>> AddDestinationDetails(DestinationDetailRequest model);
        Task<APIResponse<IEnumerable<PackageDestination>>> PackageDestinations(Guid id);
        Task<APIResponse<int>> DeletePackageDestination(Guid id);
    }
}
