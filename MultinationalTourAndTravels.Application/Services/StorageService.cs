using Microsoft.AspNetCore.Http;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Services
{
    public class StorageService : IStorageService
    {
        private readonly string webrootPath;

        public StorageService(string webrootPath)
        {
            this.webrootPath = webrootPath;
        }


        public async Task<string> DeleteFileAsync(string filePath)
        {
            var fullPath = string.Concat(webrootPath, filePath);

            await Task.Run(() =>
            {
                try
                {
                    File.Delete(fullPath);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });

            return fullPath;
        }

        public async Task<List<string>> DeleteFilesAsync(List<string> files)
        {
            List<string> fileResult = new List<string>();

            foreach (var file in files)
            {
             fileResult.Add(await DeleteFileAsync(file));   
            }

            return fileResult;
        }



        public async Task<string> SaveFileAsync(IFormFile file)
        {
            var filePath = string.Concat(Guid.NewGuid(), file.FileName);

            var fullPath = string.Concat(GetPhysicalPath(), filePath);

            using var fs = new FileStream(fullPath, FileMode.Create);

            await file.CopyToAsync(fs);

            return string.Concat(GetVirtualPath(), filePath);
        }




        public async Task<List<string>> SaveFilesAsync(IFormFileCollection files)
        {
            List<string> fileResults = new List<string>();

            foreach (var file in files)
            {
             fileResults.Add(await SaveFileAsync(file));   
            }

            return fileResults;
        }



        private string GetPhysicalPath() => webrootPath + GetVirtualPath();
        private string GetVirtualPath() => "/Files/";
    }
}
