namespace FlowCode;

public class OperationResult<T> : OperationResult
{
    public OperationResult()
    {
        Data = default!;
    }

    public OperationResult(T data)
    {
        Data = data;
        _dataHasBinSet = true;
    }

    public OperationResult(Exception ex) : base(ex)
    {
        Data = default!;
    }

    public T Data { get; set; }

    public override bool IsSuccess => Exception is null && (Data is not null && _dataHasBinSet);

    public bool _dataHasBinSet { get; set; }

    public static implicit operator OperationResult<T>(Exception ex)
    {
        return new OperationResult<T>(ex);
    }

    public static implicit operator OperationResult<T>(T data)
    {
        return new OperationResult<T>(data);
    }

}

public class OperationResult
{
    public OperationResult()
    {

    }
    public OperationResult(Exception exception)
    {
        Exception = exception;
    }

    public virtual bool IsSuccess => Exception is null;

    public Exception? Exception { get; set; }

    public static implicit operator OperationResult(Exception ex) => new OperationResult(ex);

}
