using Microsoft.EntityFrameworkCore;
using Sukuposti.Domain.Models.Pagination;
using Sukuposti.Infrastructure.Repository.BaseRepository;

namespace Sukuposti.Application.Services.BaseService;

public class BaseService<T> : IBaseService<T> where T : class
{
    protected readonly IBaseRepository<T> repository;

    public BaseService(IBaseRepository<T> repository)
    {
        this.repository = repository;
    }

    public async Task<PageResponse<T>> GetPaginated(RequestPagination pagination)
    {
        var query = await Task.FromResult(repository.GetAllAsync().Result
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize));

        var totalCount = query.Count();
        var totalPages = (int)Math.Ceiling(totalCount / (double)pagination.PageSize);

        var pagedResponse = new PageResponse<T>
        {
            Data = query,
            PageCount = totalPages,
            PageNumber = pagination.PageNumber,
            PageSize = pagination.PageSize,
        };

        return pagedResponse;
    }
    
    public async Task<PageResponse<T>> GetPaginated(IQueryable<T> collection, RequestPagination pagination)
    {
        var query = await Task.FromResult(collection
            .AsNoTracking()
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize));

        var totalCount = query.Count();
        var totalPages = (int)Math.Ceiling(totalCount / (double)pagination.PageSize);

        var pagedResponse = new PageResponse<T>
        {
            Data = query,
            PageCount = totalPages,
            PageNumber = pagination.PageNumber,
            PageSize = pagination.PageSize,
        };

        return pagedResponse;
    }
}