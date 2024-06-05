
using Dapper;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Sukuposti.Infrastructure.Context;
using Sukuposti.Infrastructure.Extensions;
using Sukuposti.Infrastructure.Models;
using Sukuposti.Infrastructure.Repository.BaseRepository;
using Sukuposti.Infrastructure.Repository.Interfaces;

namespace Sukuposti.Infrastructure.Repository.Implementations;

public class HorseRepository(ApiContext dbContext,MySqlConnection connection) : BaseRepository<Hevonen>(dbContext), IHorseRepository
{
    public async Task<IQueryable<Hevonen>> OrFilter(HorseFilterModel filters)
    {
        var horses = dbContext.Hevonens.Include(h => h.HevonenNimis).AsQueryable();
        var predicates = filters.GetValidPredicates().ToList();
        
        if (predicates.Any())
        {
            var predicate = PredicateBuilder.New<Hevonen>(false); // False for OR

            predicate = predicates.Aggregate(predicate, (current, p) => current.And(p));
            horses = horses.Where(predicate);
            
        }

        string sql = horses.ToQueryString();
        var hor = await connection.QueryAsync<Hevonen>(sql);
        return await Task.FromResult(horses);

    }
    
}


