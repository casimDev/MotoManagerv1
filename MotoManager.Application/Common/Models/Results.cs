namespace MotoManager.Application.Common.Models
{
    public class Results(bool? success = default,
        string? errorCode = default,
        string? message = default,
        object[] returns = default!)
    {
        public bool Success { get; init; } = success ?? false;
        public string ErrorCode { get; init; } = errorCode ?? string.Empty;
        public string Message { get; init; } = message ?? string.Empty;
        public object[] Returns { get; init; } = returns ?? new object[0];

        public static Results Ok(bool Success, string Message, object[] Returns) => new Results() { Success = Success, Message = Message, Returns = Returns };
        public static Results Fail(bool Success, string ErrorCode, string Message) => new Results() { Success = Success, ErrorCode = ErrorCode, Message = Message, Returns = null! };
    }
}
