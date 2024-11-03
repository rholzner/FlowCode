
namespace FlowCode;

public interface IOperationResult
{
    bool IsSuccess { get; }
    Exception? Exception { get; }
}

public interface IOperationResult<out T> : IOperationResult
{
    T Data { get; }
}

