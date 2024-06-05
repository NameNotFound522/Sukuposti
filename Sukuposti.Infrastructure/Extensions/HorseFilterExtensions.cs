using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Sukuposti.Infrastructure.Models;

namespace Sukuposti.Infrastructure.Extensions;

public static class HorseFilterExtensions
{
    public static IEnumerable<Expression<Func<Hevonen, bool>>> GetValidPredicates(this HorseFilterModel filter)
    {
          if (!string.IsNullOrWhiteSpace(filter.Rotu.ToString()))
              yield return h => h.Rotu == filter.Rotu;

          if (!string.IsNullOrWhiteSpace(filter.EmalinjaId.ToString()))
              yield return h => h.EmalinjaId == filter.EmalinjaId;

          if (!string.IsNullOrWhiteSpace(filter.Sukupuoli))
              yield return h => h.Sukupuoli == filter.Sukupuoli;

          if (!string.IsNullOrWhiteSpace(filter.Vari))
              yield return h => h.Merkit.Contains(filter.Vari);
          
          if (!string.IsNullOrWhiteSpace(filter.Nimi))
              yield return h => h.HevonenNimis.Any(n => n.Nimi.ToLower() == filter.Nimi.ToLower());


    }

}