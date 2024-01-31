using Microsoft.AspNetCore.Http;
using MultinationalTourAndTravels.Application.Abstractions.IContextService;
using MultinationalTourAndTravels.Application.Utlis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Infrastructure.Services
{
    public class ContextService : IContextService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public ContextService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }


        public Guid GetUserId()
        {
            var claim = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(_ => _.Type == AppClaim.Id);

            return claim is not null ? Guid.Parse(claim.Value) : Guid.Empty;
        }
    }
}
