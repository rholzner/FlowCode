using FlowCode;
using Microsoft.AspNetCore.Mvc;

namespace BSK.Optimizely.Site.Infrastructure.FlowCode;

public static class OperationResultConvertToActionExtensions
{
    /// <summary>
    /// Converts an <see cref="OperationResult{T}"/> to a <see cref="Result"/> using the provided functions.
    /// </summary>
    /// <typeparam name="Result"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <param name="operationResult"></param>
    /// <param name="success"></param>
    /// <param name="error"></param>
    /// <returns></returns>
    public static ActionResult ToAction<T>(this OperationResult<T> operationResult, Func<T, ActionResult> success, Func<Exception, ActionResult> error)
    {
        if (operationResult.IsSuccess)
        {
            if (operationResult.Data is null)
            {
                return error(new OperationResultException("Data is null"));
            }

            return success(operationResult.Data);
        }

        if (operationResult.Exception is null)
        {
            return error(new OperationResultException("Exception is null"));
        }

        return error(operationResult.Exception);
    }

    public static IActionResult ToAction<T>(this OperationResult<T> operationResult, Func<T, IActionResult> success, Func<Exception, IActionResult> error)
    {
        if (operationResult.IsSuccess)
        {
            if (operationResult.Data is null)
            {
                return error(new OperationResultException("Data is null"));
            }

            return success(operationResult.Data);
        }

        if (operationResult.Exception is null)
        {
            return error(new OperationResultException("Exception is null"));
        }

        return error(operationResult.Exception);
    }
}

