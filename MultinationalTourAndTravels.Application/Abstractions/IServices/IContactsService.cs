using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IServices
{
    public interface IContactsService
    {
        Task<APIResponse<IEnumerable<Contact>>> Contacts();
        Task<APIResponse<int>> ContactUs(ContactRequest model);
        Task<APIResponse<int>> DeleteContact(Guid id);
    }
}
