namespace FlowCode;

/// <summary>
/// Represents an exception that is thrown when an operation result is not successful.
/// </summary>
public class OperationResultException : Exception
{
    public OperationResultException()
    {
    }
    public OperationResultException(string message) : base(message)
    {
    }
    public OperationResultException(string message, Exception innerException) : base(message, innerException)
    {
    }
}