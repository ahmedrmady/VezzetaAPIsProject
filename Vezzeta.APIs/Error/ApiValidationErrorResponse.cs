namespace Vezzeta.APIs.Error
{
    public class ApiValidationErrorResponse:ApiResponse
    {
        public List<String> Errors { get; set; }
        public ApiValidationErrorResponse( ) : base(400)
        {
            Errors = new List<string>();
        }


    }
}
