using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.RRModels
{
    public record InclusionRequest(Guid PackageId,string Description);
    public record ExclusionRequest(Guid PackageId,string Description);

    public record InclusionOrExclusionResponse(Guid Id,Guid PackageId,string Description);

    public record InclusionExclusionUpdateRequest(Guid Id,string Description);
}
