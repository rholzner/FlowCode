namespace FlowCode.Tests.UnitTests;

public class OperationResultConvertExtensionsTests
{
    [Fact]
    public void Convert_SuccessfulOperationResult_ReturnsSuccessResult()
    {
        // Arrange
        var operationResult = new OperationResult<int>(42);
        Func<int, string> success = data => $"Success: {data}";
        Func<Exception, string> error = ex => $"Error: {ex.Message}";

        // Act
        var result = operationResult.Convert(success, error);

        // Assert
        Assert.Equal("Success: 42", result);
    }

    [Fact]
    public void Convert_FailedOperationResultWithDataNull_ReturnsErrorResult()
    {
        // Arrange
        var operationResult = new OperationResult<string>();
        Func<string, string> success = data => $"Success: {data}";
        Func<Exception, string> error = ex => $"Error: {ex.Message}";

        // Act
        var result = operationResult.Convert(success, error);

        // Assert
        Assert.Equal("Error: Exception is null", result);
    }

    [Fact]
    public void Convert_FailedOperationResultWithExceptionNull_ReturnsErrorResult()
    {
        // Arrange
        var operationResult = new OperationResult<int>(new Exception());
        Func<int, string> success = data => $"Success: {data}";
        Func<Exception, string> error = ex => $"Error: {ex.Message}";

        // Act
        var result = operationResult.Convert(success, error);

        // Assert
        Assert.Equal("Error: Exception of type 'System.Exception' was thrown.", result);
    }

    [Fact]
    public void Convert_FailedOperationResultWithException_ReturnsErrorResult()
    {
        // Arrange
        var exception = new Exception("Some error");
        var operationResult = new OperationResult<int>(exception);
        Func<int, string> success = data => $"Success: {data}";
        Func<Exception, string> error = ex => $"Error: {ex.Message}";

        // Act
        var result = operationResult.Convert(success, error);

        // Assert
        Assert.Equal("Error: Some error", result);
    }
}
