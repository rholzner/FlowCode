namespace FlowCode;

public static class ValueOperationResultOnSuccessExtensions
{

    /// <summary>
    /// Executes the provided action if the operation result is successful.
    /// </summary>
    /// <typeparam name="Result"></typeparam>
    /// <param name="operationResult"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static ValueOperationResult OnSuccess(this ValueOperationResult operationResult, Func<ValueOperationResult> action)
    {
        if (operationResult.IsSuccess)
        {
            return action();
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
    public static ValueOperationResult<Result> OnSuccess<Result>(this ValueOperationResult operationResult, Func<Result> action)
    {
        if (operationResult.IsSuccess)
        {
            return action();
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
    public static ValueOperationResult<Result> OnSuccess<T, Result>(this ValueOperationResult<T> operationResult, Func<T, Result> action)
    {
        if (operationResult.IsSuccess)
        {
            return action(operationResult.Data);
        }

        if (operationResult.Exception is null)
        {
            return new OperationResultException("Exception is null");
        }

        return operationResult.Exception;
    }

    public static ValueOperationResult OnSuccess<T>(this ValueOperationResult<T> operationResult, Func<T, ValueOperationResult> action)
    {
        if (operationResult.IsSuccess)
        {
            return action(operationResult.Data);
        }

        if (operationResult.Exception is null)
        {
            return new OperationResultException("Exception is null");
        }

        return operationResult.Exception;
    }
}