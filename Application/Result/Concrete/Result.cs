
using Application.Result.Abstract;

namespace Application.Result.Concrete;

public class Result : IResult
{
    public Result(bool success)
    {
        Success = success;
    }

    public Result(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
}
