using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultinationalTourAndTravels.Application;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;

namespace MultinationalTourAndTravels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsService contactsService;

        public ContactsController(IContactsService contactsService)
        {
            this.contactsService = contactsService;
        }

        [HttpGet]
        public async Task<APIResponse<IEnumerable<Contact>>> GetContacts() =>
            await contactsService.Contacts();


        [AllowAnonymous]
        [HttpPost]
        public async Task<APIResponse<int>> ContactUs(ContactRequest model) =>
            await contactsService.ContactUs(model);


        [HttpDelete("{id:guid}")]
        public async Task<APIResponse<int>> DeleteContact(Guid id) =>
            await contactsService.DeleteContact(id);
    }
}
