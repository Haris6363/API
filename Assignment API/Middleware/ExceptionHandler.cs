using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;


namespace Assignment.Middleware
{
    public class ExceptionHandler
    {
        public readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
        }



        public async Task HandledExceptionsAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/Json";
            var Response = context.Response;
            var ResponseError = new ResponseError
            {
                Success = false
            };
            switch (exception)
            {
                case ApplicationException ex:
                    {
                        if (ex.Message.Contains("Invalid Tokens"))
                        {
                            Response.StatusCode = (int)HttpStatusCode.Forbidden;
                            ResponseError.Message = ex.Message;
                            break;

                        }
                        else
                        {
                            Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            ResponseError.Message = ex.Message;
                            break;
                        }
                    }
                default:
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;



            }
            _logger.LogError(exception.Message);
            var result = JsonSerializer.Serialize(ResponseError);
            await context.Response.WriteAsync(result);

        }
       
    }

  
    
    
}
