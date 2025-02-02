using PerformanceManagementSystem.Application.Common.Results;

public class Result
{
    protected Result(bool success, string error, Status status)
    {
        if (success && error != string.Empty)
            throw new InvalidOperationException("A successful result cannot have an error message.");
        if (!success && error == string.Empty)
            throw new InvalidOperationException("A failed result must have an error message.");
        Success = success;
        Error = error;
        Status = status;
    }

    public bool Success { get; }
    public string Error { get; }
    public bool IsFailure => !Success;
    public Status Status { get; }

    // Helper methods for common failure statuses
    public static Result BadRequest(string message)
    {
        return new Result(false, message, Status.BadRequest);
    }

    public static Result NotFound(string message)
    {
        return new Result(false, message, Status.NotFound);
    }

    public static Result UnAuthorized(string message)
    {
        return new Result(false, message, Status.UnAuthorized);
    }

    public static Result Fail(string message, Status status)
    {
        return new Result(false, message, status);
    }

    public static Result Ok()
    {
        return new Result(true, string.Empty, Status.OK);
    }

    public static Result<T> Ok<T>(T value)
    {
        return new Result<T>(value, true, string.Empty, Status.OK);
    }
}