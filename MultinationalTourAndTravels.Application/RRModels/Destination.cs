using MultinationalTourAndTravels.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.RRModels
{
    public record DestinationRequest(Guid PackageId,string Name,string Stay);


    public record DestinationDetailRequest(Guid DestinationId,PackageType PackageType,Guid HotelId);
}
