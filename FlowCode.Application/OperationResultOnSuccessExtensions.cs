namespace FlowCode;

public static class OperationResultOnSuccessExtensions
{
    public static OperationResult<T> OnSuccess<T>(this OperationResult<T> operationResult, Action<T> action)
    {
        if (operationResult.IsSuccess)
        {
            action(operationResult.Data);
        }
        return operationResult;
    }

    public static OperationResult OnSuccess(this OperationResult operationResult, Action action)
    {
        if (operationResult.IsSuccess)
        {
            action();
        }
        return operationResult;
    }
}
