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
    public interface ISliderRepository : IBaseRepository<Slider>
    {
        Task<IEnumerable<SliderResponse>> GetAllSlides();
        Task<SliderResponse?> GetSlideById(Guid id);
        Task<IEnumerable<SliderResponse>> GetActiveSlides();
        Task<int> ChangeSlideStatus(Guid id, ShowSlide status);
        Task<int> DeleletSlider(Guid id);
    }
}
