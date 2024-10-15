namespace FlowCode;

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