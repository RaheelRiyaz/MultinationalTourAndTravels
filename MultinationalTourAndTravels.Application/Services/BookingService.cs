using AutoMapper;
using MultinationalTourAndTravels.Application.Abstractions.EmailService;
using MultinationalTourAndTravels.Application.Abstractions.IRepository;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using MultinationalTourAndTravels.Infrastructure.Model;
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
        private readonly IEmailTemplateRenderer emailTemplateRenderer;
        private readonly IEmailService emailService;

        public BookingService(IBookingRepository bookingRepository ,IMapper mapper, IEmailTemplateRenderer emailTemplateRenderer,IEmailService emailService)
        {
            this.bookingRepository = bookingRepository;
            this.mapper = mapper;
            this.emailTemplateRenderer = emailTemplateRenderer;
            this.emailService = emailService;
        }


        public async Task<APIResponse<BookingResponse>> AddBookings(BookingRequest model)
        {
            if (model.TravelDate <= DateTime.Now)
                return APIResponse<BookingResponse>.ErrorResponse("Please select date other than today");


            var booking = mapper.Map<Booking>(model);

            var settings = new MailSettings()
            {
                Body = await emailTemplateRenderer.EmailTemplate("BookingTemplate.cshtml", booking),
                Subject = "Booking",
                To = new List<string>() { "multinationaltravellers@gmail.com" },
            };


            await emailService.SendEmailAsync(settings); 




            var res = await bookingRepository.AddAsync(booking);

            if (res > 0)
                return APIResponse<BookingResponse>.SuccessResponse("Enquiry has been sent we will contact you very soon");


            return APIResponse<BookingResponse>.ErrorResponse();
        }


        public async Task<APIResponse<int>> DeleteBookingById(Guid id)
        {
            var res = await bookingRepository.DeleteAsync(id);

            if (res > 0)
                return APIResponse<int>.SuccessResponse("Booking removed successfully", result: res);

            return APIResponse<int>.ErrorResponse();
        }


        public async Task<APIResponse<int>> UpdateBookingStatus(UpdateBooking model)
        {
            var booking = await bookingRepository.GetByIdAsync(model.Id);

            if (booking is null)
                return APIResponse<int>.ErrorResponse();

            booking.IsVerified = !booking.IsVerified;
            booking.UpdatedOn = DateTime.Now;


            var res = await bookingRepository.UpdateAsync(booking);

            if (res > 0)
                return APIResponse<int>.SuccessResponse("Booking status has been updated", result:res);


            return APIResponse<int>.ErrorResponse();
        }

        public Task<APIResponse<BookingResponse>> ViewBookingById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<IEnumerable<BookingWithPackageName>>> ViewBookings()
        {
            var bookings = await bookingRepository.GetAllBookings();

            return APIResponse<IEnumerable<BookingWithPackageName>>.SuccessResponse(result: bookings);
        }
    }

}
