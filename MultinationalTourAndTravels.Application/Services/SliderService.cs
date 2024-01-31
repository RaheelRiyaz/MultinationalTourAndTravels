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
    internal class SliderService : ISlideService
    {
        private readonly IFileService fileService;
        private readonly IMapper mapper;
        private readonly ISliderRepository sliderRepository;
        private readonly IStorageService storageService;

        public SliderService(IFileService fileService,IMapper mapper, ISliderRepository sliderRepository,IStorageService storageService)
        {
            this.fileService = fileService;
            this.mapper = mapper;
            this.sliderRepository = sliderRepository;
            this.storageService = storageService;
        }


        public async Task<APIResponse<SliderResponse>> AddSlideFiles(SliderRequest model)
        {

            var slide = new Slider()
            {
                ShowSlide = model.ShowSlide,
                Description = model.Description
            };

            var appFile = await fileService.AddFile(model.File, AppModule.Slider,slide.Id);

            var res = await sliderRepository.AddAsync(slide);

           if (res > 0) 
                return APIResponse<SliderResponse>.SuccessResponse
                    (result:
                    new SliderResponse()
                    { Description = slide.Description,
                        Id = slide.Id,
                        FilePath = appFile!.FilePath, 
                        SlideStatus = slide.ShowSlide == ShowSlide.Show ? "True" : "False"}
                    );

            return APIResponse<SliderResponse>.ErrorResponse();

        }



        public async Task<APIResponse<IEnumerable<SliderResponse>>> GetAllSlides()
        {
            var slides = await sliderRepository.GetAllSlides();

            return APIResponse<IEnumerable<SliderResponse>>.SuccessResponse(result: slides);
        }


        public async Task<APIResponse<IEnumerable<SliderResponse>>> GetActiveSlides()
        {
            var slides = await sliderRepository.GetActiveSlides();

            return APIResponse<IEnumerable<SliderResponse>>.SuccessResponse(result: slides);
        }


        public async Task<APIResponse<int>> ChangeSlideStatus(SlideStatusRequest model)
        {
            var res = await sliderRepository.ChangeSlideStatus(model.Id, model.Status);
            if (res > 0)
                return APIResponse<int>.SuccessResponse(message: $@"Slide status has been changed to {(model.Status == ShowSlide.Show ? "Active" :( "Inactive"))} successfully",result:res);

            return APIResponse<int>.ErrorResponse();
        }


        public async Task<APIResponse<SliderResponse>> DeleteSlide(Guid id)
        {
            var slide = await sliderRepository.GetSlideById(id);
            if (slide is null)
                return APIResponse<SliderResponse>.ErrorResponse("No slide found");

            await storageService.DeleteFileAsync(slide.FilePath);

            var res = await sliderRepository.DeleteAsync(id);

            if (res > 0)
                return APIResponse<SliderResponse>.SuccessResponse("Slider removed successfully", result: slide);

            return APIResponse<SliderResponse>.ErrorResponse();
        }
    }
}
