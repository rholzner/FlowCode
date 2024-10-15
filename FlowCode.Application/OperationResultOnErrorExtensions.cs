namespace FlowCode;

public static class OperationResultOnErrorExtensions
{
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
