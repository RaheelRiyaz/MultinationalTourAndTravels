using MultinationalTourAndTravels.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.EmailService
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(MailSettings model);
    }
}
