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
    public class ItineraryService : IItineraryService
    {
        private readonly IItineraryRepository itineraryRepository;
        private readonly IMapper mapper;
        private readonly IFileService fileService;

        public ItineraryService(IItineraryRepository itineraryRepository,IMapper mapper,IFileService fileService)
        {
            this.itineraryRepository = itineraryRepository;
            this.mapper = mapper;
            this.fileService = fileService;
        }


        public async Task<APIResponse<ItineraryResponse>> AddItinerary(ItineraryRequest model)
        {
            var itinerary = mapper.Map<Itinerary>(model);

            AppFile? file = default;

            if (model.File is not null)
            {
             file = await fileService.AddFile(model.File, AppModule.Itinerary, itinerary.Id);
            }

            var res = await itineraryRepository.AddAsync(itinerary);

            if (res > 0)
                return APIResponse<ItineraryResponse>.SuccessResponse(message: "Itinerary added to this package", result: new ItineraryResponse(){
                    Id = itinerary.Id, FilePath = file?.FilePath ?? "",Title = itinerary.Title,Description = itinerary.Description,Day = itinerary.Day,FileId = file?.Id });

            return APIResponse<ItineraryResponse>.ErrorResponse();
        }



        public async Task<APIResponse<IEnumerable<ItineraryResponse>>> PackageItineraries(Guid packageId)
        {
            var itineraries = await itineraryRepository.ItineariesByPackgaeId(packageId);

                return APIResponse<IEnumerable<ItineraryResponse>>.SuccessResponse(result:itineraries);
        }
    }
}
