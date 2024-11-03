using Microsoft.AspNetCore.Mvc;

namespace FlowCode.Application.NetCore;

public static class OperationResultConvertToActionExtensions
{
    /// <summary>
    /// Converts an <see cref="OperationResult"/> to a <see cref="ActionResult"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="operationResult"></param>
    /// <returns></returns>
    public static ActionResult ToAction(this IOperationResult operationResult)
    {
        if (operationResult.IsSuccess)
        {
            return new OkResult();
        }
        if (operationResult.Exception is null)
        {
            return new BadRequestObjectResult("Exception is null");
        }
        return new BadRequestObjectResult(operationResult.Exception.Message);
    }
    /// <summary>
    /// Converts an <see cref="OperationResult"/> to a <see cref="ActionResult"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="operationResult"></param>
    /// <param name="success"></param>
    /// <returns></returns>
    public static ActionResult ToAction(this IOperationResult operationResult, Func<ActionResult> success)
    {
        if (operationResult.IsSuccess)
        {
            return success();
        }

        if (operationResult.Exception is null)
        {
            return new BadRequestResult();
        }
        return new BadRequestObjectResult(operationResult.Exception.Message);
    }

    /// <summary>
    /// Converts an <see cref="OperationResult"/> to a <see cref="ActionResult"/> using the provided functions.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="operationResult"></param>
    /// <param name="error"></param>
    /// <returns></returns>
    public static ActionResult ToAction(this IOperationResult operationResult, Func<Exception, ActionResult> error)
    {
        if (operationResult.IsSuccess)
        {
            return new OkObjectResult(operationResult); ;
        }
        if (operationResult.Exception is null)
        {
            return error(new OperationResultException("Exception is null"));
        }
        return error(operationResult.Exception);
    }

    /// <summary>
    /// Converts an <see cref="OperationResult{T}"/> to a <see cref="Result"/> using the provided functions.
    /// </summary>
    /// <typeparam name="Result"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <param name="operationResult"></param>
    /// <param name="success"></param>
    /// <param name="error"></param>
    /// <returns></returns>
    public static ActionResult ToAction(this IOperationResult operationResult, Func<ActionResult> success, Func<Exception, ActionResult> error)
    {
        if (operationResult.IsSuccess)
        {
            return success();
        }

        if (operationResult.Exception is null)
        {
            return error(new OperationResultException("Exception is null"));
        }

        return error(operationResult.Exception);
    }

    /// <summary>
    /// Converts an <see cref="OperationResult{T}"/> to a <see cref="IActionResult"/> using the provided functions.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="operationResult"></param>
    /// <param name="success"></param>
    /// <param name="error"></param>
    /// <returns></returns>
    public static IActionResult ToAction(this IOperationResult operationResult, Func<IActionResult> success, Func<Exception, IActionResult> error)
    {
        if (operationResult.IsSuccess)
        {
            return success();
        }

        if (operationResult.Exception is null)
        {
            return error(new OperationResultException("Exception is null"));
        }

        return error(operationResult.Exception);
    }
}
