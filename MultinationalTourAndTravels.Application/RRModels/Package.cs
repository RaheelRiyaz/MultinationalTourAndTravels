using Microsoft.AspNetCore.Http;
using MultinationalTourAndTravels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.RRModels
{
    public record PackageRequest(IFormFileCollection Files, string Name, string Description, double StartingPrice, int Days, int Nights, double Longitude, double Latitude);

    public record PackageResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double StartingPrice { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int Days { get; set; }
        public int Nights { get; set; }
    }


    public record PackageFile (Guid Id,string FilePath);

    public record DestinationName(string Name, Guid Id);

    public class DisplayingPackage
    {
        public PackageResponse PackageResponse { get; set; } = null!;
        public IEnumerable<DestinationName> Destinations { get; set; } = null!;

        public IEnumerable<PackageFile> Files { get; set; } = null!;
    }

    public class CompactPackage
    {
        public Package Package { get; set; } = null!;
        public IEnumerable<InclusionOrExclusionResponse> Inclusions { get; set; } = Enumerable.Empty<InclusionOrExclusionResponse>();
        public IEnumerable<InclusionOrExclusionResponse> Exclusions { get; set; } = Enumerable.Empty<InclusionOrExclusionResponse>();
        public IEnumerable<ItineraryResponse> Itineraries { get; set; } = Enumerable.Empty<ItineraryResponse>();
        public IEnumerable<CompactDestinationWithHotels> DestinationsWithHotels { get; set; } = Enumerable.Empty<CompactDestinationWithHotels>();
        public IEnumerable<PackageFile> Files { get; set; } = null!;

    }




    public class CompactDestinationWithHotels
    {
        public string Name { get; set; } = null!;
        public string Stay { get; set; } = null!;

        public IEnumerable<DestinationHotel> StandardHotels { get; set; } = Enumerable.Empty<DestinationHotel>();
        public IEnumerable<DestinationHotel> DeluxeHotels { get; set; } = Enumerable.Empty<DestinationHotel>();
        public IEnumerable<DestinationHotel> SuperDeluxeHotels { get; set; } = Enumerable.Empty<DestinationHotel>();
    }


}
