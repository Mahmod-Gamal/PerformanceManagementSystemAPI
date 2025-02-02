using PerformanceManagementSystem.Api.Middlewares;

namespace PerformanceManagementSystem.Api.Extensions
{
    public static class MiddlewareExtentions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
