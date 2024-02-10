using MultinationalTourAndTravels.Application.Abstractions.IRepository;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Services
{
    public class ContactService : IContactsService
    {
        private readonly IContactsRepository contactsRepository;

        public ContactService(IContactsRepository contactsRepository)
        {
            this.contactsRepository = contactsRepository;
        }


        public async Task<APIResponse<IEnumerable<Contact>>> Contacts()
        {
            var contacts = await contactsRepository.GetAllAsync();

            return APIResponse<IEnumerable<Contact>>.SuccessResponse(result: contacts);
        }

        public async Task<APIResponse<int>> ContactUs(ContactRequest model)
        {
            var contact = new Contact()
            {
                Email = model.Email,
                Message = model.Message,
                Subject = model.Subject
            };

            var res = await contactsRepository.AddAsync(contact);

            if (res > 0)
                return APIResponse<int>.SuccessResponse("Thank you for contacting us");

            return APIResponse<int>.ErrorResponse("There is some technical isssue please try later");
        }

        public async Task<APIResponse<int>> DeleteContact(Guid id)
        {
            var res = await contactsRepository.DeleteAsync(id);

            if (res > 0)
                return APIResponse<int>.SuccessResponse("Contact removed successfully",result:res);

            return APIResponse<int>.ErrorResponse("There is some technical isssue please try later");
        }
    }
}
