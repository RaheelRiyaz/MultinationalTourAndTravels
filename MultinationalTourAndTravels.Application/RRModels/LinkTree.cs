using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.RRModels
{
    public record LinkTreeRequest
        (
        string Facebook,
        string Instagram,
        string youtube,
        string Twitter,
        string Google,
        string Whatsapp,
        string Address
        );
}
