using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultinationalTourAndTravels.Application;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;

namespace MultinationalTourAndTravels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly IGalleryService galleryService;

        public GalleryController(IGalleryService galleryService)
        {
            this.galleryService = galleryService;
        }


        [HttpPost]
        public async Task<APIResponse<IEnumerable<GallerImage>>> AddImages([FromForm]GalleryRequest model) =>
            await galleryService.AddImages(model);



        [HttpGet]
        public async Task<APIResponse<IEnumerable<GallerImage>>> Gallery() =>
            await galleryService.Gallery();



        [HttpDelete("{id:guid}")]
        public async Task<APIResponse<GallerImage>> Gallery(Guid id) =>
            await galleryService.DeleteGalleryImage(id);


        [HttpPost("delete-images")]
        public async Task<APIResponse<int>> Gallery(DeleletGalleryRequest model) =>
            await galleryService.DeleteGalleryImages(model.Ids);


        [HttpGet("pagewize/{pageNo:int}/{pageSize:int}")]
        public async Task<APIResponse<IEnumerable<GallerImage>>> GalleryPageWize(int pageNo, int pageSize) =>
            await galleryService.GalleryPageWize(pageNo, pageSize);
    }
}
