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
    public class PackageDestinationRepository : BaseRepository<PackageDestination>, IPackageDestination
    {
        public PackageDestinationRepository(MultinationalTourAndTravelsDbContext dbContext) : base(dbContext) { }



        public async Task<IEnumerable<DestinationName>> GetDestinationNamesByPackage(Guid packageId)
        {
            string query = $@"SELECT[Name],[Id]
                              FROM PackageDestinations
                              WHERE PackageId = @packageId";

            return await dbContext.QueryAsync<DestinationName>(query, new { packageId });
        }

        public async Task<IEnumerable<PackageDestination>> PackageDestinations(Guid id)
        {
            string query = $@"SELECT * FROM PackageDestinations  
                            WHERE PackageId = @id";

            return await dbContext.QueryAsync<PackageDestination>(query, new { id });
        }
    }
}
