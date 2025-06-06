using todo.list.common.Results;

namespace todo.list.common.Extensions;

public static class ResultExtension
{
    public static Result<Type> IsASuccess<Type>(this Type? data, string? message = null)
        => Result<Type>.Success(data, message);
    public static Result<Type> IsAFailure<Type>(this string? message)
        => Result<Type>.Failure(message);
    public static Result<Type> IsAFailure<Type>(this Type? data, string? message = null)
        => Result<Type>.Failure(data, message);
}
