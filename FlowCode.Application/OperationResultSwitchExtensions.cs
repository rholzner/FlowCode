﻿namespace FlowCode;

public static class OperationResultSwitchExtensions
{
    /// <summary>
    /// Executes the provided action if the operation result is successful.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="operationResult"></param>
    /// <param name="success"></param>
    /// <param name="error"></param>
    public static void Switch<T>(this OperationResult<T> operationResult, Action<T> success, Action<Exception> error)
    {
        if (operationResult.IsSuccess)
        {
            if (operationResult.Data is null)
            {
                error(new OperationResultException("Data is null"));
                return;
            }

            success(operationResult.Data);
        }
        else
        {
            if (operationResult.Exception is null)
            {
                error(new OperationResultException("Exception is null"));
                return;
            }

            error(operationResult.Exception);
        }
    }
    /// <summary>
    /// Executes the provided action if the operation result is successful.
    /// </summary>
    /// <param name="operationResult"></param>
    /// <param name="success"></param>
    /// <param name="error"></param>
    public static void Switch(this OperationResult operationResult, Action success, Action<Exception> error)
    {
        if (operationResult.IsSuccess)
        {
            success();
        }
        else
        {
            if (operationResult.Exception is null)
            {
                error(new OperationResultException("Exception is null"));
                return;
            }
            error(operationResult.Exception);
        }
    }
}