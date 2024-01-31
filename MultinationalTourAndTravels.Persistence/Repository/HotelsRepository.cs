using MultinationalTourAndTravels.Application.Abstractions.IRepository;
using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using MultinationalTourAndTravels.Domain.Enums;
using MultinationalTourAndTravels.Persistence.Dapper;
using MultinationalTourAndTravels.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Persistence.Repository
{
    public class HotelsRepository : BaseRepository<Hotel>, IHotelsRepository
    {
        private const string baseQuery = $@"SELECT H.Id as HotelId,A.Id as FileId,
                                            H.Name,H.[Description],H.Stars,H.[Address],
                                            A.FilePath,
                                            CASE WHEN 
                                            H.PackageType = 1 Then 'Standard'
                                            WHEN H.PackageType = 2 THEN 'Deluxe'
                                            ELSE 'Super Deluxe'
                                            END
                                            AS PackageType
                                            FROM Hotels H
                                            INNER JOIN AppFiles A ON
                                            H.Id = A.EntityId  ";


        public HotelsRepository(MultinationalTourAndTravelsDbContext dbContext) : base(dbContext) { }


        public async Task<IEnumerable<DestinationHotel>> HotelsByDestinationAndPackageType(Guid destinationId, int packageType)
        {
            string query = $@"SELECT DestinationId,HotelId,
                                H.[Address],H.[Name],H.[Description]
                                FROM DestinationDetails D INNER JOIN Hotels H
                                ON H.Id = D.HotelId
                                WHERE DestinationId = @destinationId
                                AND D.PackageType = {packageType}";

            return await dbContext.QueryAsync<DestinationHotel>(query, new { destinationId });
        }



        public async Task<IEnumerable<HotelResponse>> ViewHotels()
        {
            return await dbContext.QueryAsync<HotelResponse>(baseQuery);
        }



        public async Task<IEnumerable<HotelResponse>> ViewHotelsByPackage(PackageType packageType)
        {
            string query = $@" {baseQuery} WHERE PackageType = @packageType";

            return await dbContext.QueryAsync<HotelResponse>(query,new {packageType});
        }
    }
}
