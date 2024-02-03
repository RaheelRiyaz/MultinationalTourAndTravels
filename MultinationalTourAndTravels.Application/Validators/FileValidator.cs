using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Validators
{
    public class IsFileImage : ValidationAttribute
    {
        private readonly string[] extensions;

        public IsFileImage(params string[] extensions)
        {
            this.extensions = extensions;
        }

        public override bool IsValid(object? value)
        {
            if(value is IFormFile formFile)
            {
                return this.extensions.Contains(formFile.ContentType.ToLower());
            }
            
            return false;
        }
        
    }




    public class IsFilesImages : ValidationAttribute
    {
        private readonly string[] extensions;

        public IsFilesImages(params string[] extensions)
        {
            this.extensions = extensions;
        }



        public override bool IsValid(object? value)
        {

            if (value is IFormFileCollection files)
            {
                foreach (var file in files)
                {
                    var isValid = this.extensions.Contains(file.ContentType.ToLower());

                    if (isValid is false) 
                        return false;
                }

                return true;
            }

            return false;
        }
    }
}
