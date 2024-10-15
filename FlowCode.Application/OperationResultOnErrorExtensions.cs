namespace FlowCode;

public static class OperationResultOnErrorExtensions
{
    /// <summary>
    /// Executes the provided action if the operation result is not successful.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="operationResult"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static OperationResult<T> OnError<T>(this OperationResult<T> operationResult, Action<Exception> action)
    {
        if (!operationResult.IsSuccess)
        {
            if (operationResult.Exception is null)
            {
                return new OperationResultException("Exception is null");
            }
            action(operationResult.Exception);
        }
        return operationResult;
    }

    /// <summary>
    /// Executes the provided action if the operation result is not successful.
    /// </summary>
    /// <param name="operationResult"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static OperationResult OnError(this OperationResult operationResult, Action<Exception> action)
    {
        if (!operationResult.IsSuccess)
        {
            if (operationResult.Exception is null)
            {
                return new OperationResultException("Exception is null");
            }

            action(operationResult.Exception);
        }
        return operationResult;
    }
}
