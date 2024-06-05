using Sukuposti.Application.Exceptions.Constans;

namespace Sukuposti.Application.Exceptions;

public class ConfirmEmailFailedException() : Exception(ErrorMessages.ConfirmEmailFailed);