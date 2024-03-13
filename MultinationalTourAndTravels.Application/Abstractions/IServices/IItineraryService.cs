using MultinationalTourAndTravels.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IServices
{
    public interface IItineraryService
    {
        Task<APIResponse<ItineraryResponse>> AddItinerary(ItineraryRequest model);
        Task<APIResponse<IEnumerable<ItineraryResponse>>> PackageItineraries(Guid packageId);
    }
}
