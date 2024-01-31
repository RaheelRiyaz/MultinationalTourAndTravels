using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IContextService
{
    public interface IContextService
    {
        Guid GetUserId();
    }
}
