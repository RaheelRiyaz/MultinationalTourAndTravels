using AutoMapper;
using MultinationalTourAndTravels.Application.Abstractions.IRepository;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IMapper mapper;

        public BookingService(IBookingRepository bookingRepository ,IMapper mapper)
        {
            this.bookingRepository = bookingRepository;
            this.mapper = mapper;
        }


        public async Task<APIResponse<BookingResponse>> AddBookings(BookingRequest model)
        {
            if (model.TravelDate <= DateTime.Now)
                return APIResponse<BookingResponse>.ErrorResponse("Please select date other than today");


            var booking = mapper.Map<Booking>(model);

            var res = await bookingRepository.AddAsync(booking);

            if (res > 0)
                return APIResponse<BookingResponse>.SuccessResponse("Enquiry has been sent we will contact you very soon");


            return APIResponse<BookingResponse>.ErrorResponse();
        }



        public async Task<APIResponse<int>> UpdateBookingStatus(UpdateBooking model)
        {
            var booking = await bookingRepository.GetByIdAsync(model.Id);

            if (booking is null)
                return APIResponse<int>.ErrorResponse();

            booking.IsVerified = model.IsVerified;

            var res = await bookingRepository.UpdateAsync(booking);

            if (res > 0)
                return APIResponse<int>.SuccessResponse("Booking status has been updated", result:res);


            return APIResponse<int>.ErrorResponse();
        }

        public Task<APIResponse<BookingResponse>> ViewBookingById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<IEnumerable<BookingResponse>>> ViewBookings()
        {
            var bookings = await bookingRepository.GetAllAsync();

            var response = mapper.Map<IEnumerable<BookingResponse>>(bookings);


            return APIResponse<IEnumerable<BookingResponse>>.SuccessResponse(result: response);
        }
    }

}
