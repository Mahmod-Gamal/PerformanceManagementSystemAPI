using PerformanceManagementSystem.Api.Utils;
using System.Diagnostics;
using System.Net;

namespace PerformanceManagementSystem.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext);
            }
        }

        private Task HandleExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(new ErrorDetails
            {
                Status = context.Response.StatusCode,
                Title = ErrorMessageUtils.GeneralErrorMessage,
                TraceId = Activity.Current?.Id ?? context?.TraceIdentifier!,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            }.ToString());
        }
    }

}
