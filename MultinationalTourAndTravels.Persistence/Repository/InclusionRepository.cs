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
    public class InclusionRepository : BaseRepository<Inclusion> ,IInclusionsRepository
    {
        public InclusionRepository(MultinationalTourAndTravelsDbContext dbContext) : base(dbContext) { }



        public async Task<IEnumerable<InclusionOrExclusionResponse>> ViewInclusions(Guid packageId)
        {
            string query = $@"SELECT Id,PackageId,[Description]
                                FROM Inclusions 
                                WHERE PackageId = @packageId";

            return await dbContext.QueryAsync<InclusionOrExclusionResponse>(query, new { packageId });
        }
    }
}
