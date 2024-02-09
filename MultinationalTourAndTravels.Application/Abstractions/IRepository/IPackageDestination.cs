using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IRepository
{
    public interface IPackageDestination : IBaseRepository<PackageDestination>
    {
        Task<IEnumerable<DestinationName>> GetDestinationNamesByPackage(Guid packageId);
        Task<IEnumerable<PackageDestination>> PackageDestinations(Guid id);
    }
}
