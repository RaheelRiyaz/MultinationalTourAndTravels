using Microsoft.AspNetCore.Http;
using MultinationalTourAndTravels.Application.Validators;
using MultinationalTourAndTravels.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.RRModels
{
    public record CabRequest(
        //[IsFileImage("image/jpeg", "image/png",ErrorMessage = "Please provide a jpeg or png file")] 
    IFormFile File,string Name,string Description,double Price,CabType CabType);

    public record CabResponse(Guid CabId,string Name,string Description,double Price,Guid? FileId,string FilePath,string CabType);
}
