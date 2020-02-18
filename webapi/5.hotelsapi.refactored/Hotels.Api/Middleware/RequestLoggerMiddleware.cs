using System.Threading.Tasks;
using Hotels.Api.Services;
using Microsoft.AspNetCore.Http;

namespace Hotels.Api.Middleware
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate next;

        // #3 custom middleware
        public RequestLoggerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, INotificationService notificationService)
        {
            notificationService.Notify($"Handling request: {context.Request.Method} {context.Request.Path}");

            await next.Invoke(context);

            notificationService.Notify("Finished handling request.");
        }
    }
}