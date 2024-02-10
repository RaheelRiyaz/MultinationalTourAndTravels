using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IRepository
{
    public interface IPackageRepository : IBaseRepository<Package>
    {
        Task<IEnumerable<PackageResponse>> GetHomePackages();
        Task<PackageResponse?> PackageById(Guid id);
        Task<IEnumerable<PackageFile>> GetPackagesFiles(Guid packageId);
    }
}
