using FlowCode;
using Microsoft.AspNetCore.Mvc;

namespace FlowCode.Application.NetCore;

public static class OperationResultConvertToActionOfTExtensions
{
    /// <summary>
    /// Converts an <see cref="OperationResult"/> to a <see cref="ActionResult"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="operationResult"></param>
    /// <returns></returns>
    public static ActionResult<T> ToAction<T>(this OperationResult<T> operationResult)
    {
        if (operationResult.IsSuccess)
        {
            return new OkObjectResult(operationResult.Data); ;
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
    /// <param name="showErrorMessage"></param>
    /// <returns></returns>
    public static ActionResult<T> ToAction<T>(this OperationResult<T> operationResult, bool showErrorMessage)
    {
        if (operationResult.IsSuccess)
        {
            return new OkObjectResult(operationResult.Data); ;
        }
        if (operationResult.Exception is null)
        {
            return new BadRequestObjectResult("Exception is null");
        }
        if (showErrorMessage)
        {
            return new BadRequestObjectResult(operationResult.Exception.Message);
        }
        return new BadRequestObjectResult("An error occurred");
    }
    /// <summary>
    /// Converts an <see cref="OperationResult"/> to a <see cref="ActionResult"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="operationResult"></param>
    /// <param name="success"></param>
    /// <returns></returns>
    public static ActionResult<T> ToAction<T>(this OperationResult<T> operationResult, Func<T, ActionResult<T>> success)
    {
        if (operationResult.IsSuccess)
        {
            return success(operationResult.Data);
        }

        if (operationResult.Exception is null)
        {
            return new BadRequestResult();
        }
        return new BadRequestObjectResult(operationResult.Exception.Message);
    }

    public static ActionResult<T> ToAction<T>(this OperationResult<T> operationResult, Func<T, ActionResult<T>> success, bool showErrorMessage)
    {
        if (operationResult.IsSuccess)
        {
            return success(operationResult.Data);
        }

        if (operationResult.Exception is null)
        {
            return new BadRequestResult();
        }

        if (showErrorMessage)
        {
            return new BadRequestObjectResult(operationResult.Exception.Message);
        }
        return new BadRequestObjectResult("An error occurred");
    }

    /// <summary>
    /// Converts an <see cref="OperationResult"/> to a <see cref="ActionResult"/> using the provided functions.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="operationResult"></param>
    /// <param name="error"></param>
    /// <returns></returns>
    public static ActionResult<T> ToAction<T>(this OperationResult<T> operationResult, Func<Exception, ActionResult> error)
    {
        if (operationResult.IsSuccess)
        {
            return new OkObjectResult(operationResult.Data); ;
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
    /// <typeparam name="T"></typeparam>
    /// <param name="operationResult"></param>
    /// <param name="error"></param>
    /// <returns></returns>
    public static ActionResult<T> ToAction<T>(this OperationResult<T> operationResult, Func<Exception, ActionResult<T>> error)
    {
        if (operationResult.IsSuccess)
        {
            return new OkObjectResult(operationResult.Data); ;
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
    /// <summary>
    /// Converts an <see cref="OperationResult{T}"/> to a <see cref="Result"/> using the provided functions.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="operationResult"></param>
    /// <param name="success"></param>
    /// <param name="error"></param>
    /// <returns></returns>
    public static ActionResult<T> ToAction<T>(this OperationResult<T> operationResult, Func<T, ActionResult<T>> success, Func<Exception, ActionResult<T>> error)
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


    /// <summary>
    /// Converts an <see cref="OperationResult{T}"/> to a <see cref="IActionResult"/> using the provided functions.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="operationResult"></param>
    /// <param name="success"></param>
    /// <param name="error"></param>
    /// <returns></returns>
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
