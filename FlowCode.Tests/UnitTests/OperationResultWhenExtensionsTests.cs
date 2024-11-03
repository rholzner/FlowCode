namespace FlowCode.Tests.UnitTests;
public class OperationResultWhenExtensionsTests
{
    [Fact]
    public void When_ConditionIsTrue_ActionIsExecuted()
    {
        // Arrange
        var operationResult = new OperationResult();
        bool condition = true;
        bool actionExecuted = false;

        // Act
        operationResult.When(op => condition, op =>
        {
            actionExecuted = true;
        });

        // Assert
        Assert.True(actionExecuted);
    }

    [Fact]
    public void When_ConditionIsFalse_ActionIsNotExecuted()
    {
        // Arrange
        var operationResult = new OperationResult();
        bool condition = false;
        bool actionExecuted = false;

        // Act
        operationResult.When(op => condition, op =>
        {
            actionExecuted = true;
        });

        // Assert
        Assert.False(actionExecuted);
    }

    [Fact]
    public async Task WhenAsync_ConditionIsTrue_ActionIsExecuted()
    {
        // Arrange
        var operationResult = new OperationResult();
        bool condition = true;
        bool actionExecuted = false;

        // Act
        await operationResult.WhenAsync(op => condition, async op =>
        {
            await Task.Delay(100);
            actionExecuted = true;
            return op;
        });

        // Assert
        Assert.True(actionExecuted);
    }

    [Fact]
    public async Task WhenAsync_ConditionIsFalse_ActionIsNotExecuted()
    {
        // Arrange
        var operationResult = new OperationResult();
        bool condition = false;
        bool actionExecuted = false;

        // Act
        await operationResult.WhenAsync(op => condition, async op =>
        {
            await Task.Delay(100);
            actionExecuted = true;
            return op;
        });

        // Assert
        Assert.False(actionExecuted);
    }

    [Fact]
    public void When_Generic_ConditionIsTrue_ActionIsExecuted()
    {
        // Arrange
        var operationResult = new OperationResult<int>();
        bool condition = true;
        bool actionExecuted = false;

        // Act
        operationResult.When(op => condition, op =>
        {
            actionExecuted = true;
        });

        // Assert
        Assert.True(actionExecuted);
    }

    [Fact]
    public void When_Generic_ConditionIsFalse_ActionIsNotExecuted()
    {
        // Arrange
        var operationResult = new OperationResult<int>();
        bool condition = false;
        bool actionExecuted = false;

        // Act
        operationResult.When(op => condition, op =>
        {
            actionExecuted = true;
        });

        // Assert
        Assert.False(actionExecuted);
    }

    [Fact]
    public async Task WhenAsync_Generic_ConditionIsTrue_ActionIsExecuted()
    {
        // Arrange
        var operationResult = new OperationResult<int>();
        bool condition = true;
        bool actionExecuted = false;

        // Act
        await operationResult.WhenAsync(op => condition, async op =>
        {
            await Task.Delay(100);
            actionExecuted = true;
            return op;
        });

        // Assert
        Assert.True(actionExecuted);
    }

    [Fact]
    public async Task WhenAsync_Generic_ConditionIsFalse_ActionIsNotExecuted()
    {
        // Arrange
        var operationResult = new OperationResult<int>();
        bool condition = false;
        bool actionExecuted = false;

        // Act
        await operationResult.WhenAsync(op => condition, async op =>
        {
            await Task.Delay(100);
            actionExecuted = true;
            return op;
        });

        // Assert
        Assert.False(actionExecuted);
    }











    [Fact]
    public void Value_When_ConditionIsTrue_ActionIsExecuted()
    {
        // Arrange
        var operationResult = new ValueOperationResult();
        bool condition = true;
        bool actionExecuted = false;

        // Act
        operationResult.When(op => condition, op =>
        {
            actionExecuted = true;
        });

        // Assert
        Assert.True(actionExecuted);
    }

    [Fact]
    public void Value_When_ConditionIsFalse_ActionIsNotExecuted()
    {
        // Arrange
        var operationResult = new ValueOperationResult();
        bool condition = false;
        bool actionExecuted = false;

        // Act
        operationResult.When(op => condition, op =>
        {
            actionExecuted = true;
        });

        // Assert
        Assert.False(actionExecuted);
    }

    [Fact]
    public async Task Value_WhenAsync_ConditionIsTrue_ActionIsExecuted()
    {
        // Arrange
        var operationResult = new ValueOperationResult();
        bool condition = true;
        bool actionExecuted = false;

        // Act
        await operationResult.WhenAsync(op => condition, async op =>
        {
            await Task.Delay(100);
            actionExecuted = true;
            return op;
        });

        // Assert
        Assert.True(actionExecuted);
    }

    [Fact]
    public async Task Value_WhenAsync_ConditionIsFalse_ActionIsNotExecuted()
    {
        // Arrange
        var operationResult = new ValueOperationResult();
        bool condition = false;
        bool actionExecuted = false;

        // Act
        await operationResult.WhenAsync(op => condition, async op =>
        {
            await Task.Delay(100);
            actionExecuted = true;
            return op;
        });

        // Assert
        Assert.False(actionExecuted);
    }

    [Fact]
    public void Value_When_Generic_ConditionIsTrue_ActionIsExecuted()
    {
        // Arrange
        var operationResult = new ValueOperationResult<int>();
        bool condition = true;
        bool actionExecuted = false;

        // Act
        operationResult.When(op => condition, op =>
        {
            actionExecuted = true;
        });

        // Assert
        Assert.True(actionExecuted);
    }

    [Fact]
    public void Value_When_Generic_ConditionIsFalse_ActionIsNotExecuted()
    {
        // Arrange
        var operationResult = new ValueOperationResult<int>();
        bool condition = false;
        bool actionExecuted = false;

        // Act
        operationResult.When(op => condition, op =>
        {
            actionExecuted = true;
        });

        // Assert
        Assert.False(actionExecuted);
    }

    [Fact]
    public async Task Value_WhenAsync_Generic_ConditionIsTrue_ActionIsExecuted()
    {
        // Arrange
        var operationResult = new ValueOperationResult<int>();
        bool condition = true;
        bool actionExecuted = false;

        // Act
        await operationResult.WhenAsync(op => condition, async op =>
        {
            await Task.Delay(100);
            actionExecuted = true;
            return op;
        });

        // Assert
        Assert.True(actionExecuted);
    }

    [Fact]
    public async Task Value_WhenAsync_Generic_ConditionIsFalse_ActionIsNotExecuted()
    {
        // Arrange
        var operationResult = new ValueOperationResult<int>();
        bool condition = false;
        bool actionExecuted = false;

        // Act
        await operationResult.WhenAsync(op => condition, async op =>
        {
            await Task.Delay(100);
            actionExecuted = true;
            return op;
        });

        // Assert
        Assert.False(actionExecuted);
    }
}
