
namespace FlowCode.Tests;

public class OperationResultSwitchExtensionsTests
{
    [Fact]
    public void Switch_WithSuccessfulOperationResult_CallsSuccessAction()
    {
        // Arrange
        var operationResult = new OperationResult<int>(42);
        bool successActionCalled = false;

        // Act
        operationResult.Switch(
            success: data =>
            {
                successActionCalled = true;
                Assert.Equal(42, data);
            },
            error: ex => Assert.True(false, "Error action should not be called.")
        );

        // Assert
        Assert.True(successActionCalled, "Success action should be called.");
    }

    [Fact]
    public void Switch_WithFailedOperationResult_CallsErrorAction()
    {
        // Arrange
        var operationResult = new OperationResult<int>(new Exception("Test exception"));
        bool errorActionCalled = false;

        // Act
        operationResult.Switch(
            success: data => Assert.True(false, "Success action should not be called."),
            error: ex =>
            {
                errorActionCalled = true;
                Assert.Equal("Test exception", ex.Message);
            }
        );

        // Assert
        Assert.True(errorActionCalled, "Error action should be called.");
    }

    [Fact]
    public void Switch_WithNullDataInSuccessfulOperationResult_CallsErrorAction()
    {
        // Arrange
        var operationResult = new OperationResult<string>();
        bool errorActionCalled = false;

        // Act
        operationResult.Switch(
            success: data => Assert.True(false, "Success action should not be called."),
            error: ex =>
            {
                errorActionCalled = true;
            }
        );

        // Assert
        Assert.True(errorActionCalled, "Error action should be called.");
    }

    [Fact]
    public void Switch_WithSuccessfulOperationResult_CallsSuccessAction_WithoutData()
    {
        // Arrange
        var operationResult = new OperationResult();
        bool successActionCalled = false;

        // Act
        operationResult.Switch(
            success: () => successActionCalled = true,
            error: ex => Assert.True(false, "Error action should not be called.")
        );

        // Assert
        Assert.True(successActionCalled, "Success action should be called.");
    }

    [Fact]
    public void Switch_WithFailedOperationResult_CallsErrorAction_WithoutData()
    {
        // Arrange
        var operationResult = new OperationResult(new Exception("Test exception"));
        bool errorActionCalled = false;

        // Act
        operationResult.Switch(
            success: () => Assert.True(false, "Success action should not be called."),
            error: ex =>
            {
                errorActionCalled = true;
                Assert.True(true, "Error action should be called.");
            }
        );

        // Assert
        Assert.True(errorActionCalled, "Error action should be called.");
    }

    [Fact]
    public void Switch_WithNullExceptionInFailedOperationResult_CallsErrorAction()
    {
        // Arrange
        var operationResult = new OperationResult(new Exception());
        bool errorActionCalled = false;

        // Act
        operationResult.Switch(
            success: () => Assert.True(false, "Success action should not be called."),
            error: ex =>
            {
                errorActionCalled = true;
            }
        );

        // Assert
        Assert.True(errorActionCalled, "Error action should be called.");
    }
}
