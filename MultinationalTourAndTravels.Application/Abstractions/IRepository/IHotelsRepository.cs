using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using MultinationalTourAndTravels.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IRepository
{
    public interface IHotelsRepository : IBaseRepository<Hotel>
    {
        Task<IEnumerable<HotelResponse>> ViewHotels();
        Task<IEnumerable<HotelResponse>> ViewHotelsByPackage(PackageType packageType);

        Task<IEnumerable<DestinationHotel>> HotelsByDestinationAndPackageType(Guid destinationId, int packageType);
    }
}
