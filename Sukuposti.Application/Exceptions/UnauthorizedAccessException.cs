namespace Sukuposti.Application.Exceptions;

public class UnauthorizedAccessException(string error) : Exception(error)
{
    
}