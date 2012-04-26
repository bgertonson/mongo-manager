namespace MongoManager.Models
{
    public class ApiResponse
    {
        public ApiResponse(bool success = true, string message = "")
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}