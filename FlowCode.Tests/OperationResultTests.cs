namespace FlowCode.Tests;

public class OperationResultTests
{
    [Fact]
    public void OperationResult_DefaultConstructor_Success()
    {
        // Arrange
        var operationResult = new OperationResult();

        // Act
        bool isSuccess = operationResult.IsSuccess;

        // Assert
        Assert.True(isSuccess);
        Assert.Null(operationResult.Exception);
    }

    [Fact]
    public void OperationResult_ExceptionConstructor_Success()
    {
        // Arrange
        var exception = new Exception("Test exception");
        var operationResult = new OperationResult(exception);

        // Act
        bool isSuccess = operationResult.IsSuccess;

        // Assert
        Assert.False(isSuccess);
        Assert.Equal(exception, operationResult.Exception);
    }

    [Fact]
    public void Int_OperationResultT_DefaultConstructor_Success()
    {
        // Arrange
        var operationResult = new OperationResult<int>();

        // Act
        bool isSuccess = operationResult.IsSuccess;

        // Assert
        Assert.False(isSuccess);
        Assert.Null(operationResult.Exception);
        Assert.Equal(0, operationResult.Data);
    }

    [Fact]
    public void Int_OperationResultT_DataConstructor_Success()
    {
        // Arrange
        int data = 42;
        var operationResult = new OperationResult<int>(data);

        // Act
        bool isSuccess = operationResult.IsSuccess;

        // Assert
        Assert.True(isSuccess);
        Assert.Null(operationResult.Exception);
        Assert.Equal(data, operationResult.Data);
    }

    [Fact]
    public void Int_OperationResultT_ExceptionConstructor_False()
    {
        // Arrange
        var exception = new Exception("Test exception");
        var operationResult = new OperationResult<int>(exception);

        // Act
        bool isSuccess = operationResult.IsSuccess;

        // Assert
        Assert.False(isSuccess);
        Assert.Equal(exception, operationResult.Exception);
        Assert.Equal(0, operationResult.Data);
    }

    [Fact]
    public void Int_OperationResultT_ImplicitOperator_Exception_False()
    {
        // Arrange
        var exception = new Exception("Test exception");

        // Act
        OperationResult<int> operationResult = exception;

        // Assert
        Assert.False(operationResult.IsSuccess);
        Assert.Equal(exception, operationResult.Exception);
        Assert.Equal(0, operationResult.Data);
    }

    [Fact]
    public void Int_OperationResultT_ImplicitOperator_Data_Success()
    {
        // Arrange
        int data = 42;

        // Act
        OperationResult<int> operationResult = data;

        // Assert
        Assert.True(operationResult.IsSuccess);
        Assert.Null(operationResult.Exception);
        Assert.Equal(data, operationResult.Data);
    }


    [Fact]
    public void String_OperationResultT_DefaultConstructor_Success()
    {
        // Arrange
        var operationResult = new OperationResult<string>();

        // Act
        bool isSuccess = operationResult.IsSuccess;

        // Assert
        Assert.False(isSuccess);
        Assert.Null(operationResult.Exception);
        Assert.Equal(default, operationResult.Data);
    }

    [Fact]
    public void String_OperationResultT_DataConstructor_Success()
    {
        // Arrange
        string data = "42";
        var operationResult = new OperationResult<string>(data);

        // Act
        bool isSuccess = operationResult.IsSuccess;

        // Assert
        Assert.True(isSuccess);
        Assert.Null(operationResult.Exception);
        Assert.Equal(data, operationResult.Data);
    }

    [Fact]
    public void String_OperationResultT_ExceptionConstructor_False()
    {
        // Arrange
        var exception = new Exception("Test exception");
        var operationResult = new OperationResult<string>(exception);

        // Act
        bool isSuccess = operationResult.IsSuccess;

        // Assert
        Assert.False(isSuccess);
        Assert.Equal(exception, operationResult.Exception);
        Assert.Equal(default, operationResult.Data);
    }

    [Fact]
    public void String_OperationResultT_ImplicitOperator_Exception_False()
    {
        // Arrange
        var exception = new Exception("Test exception");

        // Act
        OperationResult<string> operationResult = exception;

        // Assert
        Assert.False(operationResult.IsSuccess);
        Assert.Equal(exception, operationResult.Exception);
        Assert.Equal(default, operationResult.Data);
    }

    [Fact]
    public void String_OperationResultT_ImplicitOperator_Data_Success()
    {
        // Arrange
        string data = "42";

        // Act
        OperationResult<string> operationResult = data;

        // Assert
        Assert.True(operationResult.IsSuccess);
        Assert.Null(operationResult.Exception);
        Assert.Equal(data, operationResult.Data);
    }

    [Fact]
    public void FakeRecord_OperationResultT_ImplicitOperator_Data_Success()
    {
        // Arrange
        FakeRecord data = new FakeRecord(42, "robin");

        // Act
        OperationResult<FakeRecord> operationResult = data;

        // Assert
        Assert.True(operationResult.IsSuccess);
        Assert.Null(operationResult.Exception);
        Assert.Equal(data, operationResult.Data);
    }

    [Fact]
    public void FakeRecord_OperationResultT_ImplicitOperator_Exception_False()
    {
        // Arrange
        var exception = new Exception("Test exception");

        // Act
        OperationResult<FakeRecord> operationResult = exception;

        // Assert
        Assert.False(operationResult.IsSuccess);
        Assert.Equal(exception, operationResult.Exception);
        Assert.Equal(default, operationResult.Data);
    }

    [Fact]
    public void FakeClass_OperationResultT_ImplicitOperator_Data_Success()
    {
        // Arrange
        FakeClass data = new FakeClass { Id = 42, Name = "robin" };

        // Act
        OperationResult<FakeClass> operationResult = data;

        // Assert
        Assert.True(operationResult.IsSuccess);
        Assert.Null(operationResult.Exception);
        Assert.Equal(data, operationResult.Data);
    }

    [Fact]
    public void FakeClass_OperationResultT_ImplicitOperator_Exception_False()
    {
        // Arrange
        var exception = new Exception("Test exception");

        // Act
        OperationResult<FakeClass> operationResult = exception;

        // Assert
        Assert.False(operationResult.IsSuccess);
        Assert.Equal(exception, operationResult.Exception);
        Assert.Equal(default, operationResult.Data);
    }
}
