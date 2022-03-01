using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SampleWebApplication
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public CustomMiddleware(RequestDelegate next, ILoggerFactory logFactory)
        {
            _next = next;
            _logger = logFactory.CreateLogger("Custom Middleware Logger");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var v = httpContext.Request.Method;
            var p = httpContext.Request.Path;
            var t = DateTime.UtcNow.ToString("HH:mm:ss");

            _logger.LogInformation($"{v} - {p} - {t}");

            await _next(httpContext);
        }
    }

    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
