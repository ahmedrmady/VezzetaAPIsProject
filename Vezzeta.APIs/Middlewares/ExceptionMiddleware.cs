using System.Net;
using System.Text.Json;
using Vezzeta.APIs.Error;

namespace Vezzeta.APIs.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var exception = env.IsDevelopment() ?
                      new ApiExceptionResponse(ex.StackTrace.ToString())
                      : new ApiExceptionResponse()
                      ;
                var jsonOptions = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
               
                var exceptionJsonObject = JsonSerializer.Serialize(exception,jsonOptions);
              
                
                await context.Response.WriteAsync(exceptionJsonObject);

                logger.LogError(ex,ex.Message);
               
            }
        }
    }
}
