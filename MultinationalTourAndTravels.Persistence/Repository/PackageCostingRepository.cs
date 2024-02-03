using MultinationalTourAndTravels.Application.Abstractions.IRepository;
using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using MultinationalTourAndTravels.Persistence.Dapper;
using MultinationalTourAndTravels.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Persistence.Repository
{
    public class PackageCostingRepository :BaseRepository<PackageCosting>, IPackageCostingRepository
    {
        public PackageCostingRepository(MultinationalTourAndTravelsDbContext dbContext) : base(dbContext) { }



        public Task<IEnumerable<PackageCostingDBResponse>> GetPackageCostings(Guid packageId)
        {
            string query = $@"SELECT Id,PackageId,
                            CASE 
                            WHEN PackageType = 1 THEN 'Standard'
                            WHEN PackageType = 2 THEN 'Deluxe'
                            WHEN PackageType = 3 THEN 'Super Deluxe'
                            END AS Package,

                            CASE 
                            WHEN PackageCostingType = 1 THEN '2PX'
                            WHEN PackageCostingType = 2 THEN '4PX'
                            WHEN PackageCostingType = 3 THEN '6PX'
                            WHEN PackageCostingType = 4 THEN '12PX'
                            END AS PackageCosting,
                            Rate
                            FROM PackageCostings
                            WHERE PackageId = @packageId
                            ORDER BY PackageType, PackageCostingType;";

            return dbContext.QueryAsync<PackageCostingDBResponse>(query, new { packageId });
        }
    }
}
