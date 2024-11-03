namespace FlowCode.Tests.UnitTests;

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
        var operationResult = OperationResult.Success(data);
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








    [Fact]
    public void Value_OnSuccess_WithData_CallsAction()
    {
        // Arrange
        var data = "test data";
        var operationResult = new ValueOperationResult<string>(data);
        var actionCalled = false;

        // Act
        operationResult.OnSuccess(d =>
        {
            actionCalled = true;
            Assert.Equal(data, d);
            return ValueOperationResult.Success();
        });

        // Assert
        Assert.True(actionCalled);
    }

    [Fact]
    public void Value_FakeRecord_OnSuccess_WithData_CallsAction()
    {
        // Arrange
        var data = new FakeRecord(42, "robin");
        var operationResult = new ValueOperationResult<FakeRecord>(data);
        var actionCalled = false;

        // Act
        operationResult.OnSuccess(d =>
        {
            actionCalled = true;
            Assert.Equal(data, d);
            return ValueOperationResult.Success();
        });

        // Assert
        Assert.True(actionCalled);
    }


    [Fact]
    public void Value_OnSuccess_WithoutData_CallsAction()
    {
        // Arrange
        var operationResult = new ValueOperationResult();
        var actionCalled = false;

        // Act
        operationResult.OnSuccess(() =>
        {
            actionCalled = true;
            return ValueOperationResult.Success();
        });

        // Assert
        Assert.True(actionCalled);
    }

    [Fact]
    public void Value_Int_OnSuccess_WithoutData_ExpectedData_DoseNotCallsAction()
    {
        // Arrange
        var operationResult = new ValueOperationResult<int>();
        var actionCalled = false;

        // Act
        operationResult.OnSuccess(s =>
        {
            actionCalled = true;
            return 40;
        });

        // Assert
        Assert.False(actionCalled);
    }

    [Fact]
    public void Value_String_OnSuccess_WithoutData_ExpectedData_DoseNotCallsAction()
    {
        // Arrange
        var operationResult = new ValueOperationResult<string>();
        var actionCalled = false;

        // Act
        operationResult.OnSuccess(s =>
        {
            actionCalled = true;
            return ValueOperationResult.Success();
        });

        // Assert
        Assert.False(actionCalled);
    }

    [Fact]
    public void Value_Class_OnSuccess_WithoutData_ExpectedData_DoseNotCallsAction()
    {
        // Arrange
        var operationResult = new ValueOperationResult<FakeClass>();
        var actionCalled = false;

        // Act
        operationResult.OnSuccess(s =>
        {
            actionCalled = true;
            return ValueOperationResult.Success();
        });

        // Assert
        Assert.False(actionCalled);
    }

    [Fact]
    public void Value_OnSuccess_WithSuccessfulOperationResult_ShouldExecuteAction()
    {
        // Arrange
        var operationResult = ValueOperationResult.Success();
        bool actionExecuted = false;

        // Act
        operationResult.OnSuccess(() => actionExecuted = true);

        // Assert
        Assert.True(actionExecuted);
    }

    [Fact]
    public void Value_OnSuccess_WithFailedOperationResult_ShouldNotExecuteAction()
    {
        // Arrange
        var operationResult = ValueOperationResult.Failure(new OperationResultException("Test exception"));
        bool actionExecuted = false;

        // Act
        operationResult.OnSuccess(() => actionExecuted = true);

        // Assert
        Assert.False(actionExecuted);
    }

    [Fact]
    public void Value_OnSuccess_WithSuccessfulOperationResultAndData_ShouldExecuteActionWithData()
    {
        // Arrange
        string data = "Test data";
        ValueOperationResult<string> operationResult = ValueOperationResult.Success(data);
        string resultData = null;

        // Act
        operationResult.OnSuccess(s =>
        {
            resultData = data;
            return data;
        });

        // Assert
        Assert.Equal(data, resultData);
    }

    [Fact]
    public void Value_OnSuccess_WithFailedOperationResultAndData_ShouldNotExecuteAction()
    {
        // Arrange
        var data = "Test data";
        var operationResult = ValueOperationResult.Failure(new OperationResultException("Test exception"));
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
