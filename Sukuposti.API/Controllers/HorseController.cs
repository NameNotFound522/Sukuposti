using System.Collections.Immutable;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Sukuposti.Domain.Models.Pagination;
using Sukuposti.Infrastructure;
using Sukuposti.Infrastructure.Models;
using Dapper;
using Sukuposti.Infrastructure.Extensions;

namespace Sukuposti.API.Controllers;

[Route("[controller]")]
[ApiController]
public class HorseController(IHorseRepository horseRepository, IHorseService horseService, MySqlConnection connection) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetHorses([FromQuery] RequestPagination pagination)
    {
        var result = await horseService.GetPaginated(pagination);
        return Ok(result);
    }
    
    [HttpGet("search/event")]
    public async Task<IActionResult> SearchByEvent()
    {
        return Ok();
    }
    
    [HttpGet("{id}")]
    public async Task<OkObjectResult> Horses([FromRoute] uint id)
    {

        var response = await horseService.GetById(id);
       
        return Ok(response);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchByFilter([FromQuery] HorseFilterModel filter)
    {
        var response = await filter.GetValidPredicates(horseRepository);
        return Ok(response);
    }

    [HttpGet("dapper")]
    public async Task<IActionResult> TestDapper()
    {
        var query = @"
    SELECT 
        CASE
            WHEN STR_TO_DATE(syntaika, '%Y-%m-%d') IS NULL THEN SUBSTRING(syntaika, 1, 4)
            ELSE syntaika
        END AS syntaika_corrected
    FROM sukuposti.hevonen
    WHERE spnro = @spnro;";

        var parameters = new { spnro = 12 };
        var horses = connection.Query<string>(query, parameters);
        
        return Ok(horses);
    }
}