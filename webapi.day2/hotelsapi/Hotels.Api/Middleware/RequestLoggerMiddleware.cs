namespace Hotels.Api.Middleware
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Services;

    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate next;

        public RequestLoggerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ISimpleLogger simpleLogger)
        {
            var date = DateTime.Now;
            simpleLogger.LogInfo($"Handling request: {context.Request.Method} {context.Request.Path}");

            await this.next.Invoke(context);

            simpleLogger.LogInfo($"Finished handling request. Milliseconds: {(DateTime.Now - date).TotalMilliseconds}");
        }
    }
}
