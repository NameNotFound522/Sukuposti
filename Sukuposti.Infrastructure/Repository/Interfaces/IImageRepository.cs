using Sukuposti.Domain.Entities;
using Sukuposti.Infrastructure.Models;
using Sukuposti.Infrastructure.Repository.BaseRepository;

namespace Sukuposti.Infrastructure.Repository.Interfaces;

public interface IImageRepository : IBaseRepository<HevonenKuva>
{
    //public Task<PagedResponse<Image>> GetImageWithPagination(int pageNumber, int pageSize);
    //public  Task<IQueryable<Horse>> ApplyFilters(IQueryable<Horse> query, string sortOrder, bool? isFoal);
}