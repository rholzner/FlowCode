namespace FlowCode.Tests.UnitTests;

public class OperationResultOnErrorExtensionsTests2
{

    [Fact]
    public void OnError_WithException_ReturnsNewOperationResult()
    {
        // Arrange
        var operationResult = new OperationResult<int>(new Exception("Test Exception"));

        // Act
        var result = operationResult.OnError(ex =>
        {
            return 0;
        });

        // Assert
        Assert.IsType<OperationResult<int>>(result);
        Assert.Equal(0, result.Data);
    }

    [Fact]
    public void OnError_WithoutException_ReturnsOriginalOperationResult()
    {
        // Arrange
        var operationResult = new OperationResult<int>(42);

        // Act
        var result = operationResult.OnError(ex =>
        {
            return 0;
        });

        // Assert
        Assert.Equal(operationResult, result);
    }





    [Fact]
    public void Value_OnError_WithException_ReturnsNewOperationResult()
    {
        // Arrange
        var operationResult = new ValueOperationResult<int>(new Exception("Test Exception"));

        // Act
        var result = operationResult.OnError(ex =>
        {
            return 0;
        });

        // Assert
        Assert.IsType<ValueOperationResult<int>>(result);
        Assert.Equal(0, result.Data);
    }

    [Fact]
    public void Value_OnError_WithoutException_ReturnsOriginalOperationResult()
    {
        // Arrange
        var operationResult = new ValueOperationResult<int>(42);

        // Act
        var result = operationResult.OnError(ex =>
        {
            return 0;
        });

        // Assert
        Assert.Equal(operationResult, result);
    }
}
