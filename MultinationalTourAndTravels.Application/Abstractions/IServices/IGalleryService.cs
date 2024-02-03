using MultinationalTourAndTravels.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IServices
{
    public interface IGalleryService 
    {
        Task<APIResponse<IEnumerable<GallerImage>>> AddImages(GalleryRequest model);
        Task<APIResponse<IEnumerable<GallerImage>>> Gallery();
        Task<APIResponse<IEnumerable<GallerImage>>> GalleryPageWize(int pageNo,int pageSize);
        Task<APIResponse<GallerImage>> DeleteGalleryImage(Guid id);
        Task<APIResponse<int>> DeleteGalleryImages(IEnumerable<Guid> ids);
    }
}
