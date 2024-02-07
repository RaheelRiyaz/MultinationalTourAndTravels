using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultinationalTourAndTravels.Application.Abstractions.EmailService;
using MultinationalTourAndTravels.Application.Abstractions.IContextService;
using MultinationalTourAndTravels.Application.Abstractions.ITokenService;
using MultinationalTourAndTravels.Infrastructure.EmailService;
using MultinationalTourAndTravels.Infrastructure.Model;
using MultinationalTourAndTravels.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Infrastructure.DIContainer
{
    public static class Assemblyreference
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddSingleton<IContextService, ContextService>();
            services.AddSingleton<IEmailTemplateRenderer, EmailTemplateRendererService>();
            services.AddSingleton<IEmailService, MailService>();
            services.Configure<MailJetOptions>(configuration.GetSection("MailJetOptionSection"));
            return services;
        }
    }
}
