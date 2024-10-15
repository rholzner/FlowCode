namespace FlowCode;

public static class OperationResultConvertAsyncExtensions
{
    public static ValueTask<Result> ConvertAsync<Result, T>(this OperationResult<T> operationResult, Func<T, Result> success, Func<Exception, Result> error)
    {
        if (operationResult.IsSuccess)
        {
            if (operationResult.Data is null)
            {
                return ValueTask.FromResult(error(new OperationResultException("Data is null")));
            }

            return ValueTask.FromResult(success(operationResult.Data));
        }

        if (operationResult.Exception is null)
        {
            return ValueTask.FromResult(error(new OperationResultException("Exception is null")));
        }

        return ValueTask.FromResult(error(operationResult.Exception));
    }
}

