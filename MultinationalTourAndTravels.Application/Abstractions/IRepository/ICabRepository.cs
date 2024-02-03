﻿using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IRepository
{
    public interface ICabRepository : IBaseRepository<Cab>
    {
        Task<IEnumerable<CabResponse>> GetAllCabs();
        Task<int> DeleteCab(Guid cabId);
    }
}
