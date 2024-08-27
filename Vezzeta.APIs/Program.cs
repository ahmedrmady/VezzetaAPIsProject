
using Microsoft.AspNetCore.Mvc;
using Vezzeta.APIs.Error;
using Vezzeta.APIs.Middlewares;

namespace Vezzeta.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // configure the validations errors  
            builder.Services.Configure<ApiBehaviorOptions>(options => {

                options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState 
                                         .Where(p => p.Value.Errors.Count() > 0)
                                        .SelectMany(e => e.Value.Errors)
                                        .Select(E => E.ErrorMessage)
                                        .ToList();

                    var validationsErrorsResponse = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(validationsErrorsResponse);

                };

            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseMiddleware<ExceptionMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
