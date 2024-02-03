using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultinationalTourAndTravels.Application.Abstractions.IRepository;
using MultinationalTourAndTravels.Persistence.Data;
using MultinationalTourAndTravels.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Persistence.DIContainer
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<MultinationalTourAndTravelsDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(nameof(MultinationalTourAndTravelsDbContext)));
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAppFileRepository, AppFileRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IInclusionsRepository, InclusionRepository>();
            services.AddScoped<IExclusionsRepository, ExclusionsRepository>();
            services.AddScoped<IItineraryRepository, ItineraryRepository>();
            services.AddScoped<IPackageDestination, PackageDestinationRepository>();
            services.AddScoped<IDestinationDetailsRepository, DestinationDetailsRepository>();
            services.AddScoped<IHotelsRepository, HotelsRepository>();
            services.AddScoped<IChatQuestionRepository, ChatBotQuestionRepository>();
            services.AddScoped<IChatAnswerRepository, ChatBotAnswerRepository>();
            services.AddScoped<IPackageCostingRepository, PackageCostingRepository>();
            services.AddScoped<ICabRepository, CabRepository>();
            return services;
        }
    }
}
