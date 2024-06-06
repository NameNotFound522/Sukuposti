using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sukuposti.Infrastructure.Models;
using Sukuposti.Infrastructure.Repository.BaseRepository;

namespace Sukuposti.Infrastructure.Extensions
{
    public static class HorseFilterExtensions
    {
        public static async Task<List<Expression<Func<Hevonen, bool>>>> GetValidPredicates(
            this HorseFilterModel filter,
            IBaseRepository<Hevonen> horseRepository)
        {
            var predicates = new List<Expression<Func<Hevonen, bool>>>();

            if (!string.IsNullOrWhiteSpace(filter.Rotu?.ToString()))
                predicates.Add(h => h.Rotu == filter.Rotu);

            if (!string.IsNullOrWhiteSpace(filter.EmalinjaId?.ToString()))
                predicates.Add(h => h.EmalinjaId == filter.EmalinjaId);

            if (!string.IsNullOrWhiteSpace(filter.Sukupuoli))
                predicates.Add(h => h.Sukupuoli == filter.Sukupuoli);

            if (!string.IsNullOrWhiteSpace(filter.Vari))
                predicates.Add(h => h.Merkit.Contains(filter.Vari));

            if (!string.IsNullOrWhiteSpace(filter.Nimi))
            {
                var horses = await horseRepository.GetAllAsync().Result
                    .Where(x => x.HevonenNimis
                        .Select(n => n.Nimi.ToLower())
                        .Any(n => n == filter.Nimi.ToLower()))
                    .ToListAsync();

                Expression<Func<Hevonen, bool>> horsePredicate = h => horses.Contains(h);

                predicates.Add(horsePredicate);

            }

            return predicates;
        }
    }
}