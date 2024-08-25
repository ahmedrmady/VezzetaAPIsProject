
namespace Vezzeta.APIs.Error
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? Messege { get; set; }

        public ApiResponse(int statusCode , string? messege = null)
        {
            this.StatusCode = statusCode;
            this.Messege = messege ?? GetDefualtMessegeForStatusCode(statusCode);
        }

        private string? GetDefualtMessegeForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400=> "Bad Request",
                401=>"UnAuthrized",
                404 => "The Resource Not Found",
                500 => "Server Error",
                _ => null
            };
        }
    }
}
