namespace FlowCode;

/// <summary>
/// Represents the result of an operation that returns a value.
/// </summary>
/// <typeparam name="T"></typeparam>
public class OperationResult<T> : OperationResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OperationResult{T}"/> class.
    /// </summary>
    public OperationResult()
    {
        Data = default!;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OperationResult{T}"/> class.
    /// </summary>
    /// <param name="data"></param>
    public OperationResult(T data)
    {
        Data = data;
        _dataHasBeenSet = true;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OperationResult{T}"/> class.
    /// </summary>
    /// <param name="ex"></param>
    public OperationResult(Exception ex) : base(ex)
    {
        Data = default!;
    }

    /// <summary>
    /// Gets the data returned by the operation.
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    /// Gets a value indicating whether the operation was successful.
    /// </summary>
    public override bool IsSuccess => Exception is null && (Data is not null && _dataHasBeenSet);

    /// <summary>
    /// Gets a value indicating whether the data has been set.
    /// </summary>
    private bool _dataHasBeenSet { get; }

    /// <summary>
    /// Implicitly converts an exception to an operation result.
    /// </summary>
    /// <param name="ex"></param>
    public static implicit operator OperationResult<T>(Exception ex)
    {
        return new OperationResult<T>(ex);
    }

    /// <summary>
    /// Implicitly converts data to an operation result.
    /// </summary>
    /// <param name="data"></param>

    public static implicit operator OperationResult<T>(T data)
    {
        return new OperationResult<T>(data);
    }

    /// <summary>
    /// Creates a new successful operation result.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static OperationResult<T> Success(T data) => new OperationResult<T>(data);

    /// <summary>
    /// Creates a new failed operation result.
    /// </summary>
    /// <param name="ex"></param>
    /// <returns></returns>
    public new static OperationResult<T> Failure(Exception ex) => new OperationResult<T>(ex);

}
/// <summary>
/// Represents the result of an operation.
/// </summary>
public class OperationResult
{

    /// <summary>
    /// Initializes a new instance of the <see cref="OperationResult"/> class.
    /// </summary>
    public OperationResult()
    {

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OperationResult"/> class.
    /// </summary>
    /// <param name="exception"></param>
    public OperationResult(Exception exception)
    {
        Exception = exception;
    }

    /// <summary>
    /// Gets a value indicating whether the operation was successful.
    /// </summary>
    public virtual bool IsSuccess => Exception is null;

    /// <summary>
    /// Gets the exception that occurred during the operation.
    /// </summary>
    public Exception? Exception { get; set; }


    /// <summary>
    /// Implicitly converts an exception to an operation result.
    /// </summary>
    /// <param name="ex"></param>
    public static implicit operator OperationResult(Exception ex) => new OperationResult(ex);

    /// <summary>
    /// Creates a new successful operation result.
    /// </summary>
    /// <returns></returns>
    public static OperationResult Success() => new OperationResult();

    /// <summary>
    /// Creates a new failed operation result.
    /// </summary>
    /// <param name="ex"></param>
    /// <returns></returns>
    public static OperationResult Failure(Exception ex) => new OperationResult(ex);

}
