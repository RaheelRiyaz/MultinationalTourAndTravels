using MultinationalTourAndTravels.Application.RRModels;
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

        Task<APIResponse<CompactPackage>> GetCompactPackageById(Guid packageId);

        Task<APIResponse<IEnumerable<DisplayingPackage>>> GetDisplayingpackages();
        Task<APIResponse<IEnumerable<DisplayingPackage>>> GetDisplayingPackagesPageWize(int pageNo,int total);
    }
}
