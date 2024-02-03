using MultinationalTourAndTravels.Application.Abstractions.IRepository;
using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using MultinationalTourAndTravels.Persistence.Dapper;
using MultinationalTourAndTravels.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Persistence.Repository
{
    public class CabRepository : BaseRepository<Cab> , ICabRepository
    {
        private const string baseQuery = $@"SELECT C.Id as CabId,
                                            [Name],[Description],Price,
                                            A.Id as FileId,ISNULL(A.FilePath,'') as FilePath,
                                            CASE 
                                            WHEN CabType = 1 THEN 'AC'
                                            WHEN CabType = 2 THEN 'Non-AC'
                                            ELSE 'Not mentioned'
                                            END AS
                                            CabType
                                            FROM CABS C
                                            LEFT JOIN AppFiles A
                                            ON C.Id = A.EntityId ";
        public CabRepository(MultinationalTourAndTravelsDbContext  dbContext) : base(dbContext) { }

        public async Task<int> DeleteCab(Guid cabId)
        {
            return await dbContext.ExecuteAsync("SpDeleteCabs",new {cabId},commandType:CommandType.StoredProcedure);
        }

        public Task<IEnumerable<CabResponse>> GetAllCabs()
        {
            string query = $@"{baseQuery} ORDER BY C.CreatedOn";

            return dbContext.QueryAsync<CabResponse>(query);
        }
    }
}
