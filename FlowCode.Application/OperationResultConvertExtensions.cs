namespace FlowCode;

public static class OperationResultConvertExtensions
{
    public static Result Convert<Result, T>(this OperationResult<T> operationResult, Func<T, Result> success, Func<Exception, Result> error)
    {
        if (operationResult.IsSuccess)
        {
            if (operationResult.Data is null)
            {
                return error(new OperationResultException("Data is null"));
            }

            return success(operationResult.Data);
        }

        if (operationResult.Exception is null)
        {
            return error(new OperationResultException("Exception is null"));
        }

        return error(operationResult.Exception);
    }
}

