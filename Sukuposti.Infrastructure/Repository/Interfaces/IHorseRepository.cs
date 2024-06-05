using Sukuposti.Infrastructure.Models;
using Sukuposti.Infrastructure.Repository.BaseRepository;

namespace Sukuposti.Infrastructure.Repository.Interfaces;

public interface IHorseRepository : IBaseRepository<Hevonen>
{
    public Task<IQueryable<Hevonen>> OrFilter(HorseFilterModel filters);
}