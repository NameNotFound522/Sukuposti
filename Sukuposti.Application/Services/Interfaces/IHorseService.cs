using Sukuposti.Application.Services.BaseService;
using Sukuposti.Domain.DTO.EventSearch;
using Sukuposti.Domain.Models.Pagination;
using Sukuposti.Infrastructure.Models;

namespace Sukuposti.Application.Services.Interfaces;

public interface IHorseService : IBaseService<Hevonen>
{
    Task<IQueryable<Hevonen>> GetHorses();
    Task<List<Hevonen>> GetHorseByName(string name, RequestPagination pagination);
    Task<List<Hevonen>> GetHorsesByEvent(RequestEventSearch eventSearch, RequestPagination pagination);
    Task<Hevonen?> GetById(uint id);
}