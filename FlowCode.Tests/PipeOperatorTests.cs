
namespace FlowCode.Tests;

public class PipeOperatorTests
{
    [Fact]
    public void Operator_Or_ReturnsLeftResult_WhenLeftIsSuccess()
    {
        // Arrange
        var leftResult = OperationResult.Success<int>(42);
        var rightResult = OperationResult.Failure<int>(new System.Exception("Error"));

        // Act
        var result = leftResult | rightResult;

        // Assert
        Assert.Equal(leftResult, result);
    }

    [Fact]
    public void Operator_Or_ReturnsRightResult_WhenLeftIsFailure()
    {
        // Arrange
        var leftResult = OperationResult.Failure<int>(new System.Exception("Error"));
        var rightResult = OperationResult.Success<int>(42);

        // Act
        var result = leftResult | rightResult;

        // Assert
        Assert.Equal(rightResult, result);
    }
}
