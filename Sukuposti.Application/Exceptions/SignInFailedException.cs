using Sukuposti.Application.Exceptions.Constans;

namespace Sukuposti.Application.Exceptions;



public class SignInFailedException() : Exception(ErrorMessages.SignInFailed);