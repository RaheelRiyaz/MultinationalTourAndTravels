using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Domain.Enums
{
    public enum ShowSlide : byte
    {
        Show = 1,
        Hide = 2,
    }


    public enum AppModule : byte
    {
        Slider = 1,
        Package = 2,
        Itinerary = 3,
        Hotel = 4,
        Gallery = 5,
        Cabs = 6
    }



    public enum PackageType : byte
    {
        Standard = 1,
        Deluxe = 2,
        SuperDeluxe = 3,
    }


    public enum Star : byte
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
    }



    public enum PackageCostingType : byte
    {
        _2px = 1,
        _4px = 2,
        _6px = 3,
        _12px = 4,
    }



    public enum CabType : byte
    {
        AC = 1,
        NON_AC = 2,
    }
}
