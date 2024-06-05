using Sukuposti.Application.Services.Interfaces;
using Sukuposti.Domain.Entities;
using Sukuposti.Infrastructure.Repository.Interfaces;

namespace Sukuposti.Application.Services;

public class ImageService(IImageRepository imageRepository) //: IImagesService
    : IImagesService
{
 /*   public async Task<PagedResponse<Image>> GetImagesWithPagination(int pageNumber, int pageSize)
    {
        return await imageRepository.Pagination(pageNumber, pageSize);
    }*/
}