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




        public async Task<IEnumerable<BookingResponse>> GetAllBookings()
        {
            string query = $@"SELECT PackageId,Id,[Name],
                            Email,Contact,NoOfAdults,
                            NoOfChildrens,TravelDate,
                            IsVerified
                            FROM Bookings
                            ORDER BY IsVerified,CreatedOn DESC";

            return await dbContext.QueryAsync<BookingResponse>(query);
        }
    }
}
