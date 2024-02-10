using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.RRModels
{
    public record ContactRequest
        (
        string Email,
        string Subject,
        string Message
        );
}
