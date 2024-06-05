using Microsoft.AspNetCore.Mvc;
using Sukuposti.Application.Services.Interfaces;


namespace Sukuposti.API.Controllers;

[Route("[controller]")]
[ApiController]
public class ImageController(IImagesService imageService) : ControllerBase
{
    
    [HttpGet("pagination")]
    public async Task<IActionResult> Pagination(int pageNumber = 1, int pageSize = 50)
    {
        if (pageNumber <= 0 || pageSize <= 0)
            return BadRequest($"{nameof(pageNumber)} and {nameof(pageSize)} size must be greater than 0.");
      //  var pagedProducts = await imageService.GetImagesWithPagination(pageNumber, pageSize);
         
        return Ok(/*pagedProducts.Data*/);
 
    }
}