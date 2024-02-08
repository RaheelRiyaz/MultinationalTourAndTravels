using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IServices
{
    public interface IHotelsService
    {
        Task<APIResponse<int>> AddHotel(HotelRequest hotel);

        Task<APIResponse<IEnumerable<HotelResponse>>> ViewHotels();
        Task<APIResponse<int>> DeleteHotel(Guid id);
        Task<APIResponse<IEnumerable<HotelResponse>>> ViewHotelsPageWize(int pageNo,int total);
        Task<APIResponse<IEnumerable<HotelResponse>>> ViewHotelsByPackageType(PackageType packageType);
    }
}
