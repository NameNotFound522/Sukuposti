using Sukuposti.Application.Exceptions.Constans;

namespace Sukuposti.Application.Exceptions;

public class SignUpFailedException() : Exception(ErrorMessages.SignUpFailed);