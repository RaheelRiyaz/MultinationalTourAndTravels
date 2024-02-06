using Microsoft.Extensions.DependencyInjection;
using MultinationalTourAndTravels.Application.Abstractions.IRepository;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.DIContainer
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,string webrootPath)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IStorageService>(new StorageService(webrootPath));
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ISlideService, SliderService>();
            services.AddScoped<IPackageCostingService, PackageService>();
            services.AddScoped<IItineraryService, ItineraryService>();
            services.AddScoped<IInclusionsService, InclusionExcluionService>();
            services.AddScoped<IPackageDestinationService, PackageDestinationService>();
            services.AddScoped<IHotelsService, HotelsService>();
            services.AddScoped<IGalleryService, GalleryService>();
            services.AddScoped<IChatBotService, ChatBotService>();
            services.AddScoped<IPackageCosting, PackageCostingService>();
            services.AddScoped<ICabService, CabService>();
            services.AddScoped<ILinkTreeService, LinkTreeService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
