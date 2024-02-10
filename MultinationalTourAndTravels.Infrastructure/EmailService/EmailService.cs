using Mailjet.Client;
using Mailjet.Client.TransactionalEmails;
using Microsoft.Extensions.Options;
using MultinationalTourAndTravels.Application.Abstractions.EmailService;
using MultinationalTourAndTravels.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Infrastructure.EmailService
{
    public class MailService : IEmailService
    {
        private readonly MailJetOptions options;

        public MailService(IOptions<MailJetOptions> options)
        {
            this.options = options.Value;
        }

        public async Task<bool> SendEmailAsync(MailSettings model)
        {
            MailjetClient mailjetClient = new MailjetClient(options.ApiKey, options.SecretKey);
            var email = new TransactionalEmailBuilder()
                .WithFrom(new SendContact(options.FromEmail)).
                WithSubject(model.Subject).
                WithTo(new SendContact(model.To.FirstOrDefault())).
                WithHtmlPart(model.Body).
                Build();

            await mailjetClient.SendTransactionalEmailAsync(email);

            return true;
        }
    }
}
