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
    public class ItineraryRepository : BaseRepository<Itinerary>, IItineraryRepository
    {
        private const string baseQuery = $@"SELECT I.Id,I.PackageId,I.[Day],I.Title,
                                            [Description],
                                            ISNULL(A.FilePath,'') AS FilePath,
                                            A.Id as FileId
                                            FROM Itineraries I
                                            LEFT JOIN AppFiles A
                                            ON A.EntityId = I.Id ";
        public ItineraryRepository(MultinationalTourAndTravelsDbContext dbContext) : base(dbContext) { }



        public async Task<IEnumerable<ItineraryResponse>> ItineariesByPackgaeId(Guid packageId)
        {
            string query = $@" {baseQuery} WHERE PackageId = @packageId
                            ORDER BY [DAY]";

            return await dbContext.QueryAsync<ItineraryResponse>(query, new { packageId });

        }
    }
}
