namespace FlowCode.Tests.UnitTests;

public class OperationResultSwitchExtensionsTests
{
    [Fact]
    public void Switch_WithSuccessfulOperationResult_CallsSuccessAction()
    {
        // Arrange
        var operationResult = new OperationResult<int>(42);

        bool successActionCalled = false;
        bool errorActionCalled = false;

        // Act
        operationResult.Switch(
            success: data =>
            {
                successActionCalled = true;
                Assert.Equal(42, data);
            },
            error: ex => errorActionCalled = true
        );

        // Assert
        Assert.True(successActionCalled);
        Assert.False(errorActionCalled);
    }

    [Fact]
    public void Switch_WithFailedOperationResult_CallsErrorAction()
    {
        // Arrange
        var operationResult = new OperationResult<int>(new Exception("Test Exception"));

        bool successActionCalled = false;
        bool errorActionCalled = false;

        // Act
        operationResult.Switch(
            success: data => successActionCalled = true,
            error: ex =>
            {
                errorActionCalled = true;
                Assert.Equal("Test Exception", ex.Message);
            }
        );

        // Assert
        Assert.False(successActionCalled);
        Assert.True(errorActionCalled);
    }

    [Fact]
    public async Task SwitchAsync_WithSuccessfulOperationResult_CallsSuccessFunc()
    {
        // Arrange
        var operationResult = new OperationResult<string>("Hello, World!");

        bool successFuncCalled = false;
        bool errorFuncCalled = false;

        // Act
        await operationResult.SwitchAsync(
            success: data =>
            {
                successFuncCalled = true;
                Assert.Equal("Hello, World!", data);
                return ValueTask.CompletedTask;
            },
            error: async ex =>
            {
                errorFuncCalled = true;
            });

        // Assert
        Assert.True(successFuncCalled);
        Assert.False(errorFuncCalled);
    }

    [Fact]
    public async Task SwitchAsync_WithFailedOperationResult_CallsErrorFunc()
    {
        // Arrange
        var operationResult = new OperationResult<string>(new Exception("Test Exception"));

        bool successFuncCalled = false;
        bool errorFuncCalled = false;

        // Act
        await operationResult.SwitchAsync(
            success: async data => successFuncCalled = true,
            error: ex =>
            {
                errorFuncCalled = true;
                Assert.Equal("Test Exception", ex.Message);
                return ValueTask.CompletedTask;
            }
        );

        // Assert
        Assert.False(successFuncCalled);
        Assert.True(errorFuncCalled);
    }

    [Fact]
    public void Switch_WithSuccessfulOperationResult_CallsSuccessAction_WithoutData()
    {
        // Arrange
        var operationResult = new OperationResult();

        bool successActionCalled = false;
        bool errorActionCalled = false;

        // Act
        operationResult.Switch(
            success: () => successActionCalled = true,
            error: ex => errorActionCalled = true
        );

        // Assert
        Assert.True(successActionCalled);
        Assert.False(errorActionCalled);
    }

    [Fact]
    public void Switch_WithFailedOperationResult_CallsErrorAction_WithoutException()
    {
        // Arrange
        var operationResult = new OperationResult(new Exception("Test Exception"));

        bool successActionCalled = false;
        bool errorActionCalled = false;

        // Act
        operationResult.Switch(
            success: () => successActionCalled = true,
            error: ex =>
            {
                errorActionCalled = true;
                Assert.Equal("Test Exception", ex.Message);
            }
        );

        // Assert
        Assert.False(successActionCalled);
        Assert.True(errorActionCalled);
    }

    [Fact]
    public async Task SwitchAsync_WithSuccessfulOperationResult_CallsSuccessFunc_WithoutData()
    {
        // Arrange
        var operationResult = new OperationResult();

        bool successFuncCalled = false;
        bool errorFuncCalled = false;

        // Act
        await operationResult.SwitchAsync(
            success: () =>
            {
                successFuncCalled = true;
                return ValueTask.CompletedTask;
            },
            error: async ex => errorFuncCalled = true
        );

        // Assert
        Assert.True(successFuncCalled);
        Assert.False(errorFuncCalled);
    }

    [Fact]
    public async Task SwitchAsync_WithFailedOperationResult_CallsErrorFunc_WithoutException()
    {
        // Arrange
        var operationResult = new OperationResult(new Exception("Test Exception"));

        bool successFuncCalled = false;
        bool errorFuncCalled = false;

        // Act
        await operationResult.SwitchAsync(
            success: async () => successFuncCalled = true,
            error: ex =>
            {
                errorFuncCalled = true;
                Assert.Equal("Test Exception", ex.Message);
                return ValueTask.CompletedTask;
            }
        );

        // Assert
        Assert.False(successFuncCalled);
        Assert.True(errorFuncCalled);
    }





    [Fact]
    public void Value_Switch_WithSuccessfulOperationResult_CallsSuccessAction()
    {
        // Arrange
        var operationResult = new ValueOperationResult<int>(42);

        bool successActionCalled = false;
        bool errorActionCalled = false;

        // Act
        operationResult.Switch(
            success: data =>
            {
                successActionCalled = true;
                Assert.Equal(42, data);
            },
            error: ex => errorActionCalled = true
        );

        // Assert
        Assert.True(successActionCalled);
        Assert.False(errorActionCalled);
    }

    [Fact]
    public void Value_Switch_WithFailedOperationResult_CallsErrorAction()
    {
        // Arrange
        var operationResult = new ValueOperationResult<int>(new Exception("Test Exception"));

        bool successActionCalled = false;
        bool errorActionCalled = false;

        // Act
        operationResult.Switch(
            success: data => successActionCalled = true,
            error: ex =>
            {
                errorActionCalled = true;
                Assert.Equal("Test Exception", ex.Message);
            }
        );

        // Assert
        Assert.False(successActionCalled);
        Assert.True(errorActionCalled);
    }

    [Fact]
    public async Task Value_SwitchAsync_WithSuccessfulOperationResult_CallsSuccessFunc()
    {
        // Arrange
        var operationResult = new ValueOperationResult<string>("Hello, World!");

        bool successFuncCalled = false;
        bool errorFuncCalled = false;

        // Act
        await operationResult.SwitchAsync(
            success: data =>
            {
                successFuncCalled = true;
                Assert.Equal("Hello, World!", data);
                return ValueTask.CompletedTask;
            },
            error: async ex =>
            {
                errorFuncCalled = true;
            });

        // Assert
        Assert.True(successFuncCalled);
        Assert.False(errorFuncCalled);
    }

    [Fact]
    public async Task Value_SwitchAsync_WithFailedOperationResult_CallsErrorFunc()
    {
        // Arrange
        var operationResult = new ValueOperationResult<string>(new Exception("Test Exception"));

        bool successFuncCalled = false;
        bool errorFuncCalled = false;

        // Act
        await operationResult.SwitchAsync(
            success: async data => successFuncCalled = true,
            error: ex =>
            {
                errorFuncCalled = true;
                Assert.Equal("Test Exception", ex.Message);
                return ValueTask.CompletedTask;
            }
        );

        // Assert
        Assert.False(successFuncCalled);
        Assert.True(errorFuncCalled);
    }

    [Fact]
    public void Value_Switch_WithSuccessfulOperationResult_CallsSuccessAction_WithoutData()
    {
        // Arrange
        var operationResult = new ValueOperationResult();

        bool successActionCalled = false;
        bool errorActionCalled = false;

        // Act
        operationResult.Switch(
            success: () => successActionCalled = true,
            error: ex => errorActionCalled = true
        );

        // Assert
        Assert.True(successActionCalled);
        Assert.False(errorActionCalled);
    }

    [Fact]
    public void Value_Switch_WithFailedOperationResult_CallsErrorAction_WithoutException()
    {
        // Arrange
        var operationResult = new ValueOperationResult(new Exception("Test Exception"));

        bool successActionCalled = false;
        bool errorActionCalled = false;

        // Act
        operationResult.Switch(
            success: () => successActionCalled = true,
            error: ex =>
            {
                errorActionCalled = true;
                Assert.Equal("Test Exception", ex.Message);
            }
        );

        // Assert
        Assert.False(successActionCalled);
        Assert.True(errorActionCalled);
    }

    [Fact]
    public async Task Value_SwitchAsync_WithSuccessfulOperationResult_CallsSuccessFunc_WithoutData()
    {
        // Arrange
        var operationResult = new ValueOperationResult();

        bool successFuncCalled = false;
        bool errorFuncCalled = false;

        // Act
        await operationResult.SwitchAsync(
            success: () =>
            {
                successFuncCalled = true;
                return ValueTask.CompletedTask;
            },
            error: async ex => errorFuncCalled = true
        );

        // Assert
        Assert.True(successFuncCalled);
        Assert.False(errorFuncCalled);
    }

    [Fact]
    public async Task Value_SwitchAsync_WithFailedOperationResult_CallsErrorFunc_WithoutException()
    {
        // Arrange
        var operationResult = new ValueOperationResult(new Exception("Test Exception"));

        bool successFuncCalled = false;
        bool errorFuncCalled = false;

        // Act
        await operationResult.SwitchAsync(
            success: async () => successFuncCalled = true,
            error: ex =>
            {
                errorFuncCalled = true;
                Assert.Equal("Test Exception", ex.Message);
                return ValueTask.CompletedTask;
            }
        );

        // Assert
        Assert.False(successFuncCalled);
        Assert.True(errorFuncCalled);
    }
}
