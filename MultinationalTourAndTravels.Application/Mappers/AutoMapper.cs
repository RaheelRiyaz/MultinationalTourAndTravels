using AutoMapper;
using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Mappers
{
    public class UserAutoMapper : Profile
    {
        public UserAutoMapper()
        {
            CreateMap<UserRequest, User>();   
            CreateMap<User, UserResponse>();   
        }
    }



    public class SliderAutoMapper : Profile
    {
        public SliderAutoMapper()
        {
            CreateMap<AppFile, SliderResponse>();
        }
    }


    public class PackageAutoMapper : Profile
    {
        public PackageAutoMapper()
        {
            CreateMap<PackageRequest, Package>();
        }
    }



    public class ItineraryAutoMapper : Profile
    {
        public ItineraryAutoMapper()
        {
            CreateMap<ItineraryRequest, Itinerary>();
        }
    }

    public class AppFileMapper : Profile
    {
        public AppFileMapper()
        {
            CreateMap<AppFile, GallerImage>();
        }
    }
}
