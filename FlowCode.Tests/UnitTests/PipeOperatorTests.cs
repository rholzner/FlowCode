namespace FlowCode.Tests.UnitTests;

public class PipeOperatorTests
{
    [Fact]
    public void Operator_Or_ReturnsLeftResult_WhenLeftIsSuccess()
    {
        // Arrange
        var leftResult = OperationResult.Success(42);
        var rightResult = OperationResult.Failure<int>(new Exception("Error"));

        // Act
        var result = leftResult | rightResult;

        // Assert
        Assert.Equal(leftResult, result);
    }

    [Fact]
    public void Operator_Or_ReturnsRightResult_WhenLeftIsFailure()
    {
        // Arrange
        var leftResult = OperationResult.Failure<int>(new Exception("Error"));
        var rightResult = OperationResult.Success(42);

        // Act
        var result = leftResult | rightResult;

        // Assert
        Assert.Equal(rightResult, result);
    }






    [Fact]
    public void Value_Operator_Or_ReturnsLeftResult_WhenLeftIsSuccess()
    {
        // Arrange
        var leftResult = ValueOperationResult.Success(42);
        var rightResult = ValueOperationResult.Failure<int>(new Exception("Error"));

        // Act
        var result = leftResult | rightResult;

        // Assert
        Assert.Equal(leftResult, result);
    }

    [Fact]
    public void Value_Operator_Or_ReturnsRightResult_WhenLeftIsFailure()
    {
        // Arrange
        var leftResult = ValueOperationResult.Failure<int>(new Exception("Error"));
        var rightResult = ValueOperationResult.Success(42);

        // Act
        var result = leftResult | rightResult;

        // Assert
        Assert.Equal(rightResult, result);
    }
}
