using AutoMapper;
using MultinationalTourAndTravels.Application.Abstractions.IRepository;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using MultinationalTourAndTravels.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository packageRepository;
        private readonly IExclusionsRepository exclusionsRepository;
        private readonly IInclusionsRepository inclusionsRepository;
        private readonly IItineraryRepository itineraryRepository;
        private readonly IMapper mapper;
        private readonly IFileService fileService;
        private readonly IPackageDestination packageDestination;
        private readonly IHotelsRepository hotelsRepository;

        public PackageService(IPackageRepository packageRepository, IExclusionsRepository exclusionsRepository, IInclusionsRepository inclusionsRepository, IItineraryRepository itineraryRepository, IMapper mapper, IFileService fileService, IPackageDestination packageDestination, IHotelsRepository hotelsRepository)
        {
            this.packageRepository = packageRepository;
            this.exclusionsRepository = exclusionsRepository;
            this.inclusionsRepository = inclusionsRepository;
            this.itineraryRepository = itineraryRepository;
            this.mapper = mapper;
            this.fileService = fileService;
            this.packageDestination = packageDestination;
            this.hotelsRepository = hotelsRepository;
        }




        public async Task<APIResponse<int>> AddPackage(PackageRequest model)
        {
            var package = mapper.Map<Package>(model);

            var appFileResponse = await fileService.AddFiles(model.Files, AppModule.Package, package.Id);
            if (!appFileResponse.Any())
                return APIResponse<int>.ErrorResponse();

            var res = await packageRepository.AddAsync(package);

            if (res > 0)
                return APIResponse<int>.SuccessResponse("Package created successfully", result: res);

            return APIResponse<int>.ErrorResponse();
        }




        public async Task<APIResponse<CompactPackage>> GetCompactPackageById(Guid packageId)
        {
            var package = await packageRepository.GetByIdAsync(packageId);

            if (package is null)
                return APIResponse<CompactPackage>.ErrorResponse();


            var destinations = await packageDestination.FilterAsync(_ => _.PackageId == packageId);


            List<CompactDestinationWithHotels> compactDestinationWithHotels = new List<CompactDestinationWithHotels>();


            foreach (var destination in destinations)
            {
                var SH = await hotelsRepository.HotelsByDestinationAndPackageType(destination.Id, 1);
                var DH = await hotelsRepository.HotelsByDestinationAndPackageType(destination.Id, 2);
                var SDH = await hotelsRepository.HotelsByDestinationAndPackageType(destination.Id, 3);


                CompactDestinationWithHotels CDH = new CompactDestinationWithHotels()
                {
                    Name = destination.Name,
                    Stay = destination.Stay,
                    DeluxeHotels = DH,
                    StandardHotels = SH,
                    SuperDeluxeHotels = SDH
                };

                compactDestinationWithHotels.Add(CDH);
            }
            var files = await packageRepository.GetPackagesFiles(packageId);
            var itineraries = await itineraryRepository.ItineariesByPackgaeId(packageId);
            var exclusions = await exclusionsRepository.ViewExclusions(packageId);
            var inclusions = await inclusionsRepository.ViewInclusions(packageId);

            CompactPackage compactPackage = new CompactPackage()
            {
                Package = package,
                DestinationsWithHotels = compactDestinationWithHotels,
                Exclusions = exclusions,
                Inclusions = inclusions,
                Itineraries = itineraries,
                Files = files
            };

            return APIResponse<CompactPackage>.SuccessResponse(result: compactPackage);
        }





        public async Task<APIResponse<IEnumerable<DisplayingPackage>>> GetDisplayingpackages()
        {
            var displayingPackage = new List<DisplayingPackage>();

            var packages = await packageRepository.GetHomePackages();

            foreach (var package in packages)
            {
                var destinations = await packageDestination.GetDestinationNamesByPackage(package.Id);
                var files = await packageRepository.GetPackagesFiles(package.Id);

                var _package = new DisplayingPackage()
                {
                    PackageResponse = package,
                    Destinations = destinations,
                    Files = files
                };

                displayingPackage.Add(_package);
            }

            return APIResponse<IEnumerable<DisplayingPackage>>.SuccessResponse(result: displayingPackage);
        }


        public async Task<APIResponse<IEnumerable<DisplayingPackage>>> GetDisplayingPackagesPageWize(int pageNo, int total)
        {
            var packages = await GetDisplayingpackages();

             var totalPackages = packages?.Result?.Skip((pageNo-1)*total).Take(total);

            return APIResponse<IEnumerable<DisplayingPackage>>.SuccessResponse(result: totalPackages);
        }
    }
}
