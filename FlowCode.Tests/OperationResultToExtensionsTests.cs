namespace FlowCode.Tests;
public class OperationResultToExtensionsTests
{
    [Fact]
    public void To_ReturnsSuccessResult_WhenOperationResultIsSuccess()
    {
        // Arrange
        var data = "Test Data";
        var operationResult = new OperationResult<string>(data);
        Func<string, int> success = str => str.Length;
        Func<Exception, Exception> error = ex => ex;

        // Act
        var result = operationResult.To(success, error);

        // Assert
        Assert.Equal(data.Length, result.Data);
    }

    [Fact]
    public void To_ReturnsErrorResult_WhenOperationResultDataIsNull()
    {
        // Arrange
        var operationResult = new OperationResult<string>();
        Func<string, int> success = str => str.Length;
        Func<Exception, Exception> error = ex => ex;

        // Act
        var result = operationResult.To(success, error);

        // Assert
        Assert.Equal("Exception is null", result.Exception.Message);
    }

    [Fact]
    public void To_ReturnsErrorResult_WhenOperationResultExceptionIsNull()
    {
        // Arrange

        var ex = new Exception("test");

        var operationResult = new OperationResult<string>(ex);
        Func<string, int> success = str => str.Length;
        Func<Exception, Exception> error = ex => ex;

        // Act
        var result = operationResult.To(success, error);

        // Assert
        Assert.Equal("test", result.Exception.Message);
    }
}