using Microsoft.AspNetCore.Http;
using MultinationalTourAndTravels.Domain.Entities;
using MultinationalTourAndTravels.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IServices
{
    public interface IFileService
    {
        Task<AppFile?> AddFile(IFormFile file, AppModule appModule, Guid? entityId = default);
        Task<IEnumerable<AppFile>> AddFiles(IFormFileCollection files, AppModule appModule, Guid? entityId = default);

        Task<int> DeleteFileAsync(Guid id,string file);
    }
}
