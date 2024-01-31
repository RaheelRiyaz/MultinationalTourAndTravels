using MultinationalTourAndTravels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.ITokenService
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
