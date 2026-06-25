namespace HRManagement.Application.Responses
{
    public class BaseResponse<T>
    {
        public bool Success { get; private set; }
        public string? Message { get; private set; }
        public T? Data { get; private set; }

        private BaseResponse() { }

        public static BaseResponse<T> SuccessResponse(T data, string message)
        {
            return new BaseResponse<T>
            {
                Success = true,
                Message = message,
                Data = data
            };
        }

        public static BaseResponse<T> FailureResponse(string message)
        {
            return new BaseResponse<T>
            {
                Success = false,
                Message = message
            };
        }
    }
}