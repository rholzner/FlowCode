
namespace FlowCode.Tests;

public class OperationResultOnErrorExtensionsTests
{
    [Fact]
    public void OnError_WithException_CallsAction()
    {
        // Arrange
        var operationResult = new OperationResult<int>(new Exception("Test Exception"));
        bool actionCalled = false;

        // Act
        operationResult.OnError(ex =>
        {
            actionCalled = true;
            Assert.Equal("Test Exception", ex.Message);
        });

        // Assert
        Assert.True(actionCalled);
    }

    [Fact]
    public void FakeRecord_OnError_WithException_CallsAction()
    {
        // Arrange
        var operationResult = new OperationResult<FakeRecord>(new Exception("Test Exception"));
        bool actionCalled = false;

        // Act
        operationResult.OnError(ex =>
        {
            actionCalled = true;
            Assert.Equal("Test Exception", ex.Message);
        });

        // Assert
        Assert.True(actionCalled);
    }


    [Fact]
    public void OnError_WithoutException_DoesNotCallAction()
    {
        // Arrange
        var operationResult = new OperationResult<int>(42);
        bool actionCalled = false;

        // Act
        operationResult.OnError(ex =>
        {
            actionCalled = true;
        });

        // Assert
        Assert.False(actionCalled);
    }

    [Fact]
    public void FakeRecord_OnError_WithoutException_DoesNotCallAction()
    {
        // Arrange
        var operationResult = new OperationResult<FakeRecord>(new FakeRecord(42, "robin"));
        bool actionCalled = false;

        // Act
        operationResult.OnError(ex =>
        {
            actionCalled = true;
        });

        // Assert
        Assert.False(actionCalled);
    }
}
