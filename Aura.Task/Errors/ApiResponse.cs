namespace Aura.PracticalTask.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? Messege { get; set; }

        public ApiResponse(int statusCode , string messege=null)
        {

            this.StatusCode = statusCode;
            this.Messege = messege?? GetMessegeForStatusCode(statusCode);
        }

        private string? GetMessegeForStatusCode(int statusCode)
        {

            return statusCode switch
            {
                400 => "bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resourse not found",
                500 => "internal error",
                _ => null

            };
        }
    }
}
