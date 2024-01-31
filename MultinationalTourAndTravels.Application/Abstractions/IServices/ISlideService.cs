using MultinationalTourAndTravels.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IServices
{
    public interface ISlideService
    {
        Task<APIResponse<SliderResponse>> AddSlideFiles(SliderRequest model);
        Task<APIResponse<IEnumerable<SliderResponse>>> GetAllSlides();
        Task<APIResponse<IEnumerable<SliderResponse>>> GetActiveSlides();
        Task<APIResponse<int>> ChangeSlideStatus(SlideStatusRequest model);

        Task<APIResponse<SliderResponse>> DeleteSlide(Guid id);
    }
}
