using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.RRModels
{
      public record BookingRequest
        (Guid PackageId,
        string Name, 
        string Email, 
        string Contact,
        int NoOfAdults, 
        int NoOfChildrens,
        DateTime TravelDate
        );


       public record BookingResponse
         (
        Guid PackageId,
        Guid Id,
         string Name,
        string Email,
        string Contact,
        int NoOfAdults,
        int NoOfChildrens,
        DateTime TravelDate,
        bool IsVerified
        );

      public record UpdateBooking
        (
        Guid Id,
        bool IsVerified
        );
}
