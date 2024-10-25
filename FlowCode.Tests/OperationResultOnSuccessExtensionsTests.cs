using static System.Runtime.InteropServices.JavaScript.JSType;

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
            return OperationResult.Success();
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
            return OperationResult.Success();
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
            return OperationResult.Success();
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
            return OperationResult.Success();
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
            return OperationResult.Success();
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
            return OperationResult.Success();
        });

        // Assert
        Assert.False(actionCalled);
    }

    [Fact]
    public void OnSuccess_WithSuccessfulOperationResult_ShouldExecuteAction()
    {
        // Arrange
        var operationResult = OperationResult.Success();
        bool actionExecuted = false;

        // Act
        operationResult.OnSuccess(() => actionExecuted = true);

        // Assert
        Assert.True(actionExecuted);
    }

    [Fact]
    public void OnSuccess_WithFailedOperationResult_ShouldNotExecuteAction()
    {
        // Arrange
        var operationResult = OperationResult.Failure(new OperationResultException("Test exception"));
        bool actionExecuted = false;

        // Act
        operationResult.OnSuccess(() => actionExecuted = true);

        // Assert
        Assert.False(actionExecuted);
    }

    [Fact]
    public void OnSuccess_WithSuccessfulOperationResultAndData_ShouldExecuteActionWithData()
    {
        // Arrange
        var data = "Test data";
        var operationResult = OperationResult.Success<string>(data);
        string resultData = null;

        // Act
        operationResult.OnSuccess(() =>
        {
            resultData = data;
            return data;
        });

        // Assert
        Assert.Equal(data, resultData);
    }

    [Fact]
    public void OnSuccess_WithFailedOperationResultAndData_ShouldNotExecuteAction()
    {
        // Arrange
        var data = "Test data";
        var operationResult = OperationResult.Failure(new OperationResultException("Test exception"));
        string resultData = null;

        // Act
        operationResult.OnSuccess(() =>
        {
            resultData = data;
            return data;
        });

        // Assert
        Assert.Null(resultData);
    }
}
