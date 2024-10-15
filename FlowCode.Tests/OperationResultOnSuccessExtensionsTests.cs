namespace FlowCode.Tests;

public class OperationResultOnSuccessExtensionsTests
{
    [Fact]
    public void OnSuccess_WithData_CallsAction()
    {
        // Arrange
        var data = "test data";
        var operationResult = new OperationResult<string>(data);
        var actionCalled = false;

        // Act
        operationResult.OnSuccess(d =>
        {
            actionCalled = true;
            Assert.Equal(data, d);
        });

        // Assert
        Assert.True(actionCalled);
    }

    [Fact]
    public void FakeRecord_OnSuccess_WithData_CallsAction()
    {
        // Arrange
        var data = new FakeRecord(42, "robin");
        var operationResult = new OperationResult<FakeRecord>(data);
        var actionCalled = false;

        // Act
        operationResult.OnSuccess(d =>
        {
            actionCalled = true;
            Assert.Equal(data, d);
        });

        // Assert
        Assert.True(actionCalled);
    }


    [Fact]
    public void OnSuccess_WithoutData_CallsAction()
    {
        // Arrange
        var operationResult = new OperationResult();
        var actionCalled = false;

        // Act
        operationResult.OnSuccess(() =>
        {
            actionCalled = true;
        });

        // Assert
        Assert.True(actionCalled);
    }

    [Fact]
    public void Int_OnSuccess_WithoutData_ExpectedData_DoseNotCallsAction()
    {
        // Arrange
        var operationResult = new OperationResult<int>();
        var actionCalled = false;

        // Act
        operationResult.OnSuccess(() =>
        {
            actionCalled = true;
        });

        // Assert
        Assert.False(actionCalled);
    }

    [Fact]
    public void String_OnSuccess_WithoutData_ExpectedData_DoseNotCallsAction()
    {
        // Arrange
        var operationResult = new OperationResult<string>();
        var actionCalled = false;

        // Act
        operationResult.OnSuccess(() =>
        {
            actionCalled = true;
        });

        // Assert
        Assert.False(actionCalled);
    }

    [Fact]
    public void Class_OnSuccess_WithoutData_ExpectedData_DoseNotCallsAction()
    {
        // Arrange
        var operationResult = new OperationResult<FakeClass>();
        var actionCalled = false;

        // Act
        operationResult.OnSuccess(() =>
        {
            actionCalled = true;
        });

        // Assert
        Assert.False(actionCalled);
    }
}
