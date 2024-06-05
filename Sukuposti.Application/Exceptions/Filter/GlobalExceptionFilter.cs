using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Sukuposti.Application.Exceptions.Filter;

public class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var statusCode = context.Exception switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            
            SignUpFailedException => StatusCodes.Status400BadRequest,

            SignInFailedException => StatusCodes.Status400BadRequest,
            
            ConfirmEmailFailedException => StatusCodes.Status500InternalServerError,

            UnauthorizedAccessException => StatusCodes.Status401Unauthorized,

            _ => StatusCodes.Status500InternalServerError
        };

        context.Result = new ObjectResult(new
        {
            error = context.Exception.Message,
        })
        {
            StatusCode = statusCode
        };
    }
}