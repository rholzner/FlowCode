namespace FlowCode.Tests.UnitTests;

public class OperationResultsTests
{
    [Fact]
    public void Add_ShouldAddOperationResultsToList()
    {
        // Arrange
        var operationResults = new OperationResults();
        var result1 = new OperationResult();
        var result2 = new OperationResult();

        // Act
        operationResults.Add(result1, result2);

        // Assert
        Assert.Equal(2, operationResults.Count);
        Assert.Contains(result1, operationResults);
        Assert.Contains(result2, operationResults);
    }

    [Fact]
    public void Add_Condition_ShouldAddOperationResultsThatMeetConditionToList()
    {
        // Arrange
        var operationResults = new OperationResults();
        var result1 = new OperationResult();
        var result2 = new OperationResult();
        var result3 = new OperationResult();

        // Act
        operationResults.Add(result1, result2, result3);
        operationResults.Add(result => false, result2, result3);

        // Assert
        Assert.Equal(3, operationResults.Count);
        Assert.Contains(result2, operationResults);
        Assert.Contains(result3, operationResults);
    }

    [Fact]
    public void IsSuccess_ShouldReturnTrue_WhenAllOperationResultsAreSuccessful()
    {
        // Arrange
        var operationResults = new OperationResults();
        var result1 = OperationResult.Success();
        var result2 = OperationResult.Success();

        // Act
        operationResults.Add(result1, result2);

        // Assert
        Assert.True(operationResults.IsSuccess);
    }

    [Fact]
    public void IsSuccess_ShouldReturnFalse_WhenAtLeastOneOperationResultIsNotSuccessful()
    {
        // Arrange
        var operationResults = new OperationResults();
        var result1 = OperationResult.Success();
        var result2 = OperationResult.Failure(new Exception("fail"));

        // Act
        operationResults.Add(result1, result2);

        // Assert
        Assert.False(operationResults.IsSuccess);
    }
}
