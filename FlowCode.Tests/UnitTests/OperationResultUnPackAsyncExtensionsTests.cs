namespace FlowCode.Tests.UnitTests;

public class OperationResultUnPackAsyncExtensionsTests
{
    [Fact]
    public async Task UnPackAsync_Success_ReturnsResult()
    {
        // Arrange
        var operationResult = new OperationResult();
        var expectedResult = new Result();

        // Act
        var result = await operationResult.UnPackAsync(() => ValueTask.FromResult(expectedResult), _ => throw new Exception());

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public async Task UnPackAsync_FailureWithException_ReturnsErrorResult()
    {
        // Arrange
        var operationResult = new OperationResult { Exception = new Exception("Test Exception") };

        var error = new Result();

        // Act
        var result = await operationResult.UnPackAsync(() => throw new Exception(), ex => ValueTask.FromResult(error));

        // Assert
        Assert.Equal(result, error);
    }

    

    [Fact]
    public void UnPack_Success_ReturnsResult()
    {
        // Arrange
        var operationResult = new OperationResult();
        var expectedResult = new Result();

        // Act
        var result = operationResult.UnPack(() => expectedResult, _ => throw new Exception());

        // Assert
        Assert.Equal(expectedResult, result);
    }
}

public class Result { }
