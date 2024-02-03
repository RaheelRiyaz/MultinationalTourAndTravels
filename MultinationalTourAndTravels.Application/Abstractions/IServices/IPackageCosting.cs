using MultinationalTourAndTravels.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IServices
{
    public interface IPackageCosting
    {
        Task<APIResponse<int>> AddPackageCosting(PackageCostingRequest model);

        Task<APIResponse<IEnumerable<PackageCostingClientResponse>>> PackageCostings(Guid packageId);
    }
}
