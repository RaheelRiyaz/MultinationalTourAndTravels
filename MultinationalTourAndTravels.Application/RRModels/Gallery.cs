using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.RRModels
{
   public record GalleryRequest
        (
       IFormFileCollection Files
       );

    public record GallerImage(Guid Id,string FilePath);

    public record DeleletGalleryRequest(IEnumerable<Guid> Ids);
}
