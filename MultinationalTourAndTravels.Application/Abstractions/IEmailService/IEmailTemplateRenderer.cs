using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.EmailService
{
    public interface IEmailTemplateRenderer
    {
        Task<string> EmailTemplate(string templateName ,object model);
    }
}
