using Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace WebApi.Exceptions
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                string message;

                switch (error)
                {
                    case ApiException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        message = "خطا در درخواست";
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        message = "آیتم مورد نظر پیدا نشد";
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        message = "خطای سمت سرور";
                        break;
                }

                var result = JsonSerializer.Serialize(new { message });
                await response.WriteAsync(result);
            }
        }
    }
}
