using FlowCode.Application.NetCore;
using Microsoft.AspNetCore.Mvc;

namespace FlowCode.Tests;

public class OperationResultConvertToActionExtensionsTests
{
    [Fact]
    public void ToAction_Returns_OkObjectResult_When_OperationResult_Is_Successful()
    {
        // Arrange
        var operationResult = new OperationResult();

        // Act
        var result = operationResult.ToAction();

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void ToAction_Returns_BadRequestObjectResult_With_Exception_Message_When_OperationResult_Is_Not_Successful_And_Exception_Is_Null()
    {
        // Arrange
        var text = "test";
        OperationResult operationResult = new Exception(text);

        // Act
        var result = operationResult.ToAction();

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(text, badRequestResult.Value);
    }

    [Fact]
    public void ToAction_Returns_BadRequestObjectResult_With_Exception_Message_When_OperationResult_Is_Not_Successful_And_Exception_Is_Not_Null()
    {
        // Arrange
        var exceptionMessage = "Test Exception";
        var operationResult = new OperationResult(new OperationResultException(exceptionMessage));

        // Act
        var result = operationResult.ToAction();

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(exceptionMessage, badRequestResult.Value);
    }

    [Fact]
    public void ToAction_With_Success_Function_Returns_BadRequestResult_When_OperationResult_Is_Not_Successful_And_Exception_Is_Null()
    {
        // Arrange
        OperationResult operationResult = new Exception();

        // Act
        var result = operationResult.ToAction(data => new BadRequestResult());

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public void ToAction_With_Success_Function_Returns_BadRequestObjectResult_With_Exception_Message_When_OperationResult_Is_Not_Successful_And_Exception_Is_Not_Null()
    {
        // Arrange
        var exceptionMessage = "Test Exception";
        var operationResult = new OperationResult(new OperationResultException(exceptionMessage));

        // Act
        var result = operationResult.ToAction(data => new BadRequestObjectResult(data));

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public void ToAction_With_Error_Function_Returns_OkObjectResult_When_OperationResult_Is_Successful()
    {
        // Arrange
        var operationResult = new OperationResult();

        // Act
        var result = operationResult.ToAction(ex => new OkObjectResult("Success"));

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void ToAction_With_Error_Function_Returns_Error_Function_Result_When_OperationResult_Is_Not_Successful_And_Exception_Is_Null()
    {
        // Arrange
        OperationResult operationResult = new Exception();

        // Act
        var result = operationResult.ToAction(ex => new BadRequestResult());

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public void ToAction_With_Error_Function_Returns_Error_Function_Result_When_OperationResult_Is_Not_Successful_And_Exception_Is_Not_Null()
    {
        // Arrange
        var exceptionMessage = "Test Exception";
        var operationResult = new OperationResult(new OperationResultException(exceptionMessage));
        var expectedResult = new BadRequestObjectResult(exceptionMessage);

        // Act
        var result = operationResult.ToAction(ex => expectedResult);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ToAction_With_Success_And_Error_Functions_Returns_Success_Function_Result_When_OperationResult_Is_Successful_And_Data_Is_Not_Null()
    {
        // Arrange
        var operationResult = new OperationResult<string>("Success");
        var expectedResult = new OkObjectResult("Success");

        // Act
        var result = operationResult.ToAction(() => expectedResult, ex => new BadRequestObjectResult(ex.Message));

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ToAction_With_Success_And_Error_Functions_Returns_BadRequestObjectResult_With_Exception_Message_When_OperationResult_Is_Successful_And_Data_Is_Null()
    {
        // Arrange
        var operationResult = new OperationResult<string>();
        var expectedResult = new BadRequestObjectResult("Data is null");

        // Act
        var result = operationResult.ToAction(() => new OkResult(), ex => expectedResult);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ToAction_With_Success_And_Error_Functions_Returns_BadRequestObjectResult_With_Exception_Message_When_OperationResult_Is_Not_Successful_And_Exception_Is_Null()
    {
        // Arrange
        var operationResult = new OperationResult<string>("Success");

        // Act
        var result = operationResult.ToAction(
            () => new OkResult(),
            ex => new BadRequestObjectResult(ex.Message));

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void ToAction_With_Success_And_Error_Functions_Returns_Error_Function_Result_When_OperationResult_Is_Not_Successful_And_Exception_Is_Not_Null()
    {
        // Arrange
        var exceptionMessage = "Test Exception";
        var operationResult = new OperationResult<string>(new OperationResultException(exceptionMessage));
        var expectedResult = new BadRequestObjectResult(exceptionMessage);

        // Act
        var result = operationResult.ToAction(() => new OkResult(), ex => expectedResult);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ToAction_With_Success_And_Error_Functions_Returns_Success_Function_Result_When_OperationResult_Is_Successful_And_Data_Is_Not_Null_Using_IActionResult()
    {
        // Arrange
        var operationResult = new OperationResult<string>("Success");
        var expectedResult = new OkObjectResult("Success");

        // Act
        var result = operationResult.ToAction(() => expectedResult, ex => new BadRequestObjectResult(ex.Message));

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ToAction_With_Success_And_Error_Functions_Returns_BadRequestObjectResult_With_Exception_Message_When_OperationResult_Is_Successful_And_Data_Is_Null_Using_IActionResult()
    {
        // Arrange
        var operationResult = new OperationResult<string>();
        var expectedResult = new BadRequestObjectResult("Data is null");

        // Act
        var result = operationResult.ToAction(() => new OkResult(), ex => expectedResult);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ToAction_With_Success_And_Error_Functions_Returns_BadRequestObjectResult_With_Exception_Message_When_OperationResult_Is_Not_Successful_And_Exception_Is_Null_Using_IActionResult()
    {
        // Arrange
        var operationResult = new OperationResult<string>("Success");

        // Act
        var result = operationResult.ToAction(
            () => new OkResult(),
            ex => new BadRequestObjectResult(ex.Message));

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void ToAction_With_Success_And_Error_Functions_Returns_Error_Function_Result_When_OperationResult_Is_Not_Successful_And_Exception_Is_Not_Null_Using_IActionResult()
    {
        // Arrange
        var exceptionMessage = "Test Exception";
        var operationResult = new OperationResult<string>(new OperationResultException(exceptionMessage));
        var expectedResult = new BadRequestObjectResult(exceptionMessage);

        // Act
        var result = operationResult.ToAction(() => new OkResult(), ex => expectedResult);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}
