using MultinationalTourAndTravels.Application;
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
    public class BookingRepository : BaseRepository<Booking> , IBookingRepository
    {
        public BookingRepository(MultinationalTourAndTravelsDbContext dbContext): base(dbContext) { }




        public async Task<IEnumerable<BookingWithPackageName>> GetAllBookings()
        {
            string query = $@"SELECT B.Id as BookingId,
                            B.[Name] as Customer,
                            B.Contact,B.Email,
                            B.NoOfAdults,B.NoOfChildrens,
                            B.IsVerified,P.[Name] as Package,
                            B.TravelDate
                            FROM BOOKINGS B
                            INNER JOIN Packages P
                            ON P.Id = B.PackageId
                            ORDER BY IsVerified,B.CreatedOn DESC";

            return await dbContext.QueryAsync<BookingWithPackageName>(query);
        }
    }
}
