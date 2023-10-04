namespace LeapYearKata.Blazor.ROP;

public class Result<T>
{
    public T Value { get; }
    public string Error { get; }
    public bool IsSuccess { get; }

    public Result(T value, string error, bool isSuccess)
    {
        Value = value;
        Error = error;
        IsSuccess = isSuccess;
    }
    
    public static Result<T> Success(T value) => new Result<T>(value, string.Empty, true);
    public static Result<T> Fail(string error) => new Result<T>(default, error, false);
}