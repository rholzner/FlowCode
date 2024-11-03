
namespace FlowCode;

public struct ValueOperationResult : IOperationResult
{
    public ValueOperationResult()
    {
        Exception = null;
    }
    public ValueOperationResult(Exception exception)
    {
        Exception = exception;
    }
    public Exception? Exception { get; }
    public bool IsSuccess => Exception is null;

    /// <summary>
    /// Implicitly converts an exception to an operation result.
    /// </summary>
    /// <param name="ex"></param>
    public static implicit operator ValueOperationResult(Exception ex) => new ValueOperationResult(ex);

    public static bool operator !(ValueOperationResult operation)
    {
        return !operation.IsSuccess;
    }

    public static ValueOperationResult operator |(ValueOperationResult left, Func<ValueOperationResult> right)
    {
        if (left.IsSuccess)
        {
            return left;
        }
        return right();
    }

    /// <summary>
    /// Creates a new successful operation result.
    /// </summary>
    /// <returns></returns>
    public static ValueOperationResult Success() => new ValueOperationResult();
    public static ValueOperationResult<T> Success<T>(T data) => new ValueOperationResult<T>(data);

    /// <summary>
    /// Creates a new failed operation result.
    /// </summary>
    /// <param name="ex"></param>
    /// <returns></returns>
    public static ValueOperationResult Failure(Exception ex) => new ValueOperationResult(ex);
    public static ValueOperationResult<T> Failure<T>(Exception ex) => new ValueOperationResult<T>(ex);


    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj is ValueOperationResult operation)
        {
            if (this.IsSuccess)
            {
                return operation.IsSuccess;
            }

            return operation.Exception == Exception;
        }

        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(IsSuccess, Exception);
    }

}

public struct ValueOperationResult<T> : IOperationResult<T>
{
    public ValueOperationResult(T data)
    {
        Data = data;
        Exception = null;
        _dataHasBeenSet = true;
    }
    public ValueOperationResult(Exception exception)
    {
        Data = default!;
        Exception = exception;
    }
    public T Data { get; }
    public Exception? Exception { get; }
    /// <summary>
    /// Gets a value indicating whether the operation was successful.
    /// </summary>
    public bool IsSuccess
    {
        get
        {
            return Exception is null && (Data is not null && _dataHasBeenSet);
        }
    }

    /// <summary>
    /// Gets a value indicating whether the data has been set.
    /// </summary>
    private bool _dataHasBeenSet { get; }

    /// <summary>
    /// Implicitly converts an exception to an operation result.
    /// </summary>
    /// <param name="ex"></param>
    public static implicit operator ValueOperationResult<T>(Exception ex)
    {
        return new ValueOperationResult<T>(ex);
    }

    /// <summary>
    /// Implicitly converts data to an operation result.
    /// </summary>
    /// <param name="data"></param>

    public static implicit operator ValueOperationResult<T>(T data)
    {
        return new ValueOperationResult<T>(data);
    }

    public static ValueOperationResult<T> operator |(ValueOperationResult<T> left, ValueOperationResult<T> right)
    {
        if (left.IsSuccess)
        {
            return left;
        }
        return right;
    }

    public static ValueOperationResult<T> operator |(ValueOperationResult<T> left, Func<T> right)
    {
        if (left.IsSuccess)
        {
            return left;
        }
        return right();
    }

    public static bool operator !(ValueOperationResult<T> operation)
    {
        return !operation.IsSuccess;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (this.IsSuccess && Data is not null && obj is T incommingData)
        {
            return Data.Equals(incommingData);
        }

        if (obj is ValueOperationResult<T> operation)
        {
            if (this.IsSuccess)
            {
                if (Data is not null && Data.Equals(operation.Data))
                {
                    return true;
                }

                return false;

            }
            return operation.Exception == Exception;
        }

        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(IsSuccess, Exception, Data);
    }


    /// <summary>
    /// Creates a new successful operation result.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static ValueOperationResult<T> Success(T data) => new ValueOperationResult<T>(data);

    /// <summary>
    /// Creates a new failed operation result.
    /// </summary>
    /// <param name="ex"></param>
    /// <returns></returns>
    public new static ValueOperationResult<T> Failure(Exception ex) => new ValueOperationResult<T>(ex);
}
