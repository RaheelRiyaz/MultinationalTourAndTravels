using AutoMapper;
using MultinationalTourAndTravels.Application.Abstractions.IRepository;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly IFileService fileService;
        private readonly IAppFileRepository appFileRepository;
        private readonly IMapper mapper;

        public GalleryService(IFileService fileService, IAppFileRepository appFileRepository, IMapper mapper)
        {
            this.fileService = fileService;
            this.appFileRepository = appFileRepository;
            this.mapper = mapper;
        }


        public async Task<APIResponse<IEnumerable<GallerImage>>> AddImages(GalleryRequest model)
        {
            var filePaths = await fileService.AddFiles(model.Files, AppModule.Gallery);

            if (!filePaths.Any())
                return APIResponse<IEnumerable<GallerImage>>.ErrorResponse();

            return APIResponse<IEnumerable<GallerImage>>.SuccessResponse(message: "Images Uploaded Successfully", result: mapper.Map<IEnumerable<GallerImage>>(filePaths));
        }


        public async Task<APIResponse<GallerImage>> DeleteGalleryImage(Guid id)
        {
            var file = await appFileRepository.GetByIdAsync(id);

            if (file is null)
                return APIResponse<GallerImage>.ErrorResponse();

            var res = await appFileRepository.DeleteAsync(file);
            if (res > 0)
                return APIResponse<GallerImage>.SuccessResponse(result: mapper.Map<GallerImage>(file));

            return APIResponse<GallerImage>.ErrorResponse();
        }



        public async Task<APIResponse<int>> DeleteGalleryImages(IEnumerable<Guid> ids)
        {
            var res = await appFileRepository.DeleteRangeAsync(ids);

            if (res > 0)
                return APIResponse<int>.SuccessResponse(result: res);


            return APIResponse<int>.ErrorResponse();
        }



        public async Task<APIResponse<IEnumerable<GallerImage>>> Gallery()
        {
            var galleryImages = await appFileRepository.FilterAsync(_ => _.AppModule == AppModule.Gallery);

            return APIResponse<IEnumerable<GallerImage>>.SuccessResponse(result: mapper.Map<IEnumerable<GallerImage>>(galleryImages));
        }

        public async Task<APIResponse<IEnumerable<GallerImage>>> GalleryPageWize(int pageNo, int pageSize)
        {
            var galleryImages = (await appFileRepository.FilterAsync(_ => _.AppModule == AppModule.Gallery))
                .Skip((pageNo - 1) * pageSize).Take(pageSize);

            return APIResponse<IEnumerable<GallerImage>>.SuccessResponse(result: mapper.Map<IEnumerable<GallerImage>>(galleryImages));
        }
    }
}
