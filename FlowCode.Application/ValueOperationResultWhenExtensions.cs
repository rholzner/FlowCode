namespace FlowCode;

public static class ValueOperationResultWhenExtensions
{
    public static ValueOperationResult When(this ValueOperationResult operationResult, Func<ValueOperationResult, bool> condition, Action<ValueOperationResult> action)
    {
        if (condition(operationResult))
        {
            action(operationResult);
        }
        return operationResult;
    }

    public static ValueTask<ValueOperationResult> WhenAsync(this ValueOperationResult operationResult, Func<ValueOperationResult, bool> condition, Func<ValueOperationResult, ValueTask<ValueOperationResult>> action)
    {
        if (condition(operationResult))
        {
            return action(operationResult);
        }
        return ValueTask.FromResult(operationResult);
    }

    public static ValueOperationResult<T> When<T>(this ValueOperationResult<T> operationResult, Func<ValueOperationResult<T>, bool> condition, Action<ValueOperationResult<T>> action)
    {
        if (condition(operationResult))
        {
            action(operationResult);
        }
        return operationResult;
    }

    public static ValueTask<ValueOperationResult<T>> WhenAsync<T>(this ValueOperationResult<T> operationResult, Func<ValueOperationResult<T>, bool> condition, Func<ValueOperationResult<T>, ValueTask<ValueOperationResult<T>>> action)
    {
        if (condition(operationResult))
        {
            return action(operationResult);
        }
        return ValueTask.FromResult(operationResult);
    }
}
