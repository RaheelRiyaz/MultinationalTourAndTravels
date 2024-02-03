using Microsoft.AspNetCore.Http;
using MultinationalTourAndTravels.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.RRModels
{
   public record GalleryRequest
        ([IsFilesImages("image/jpeg", "image/png",ErrorMessage ="Please provide a jpeg or png file")]
       IFormFileCollection Files
       );

    public record GallerImage(Guid Id,string FilePath);

    public record DeleletGalleryRequest(IEnumerable<Guid> Ids);
}
