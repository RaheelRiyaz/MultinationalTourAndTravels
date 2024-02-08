using AutoMapper;
using MultinationalTourAndTravels.Application.Abstractions.IRepository;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using MultinationalTourAndTravels.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Services
{
    public class HotelsService : IHotelsService
    {
        private readonly IHotelsRepository hotelsRepository;
        private readonly IFileService fileService;

        public HotelsService(IHotelsRepository hotelsRepository, IFileService fileService)
        {
            this.hotelsRepository = hotelsRepository;
            this.fileService = fileService;
        }


        public async Task<APIResponse<int>> AddHotel(HotelRequest hotel)
        {
            var newHotel = new Hotel()
            {
             Address = hotel.Address,
             Name = hotel.Name,
             Stars = hotel.Stars,
             PackageType = hotel.PackageType,
             Description = hotel.Description
            };


            if(hotel.File is not null)
                await fileService.AddFile(hotel.File, AppModule.Hotel, newHotel.Id);


            var res = await hotelsRepository.AddAsync(newHotel);

            if (res > 0)
                return APIResponse<int>.SuccessResponse("Hotel added successfully", result: res);

            return APIResponse<int>.ErrorResponse();
        }

        public async Task<APIResponse<int>> DeleteHotel(Guid id)
        {
            var hotel = await hotelsRepository.GetByIdAsync(id);

            if (hotel is null)
                return APIResponse<int>.ErrorResponse();

            var res = await hotelsRepository.DeleteAsync(hotel);

            if (res > 0)
                return APIResponse<int>.SuccessResponse("Hotel removed successfully", result: res);

            return APIResponse<int>.ErrorResponse();
        }

        public async Task<APIResponse<IEnumerable<HotelResponse>>> ViewHotels()
        {
            var hotels = await hotelsRepository.ViewHotels();

            return APIResponse<IEnumerable<HotelResponse>>.SuccessResponse(result: hotels);
        }



        public async Task<APIResponse<IEnumerable<HotelResponse>>> ViewHotelsByPackageType(PackageType packageType)
        {
            var hotels = await hotelsRepository.ViewHotelsByPackage(packageType);

            return APIResponse<IEnumerable<HotelResponse>>.SuccessResponse(result: hotels);
        }

        public async Task<APIResponse<IEnumerable<HotelResponse>>> ViewHotelsPageWize(int pageNo, int total)
        {
            var hotels = await hotelsRepository.ViewHotels();
            var res = hotels.Skip((pageNo - 1)* total).Take(total);

            return APIResponse<IEnumerable<HotelResponse>>.SuccessResponse(result: res);
        }
    }
}
