﻿namespace FlowCode;

public static class OperationResultOnSuccessAsyncExtensions
{
    /// <summary>
    /// Executes the provided action if the operation result is successful.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="operationResult"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static async ValueTask<OperationResult<T>> OnSuccessAsync<T>(this OperationResult<T> operationResult, Func<T, ValueTask> action)
    {
        if (operationResult.IsSuccess)
        {
            await action(operationResult.Data);
        }
        return operationResult;
    }

    /// <summary>
    /// Executes the provided action if the operation result is successful.
    /// </summary>
    /// <param name="operationResult"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static async ValueTask<OperationResult> OnSuccessAsync(this OperationResult operationResult, Func<ValueTask> action)
    {
        if (operationResult.IsSuccess)
        {
            await action();
        }
        return operationResult;
    }

    /// <summary>
    /// Executes the provided action if the operation result is successful.
    /// </summary>
    /// <typeparam name="Result"></typeparam>
    /// <param name="operationResult"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static async ValueTask<OperationResult<Result>> OnSuccessAsync<Result>(this OperationResult operationResult, Func<ValueTask<Result>> action)
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
    public static async ValueTask<OperationResult<Result>> OnSuccessAsync<T, Result>(this OperationResult<T> operationResult, Func<T, ValueTask<Result>> action)
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
