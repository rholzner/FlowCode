namespace FlowCode.Tests;

public class OperationResultConvertAsyncExtensions
{
    [Fact]
    public async Task ConvertAsync_SuccessWithData_ReturnsSuccessResult()
    {
        // Arrange
        var operationResult = new OperationResult<int>(42);
        Func<int, string> success = data => $"Success: {data}";
        Func<Exception, string> error = ex => $"Error: {ex.Message}";

        // Act
        var result = await operationResult.ConvertAsync(success, error);

        // Assert
        Assert.Equal("Success: 42", result);
    }

    [Fact]
    public async Task ConvertAsync_SuccessWithNullData_ReturnsErrorResult()
    {
        // Arrange
        var operationResult = new OperationResult<string>();
        Func<string, string> success = data => $"Success: {data}";
        Func<Exception, string> error = ex => $"Error: {ex.Message}";

        // Act
        var result = await operationResult.ConvertAsync(success, error);

        // Assert
        Assert.Equal("Error: Exception is null", result);
    }

    [Fact]
    public async Task ConvertAsync_FailureWithException_ReturnsErrorResult()
    {
        // Arrange
        var exception = new InvalidOperationException("Something went wrong");
        var operationResult = new OperationResult<int>(exception);
        Func<int, string> success = data => $"Success: {data}";
        Func<Exception, string> error = ex => $"Error: {ex.Message}";

        // Act
        var result = await operationResult.ConvertAsync(success, error);

        // Assert
        Assert.Equal("Error: Something went wrong", result);
    }

    [Fact]
    public async Task ConvertAsync_FailureWithNullException_ReturnsErrorResult()
    {
        // Arrange
        var operationResult = new OperationResult<int>(null);
        Func<int, string> success = data => $"Success: {data}";
        Func<Exception, string> error = ex => $"Error: {ex.Message}";

        // Act
        var result = await operationResult.ConvertAsync(success, error);

        // Assert
        Assert.Equal("Error: Exception is null", result);
    }
}
