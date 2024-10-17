namespace FlowCode.Tests;

public class OperationResultOnSuccessAsyncExtensionsTests
{
    [Fact]
    public async Task OnSuccessAsync_WithSuccessfulOperationResult_CallsAction()
    {
        // Arrange
        var operationResult = OperationResult.Success();
        bool actionCalled = false;

        // Act
        await operationResult.OnSuccessAsync(() =>
        {
            actionCalled = true;
            return ValueTask.CompletedTask;
        });

        // Assert
        Assert.True(actionCalled);
    }

    [Fact]
    public async Task OnSuccessAsync_WithFailedOperationResult_DoesNotCallAction()
    {
        // Arrange
        var operationResult = OperationResult.Failure(new Exception());
        bool actionCalled = false;

        // Act
        await operationResult.OnSuccessAsync(() =>
        {
            actionCalled = true;
            return ValueTask.CompletedTask;
        });

        // Assert
        Assert.False(actionCalled);
    }

    [Fact]
    public async Task OnSuccessAsync_WithSuccessfulOperationResultWithData_CallsActionWithData()
    {
        // Arrange
        var data = "test";
        var operationResult = OperationResult.Success(data);
        string resultData = null;

        // Act
        await operationResult.OnSuccessAsync(d =>
        {
            resultData = d;
            return ValueTask.CompletedTask;
        });

        // Assert
        Assert.Equal(data, resultData);
    }

    [Fact]
    public async Task OnSuccessAsync_WithFailedOperationResultWithData_DoesNotCallAction()
    {
        // Arrange
        var operationResult = OperationResult.Failure<string>(new Exception());
        bool actionCalled = false;

        // Act
        await operationResult.OnSuccessAsync(d =>
        {
            actionCalled = true;
            return ValueTask.CompletedTask;
        });

        // Assert
        Assert.False(actionCalled);
    }

    [Fact]
    public async Task OnSuccessAsync_WithSuccessfulOperationResultAndResultType_CallsActionAndReturnsResult()
    {
        // Arrange
        var operationResult = OperationResult.Success();
        bool actionCalled = false;

        // Act
        var result = await operationResult.OnSuccessAsync(async () =>
        {
            actionCalled = true;
            return 42;
        });

        // Assert
        Assert.True(actionCalled);
        Assert.Equal(42, result);
    }

    [Fact]
    public async Task OnSuccessAsync_WithFailedOperationResultAndResultType_ReturnsException()
    {
        // Arrange
        var error = new Exception();
        var operationResult = OperationResult.Failure(error);
        var exception = error;

        // Act
        var result = await operationResult.OnSuccessAsync(() =>
        {
            return ValueTask.FromResult(42);
        });

        // Assert
        Assert.Equal(result.Exception,exception);
    }

    [Fact]
    public async Task OnSuccessAsync_WithSuccessfulOperationResultWithDataAndResultType_CallsActionWithDataAndReturnsResult()
    {
        // Arrange
        var data = "test";
        var operationResult = OperationResult.Success(data);
        string resultData = null;

        // Act
        var result = await operationResult.OnSuccessAsync(d =>
        {
            resultData = d;
            return ValueTask.FromResult(42);
        });

        // Assert
        Assert.Equal(data, resultData);
        Assert.Equal(42, result);
    }

    [Fact]
    public async Task OnSuccessAsync_WithFailedOperationResultWithDataAndResultType_ReturnsException()
    {
        // Arrange
        var error = new Exception();
        var operationResult = OperationResult.Failure<string>(error);
        var exception = error;

        // Act
        var result = await operationResult.OnSuccessAsync(d =>
        {
            return ValueTask.FromResult(42);
        });

        // Assert
        Assert.Equal(exception.Message, result.Exception?.Message);
    }
}
