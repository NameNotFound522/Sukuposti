using Sukuposti.Domain.Models.Pagination;

namespace Sukuposti.Application.Services.BaseService;

public interface IBaseService<T> where T : class
{
    Task<PageResponse<T>> GetPaginated(RequestPagination pagination);
    Task<PageResponse<T>> GetPaginated(IQueryable<T> collection, RequestPagination pagination);
}