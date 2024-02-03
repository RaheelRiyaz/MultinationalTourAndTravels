using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IRepository
{
    public interface IPackageCostingRepository : IBaseRepository<PackageCosting>
    {
        Task<IEnumerable<PackageCostingDBResponse>> GetPackageCostings(Guid packageId);
    }
}
