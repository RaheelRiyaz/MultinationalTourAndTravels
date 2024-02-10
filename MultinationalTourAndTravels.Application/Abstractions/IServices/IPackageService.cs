using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IServices
{
    public interface IPackageCostingService
    {
        Task<APIResponse<int>> AddPackage(PackageRequest model);
        Task<APIResponse<int>> UpdatePackage(UpdatePackageRequest model);
        Task<APIResponse<int>> UpdatePackageStatus(UpdateStatus model);
        Task<APIResponse<CompactPackage>> GetCompactPackageById(Guid packageId);
        Task<APIResponse<IEnumerable<DisplayingPackage>>> GetDisplayingpackages();
        Task<APIResponse<IEnumerable<AllPackageResponse>>> GetAllPackages();
        Task<APIResponse<PackageResponse>> PackageById(Guid id);
        Task<APIResponse<IEnumerable<DisplayingPackage>>> GetDisplayingPackagesPageWize(int pageNo,int total);
    }
}
