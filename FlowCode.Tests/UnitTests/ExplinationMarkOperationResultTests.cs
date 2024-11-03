namespace FlowCode.Tests.UnitTests;
public class ExplinationMarkOperationResultTests
{
    [Fact]
    public void Operator_Not_Success_Returns_False()
    {
        // Arrange
        var operation = new OperationResult();

        // Act
        bool result = !operation;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Value_Operator_Not_Success_Returns_False()
    {
        // Arrange
        var operation = new ValueOperationResult();

        // Act
        bool result = !operation;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void int_Operator_Not_Success_Returns_True()
    {
        // Arrange
        var operation = new OperationResult<int>();

        // Act
        bool result = !operation;

        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void Value_int_Operator_Not_Success_Returns_True()
    {
        // Arrange
        var operation = new ValueOperationResult<int>();

        // Act
        bool result = !operation;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Operator_Not_Failure_Returns_True()
    {
        // Arrange
        var exception = new Exception();
        var operation = new OperationResult(exception);

        // Act
        bool result = !operation;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Value_Operator_Not_Failure_Returns_True()
    {
        // Arrange
        var exception = new Exception();
        var operation = new ValueOperationResult(exception);

        // Act
        bool result = !operation;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void int_Operator_Not_Failure_Returns_True()
    {
        // Arrange
        var exception = new Exception();
        var operation = new OperationResult<int>(exception);

        // Act
        bool result = !operation;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Value_int_Operator_Not_Failure_Returns_True()
    {
        // Arrange
        var exception = new Exception();
        var operation = new ValueOperationResult<int>(exception);

        // Act
        bool result = !operation;

        // Assert
        Assert.True(result);
    }
}
