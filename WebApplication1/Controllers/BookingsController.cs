using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultinationalTourAndTravels.Application;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;

namespace MultinationalTourAndTravels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public BookingsController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }


        [HttpGet]
        public async Task<APIResponse<IEnumerable<BookingResponse>>> ViewBookings() =>
            await bookingService.ViewBookings();



        [HttpPost]
        public async Task<APIResponse<BookingResponse>> AddBookings(BookingRequest model) =>
            await bookingService.AddBookings(model);


        [HttpPut("status")]
        public async Task<APIResponse<int>> UpdateBookingStatus(UpdateBooking model) =>
            await bookingService.UpdateBookingStatus(model);

    }
}
