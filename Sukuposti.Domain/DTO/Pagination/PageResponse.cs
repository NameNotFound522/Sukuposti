namespace Sukuposti.Domain.Models.Pagination;

public class PageResponse<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int PageCount { get; set; }
    public IQueryable<T>? Data { get; set; }
}   