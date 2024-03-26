using Serilog;
using SortedAPI.Domain;
using System.Net;
using System.Text.Json;

namespace SortedAPI.Middleware
{
    public class GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger = logger;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Log.Error(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;
            Error errorResponse = new();

            switch (exception)
            {
                case HttpRequestException:
                    errorResponse.Message = "Invalid request";
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case ApplicationException:
                    errorResponse.Message = "Invalid request";
                    response.StatusCode = (int)HttpStatusCode.BadRequest; 
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse.Message = "Internal server error";
                    break;
            }
            var exceptionResult = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(exceptionResult);
        }
    }
}
