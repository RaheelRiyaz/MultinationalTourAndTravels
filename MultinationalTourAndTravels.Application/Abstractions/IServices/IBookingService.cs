using MultinationalTourAndTravels.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IServices
{
    public interface IBookingService
    {
        Task<APIResponse<IEnumerable<BookingResponse>>> ViewBookings();
        Task<APIResponse<BookingResponse>> ViewBookingById(Guid id);
        Task<APIResponse<int>> UpdateBookingStatus(UpdateBooking model);

        Task<APIResponse<BookingResponse>> AddBookings(BookingRequest model);
    }
}
