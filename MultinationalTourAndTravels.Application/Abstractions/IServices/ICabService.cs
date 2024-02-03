using MultinationalTourAndTravels.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IServices
{
    public interface ICabService
    {
        Task<APIResponse<IEnumerable<CabResponse>>> GetAllCabs();
        Task<APIResponse<int>> AddNewCab(CabRequest model);
        Task<APIResponse<int>> DeleteCab(Guid cabId);

    }
}
