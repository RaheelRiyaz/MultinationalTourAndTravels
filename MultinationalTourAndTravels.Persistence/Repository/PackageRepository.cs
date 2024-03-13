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
    public class PackageRepository : BaseRepository<Package> ,IPackageRepository
    {
        public PackageRepository(MultinationalTourAndTravelsDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<PackageResponse>> GetHomePackages()
        {
            string query = $@"SELECT Id,
                                [Name],[Description],
                                [Days],Nights,StartingPrice,
                                Longitude,Latitude
                                FROM Packages
                                WHERE IsActive = 1
                                ORDER BY CreatedOn DESC ";

            return await dbContext.QueryAsync<PackageResponse>(query);
        }


        public async Task<IEnumerable<PackageFile>> GetPackagesFiles(Guid packageId)
        {
            string query = $@"SELECT Id,FilePath FROM AppFiles
                                WHERE EntityId = @packageId";

            return await dbContext.QueryAsync<PackageFile>(query, new { packageId });
        }
    }
}
