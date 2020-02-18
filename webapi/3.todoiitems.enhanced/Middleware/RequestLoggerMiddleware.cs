namespace TodoItems.Middleware
{
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;

    public class RequestLoggerMiddleware
    {
        private readonly ILogger logger;
        private readonly RequestDelegate next;

        // #3 custom middleware
        public RequestLoggerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            this.logger = loggerFactory.CreateLogger<RequestLoggerMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            this.logger.LogInformation("Handling request: " + context.Request.Path);

            await this.next.Invoke(context);

            this.logger.LogInformation("Finished handling request.");
        }
    }
}
