using Microsoft.AspNetCore.Http;
using MultinationalTourAndTravels.Application.Abstractions.IRepository;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Domain.Entities;
using MultinationalTourAndTravels.Domain.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IAppFileRepository appFileRepository;
        private readonly IStorageService storageService;

        public FileService(IAppFileRepository appFileRepository,IStorageService storageService)
        {
            this.appFileRepository = appFileRepository;
            this.storageService = storageService;
        }


        public async Task<IEnumerable<AppFile>> AddFiles(IFormFileCollection files, AppModule appModule, Guid? entityId = default)
        {
            

            var paths = await storageService.SaveFilesAsync(files);
            var appFiles = new List<AppFile>();

            foreach (var path in paths)
            {
                var appFile = new AppFile()
                {
                    AppModule = appModule,
                    EntityId = entityId,
                    FilePath = path
                };

                appFiles.Add(appFile);
            }

            var res = await appFileRepository.AddRangeAsync(appFiles);

            if (res > 0) return appFiles;

            return Enumerable.Empty<AppFile>();
        }


        public async Task<AppFile?> AddFile(IFormFile file, AppModule appModule, Guid? entityId = default)
        {
            var path = await storageService.SaveFileAsync(file);

            var appFile = new AppFile()
            {
                AppModule = appModule,
                EntityId = entityId,
                FilePath = path
            };
            var res = await appFileRepository.AddAsync(appFile);

            if (res > 0) return appFile;

            return null;
        }


        public async Task<int> DeleteFileAsync(Guid id,string file)
        {
            await storageService.DeleteFileAsync(file);

            var deleteDbFile = await appFileRepository.DeleteAsync(id);

            return deleteDbFile;
        }
    }
}
