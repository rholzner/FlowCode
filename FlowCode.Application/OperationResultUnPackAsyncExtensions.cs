namespace FlowCode;

public static class OperationResultUnPackAsyncExtensions
{
    public static ValueTask<Result> UnPackAsync<Result>(this OperationResult operationResult,Func<ValueTask<Result>> Success, Func<Exception, ValueTask<Result>> error)
    {
        if (operationResult.IsSuccess)
        {
            return Success();
        }

        if (operationResult.Exception is null)
        {
            return error(new OperationResultException("Exception is null"));
        }

        return error(operationResult.Exception);
    }

    public static ValueTask<Result> UnPackAsync<Result, T>(this OperationResult<T> operationResult, Func<T, ValueTask<Result>> Success, Func<Exception, ValueTask<Result>> error)
    {
        if (operationResult.IsSuccess)
        {
            if (operationResult.Data is null)
            {
                return error(new OperationResultException("Data is null"));
            }
            return Success(operationResult.Data);
        }
        if (operationResult.Exception is null)
        {
            return error(new OperationResultException("Exception is null"));
        }
        return error(operationResult.Exception);
    }

    public static Result UnPack<Result>(this OperationResult operationResult, Func<Result> Success, Func<Exception, Result> error)
    {
        if (operationResult.IsSuccess)
        {
            return Success();
        }
        if (operationResult.Exception is null)
        {
            return error(new OperationResultException("Exception is null"));
        }
        return error(operationResult.Exception);
    }

    public static Result UnPack<Result, T>(this OperationResult<T> operationResult, Func<T, Result> Success, Func<Exception, Result> error)
    {
        if (operationResult.IsSuccess)
        {
            if (operationResult.Data is null)
            {
                return error(new OperationResultException("Data is null"));
            }
            return Success(operationResult.Data);
        }
        if (operationResult.Exception is null)
        {
            return error(new OperationResultException("Exception is null"));
        }
        return error(operationResult.Exception);
    }

}
