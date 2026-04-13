namespace JobHandlerAPI.Helpers
{
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public T Data { get; private set; }
        public IEnumerable<string> Errors { get; private set; }

        public static Result<T> Success(T data) =>
            new Result<T> { IsSuccess = true, Data = data, Errors = Array.Empty<string>() };

        public static Result<T> Failure(IEnumerable<string> errors) =>
            new Result<T> { IsSuccess = false, Errors = errors };

        public static Result<T> Failure(string error) =>
            new Result<T> { IsSuccess = false, Errors = new[] { error } };
    }
}
