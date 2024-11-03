namespace FlowCode;

public static class ValueOperationResultToExtensions
{
    public static ValueOperationResult<Result> To<T, Result>(this ValueOperationResult<T> operationResult, Func<T, Result> success, Func<Exception, Exception> error)
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
        return operationResult.Exception;
    }
}