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
    public class ExclusionsRepository : BaseRepository<Exlusion> ,IExclusionsRepository
    {
        public ExclusionsRepository(MultinationalTourAndTravelsDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<InclusionOrExclusionResponse>> ViewExclusions(Guid packageId)
        {
            string query = $@"SELECT Id,PackageId,[Description]
                                FROM Exlusions 
                                WHERE PackageId = @packageId";

            return await dbContext.QueryAsync<InclusionOrExclusionResponse>(query, new { packageId });
        }
    }
}
