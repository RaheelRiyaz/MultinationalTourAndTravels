using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultinationalTourAndTravels.Application;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;

namespace MultinationalTourAndTravels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public BookingsController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }


        [HttpGet]
        public async Task<APIResponse<IEnumerable<BookingWithPackageName>>> ViewBookings() =>
            await bookingService.ViewBookings();



        [AllowAnonymous]
        [HttpPost]
        public async Task<APIResponse<BookingResponse>> AddBookings(BookingRequest model) =>
            await bookingService.AddBookings(model);


        [HttpPut("status")]
        public async Task<APIResponse<int>> UpdateBookingStatus(UpdateBooking model) =>
            await bookingService.UpdateBookingStatus(model);


        [HttpDelete("{id:guid}")]
        public async Task<APIResponse<int>> DeleteBookingById(Guid id) =>
            await bookingService.DeleteBookingById(id);

    }
}
