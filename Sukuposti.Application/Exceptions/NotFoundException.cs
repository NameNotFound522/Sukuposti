using Sukuposti.Application.Exceptions.Constans;

namespace Sukuposti.Application.Exceptions;

public abstract class NotFoundException : Exception
{
    public NotFoundException() : base(ErrorMessages.NotFound)
    {
    }
}