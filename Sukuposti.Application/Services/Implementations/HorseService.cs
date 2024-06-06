using Microsoft.EntityFrameworkCore;
using Sukuposti.Application.Services.BaseService;
using Sukuposti.Application.Services.Interfaces;
using Sukuposti.Domain.DTO.EventSearch;
using Sukuposti.Domain.Models.Pagination;
using Sukuposti.Infrastructure.Models;
using Sukuposti.Infrastructure.Repository.Interfaces;

namespace Sukuposti.Application.Services.Implementations;

public class HorseService : BaseService<Hevonen>, IHorseService
{
    public HorseService(IHorseRepository horseRepository) : base(horseRepository)
    {
    }

    public async Task<IQueryable<Hevonen>> GetHorses()
    {
        var horses = await repository.GetAllAsync();
        return horses;
    }

    public async Task<List<Hevonen>> GetHorseByName(string name, RequestPagination pagination)
    {
        var horses = repository.GetAllAsync().Result
            .Where(x => x.HevonenNimis
                .Select(n => n.Nimi.ToLower())
                .Any(n => n.Contains(name.ToLower())));
        
        var response = await GetPaginated(horses, pagination);
        return await response.Data!.ToListAsync();
    }
    
    public async Task<List<Hevonen>> GetHorsesByEvent(RequestEventSearch eventSearch, RequestPagination pagination)
    {
        var horses = await GetPaginated(pagination).Result.Data!
            .ToListAsync();
            
        return horses;
    }

    public async Task<Hevonen?> GetById(uint id)
    {
        return await repository.GetByIdAsync(id);
    }
}