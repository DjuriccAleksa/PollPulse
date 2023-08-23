using Microsoft.AspNetCore.Diagnostics;
using PollPulse.Entities.Exceptions;
using PollPulse.Entities.Exceptions.BaseExceptions;
using PollPulse.Entities.Exceptions.ExceptionModel;
using System.Text.Json;

namespace PollPulse.API.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandling(this WebApplication app)
        {
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature is not null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            ValidationAppException => StatusCodes.Status422UnprocessableEntity,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        if(contextFeature.Error is ValidationAppException exception)
                            await context.Response.WriteAsync(JsonSerializer.Serialize(new { exception.Errors }));
                        else 
                        {
                            await context.Response.WriteAsync(new ExceptionDetails()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = contextFeature.Error.Message
                            }.ToString());
                        }
                    }
                });
            });
        }
    }
}
