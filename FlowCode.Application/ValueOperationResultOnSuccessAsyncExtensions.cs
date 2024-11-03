namespace FlowCode;

public static class ValueOperationResultOnSuccessAsyncExtensions
{
    /// <summary>
    /// Executes the provided action if the operation result is successful.
    /// </summary>
    /// <typeparam name="Result"></typeparam>
    /// <param name="operationResult"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static async ValueTask<ValueOperationResult> OnSuccessAsync(this ValueOperationResult operationResult, Func<ValueTask<ValueOperationResult>> action)
    {
        if (operationResult.IsSuccess)
        {
            return await action();
        }

        if (operationResult.Exception is null)
        {
            return new OperationResultException("Exception is null");
        }

        return operationResult.Exception;
    }

    /// <summary>
    /// Executes the provided action if the operation result is successful.
    /// </summary>
    /// <typeparam name="Result"></typeparam>
    /// <param name="operationResult"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static async ValueTask<ValueOperationResult<Result>> OnSuccessAsync<Result>(this ValueOperationResult operationResult, Func<ValueTask<Result>> action)
    {
        if (operationResult.IsSuccess)
        {
            return await action();
        }

        if (operationResult.Exception is null)
        {
            return new OperationResultException("Exception is null");
        }

        return operationResult.Exception;
    }

    /// <summary>
    /// Executes the provided action if the operation result is successful.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="Result"></typeparam>
    /// <param name="operationResult"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static async ValueTask<ValueOperationResult<Result>> OnSuccessAsync<T, Result>(this ValueOperationResult<T> operationResult, Func<T, ValueTask<ValueOperationResult<Result>>> action)
    {
        if (operationResult.IsSuccess)
        {
            return await action(operationResult.Data);
        }

        if (operationResult.Exception is null)
        {
            return new OperationResultException("Exception is null");
        }

        return operationResult.Exception;
    }

    public static async ValueTask<ValueOperationResult> OnSuccessAsync<T>(this ValueOperationResult<T> operationResult, Func<T, ValueTask<ValueOperationResult>> action)
    {
        if (operationResult.IsSuccess)
        {
            return await action(operationResult.Data);
        }

        if (operationResult.Exception is null)
        {
            return new OperationResultException("Exception is null");
        }

        return operationResult.Exception;
    }
}