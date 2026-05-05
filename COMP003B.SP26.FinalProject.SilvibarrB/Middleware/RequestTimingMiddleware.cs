using System.Diagnostics;

namespace COMP003B.SP26.FinalProject.SilvibarrB.Middleware
{

    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next; 

        public RequestTimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) //called for each http req
        {
            var stopwatch = Stopwatch.StartNew(); // Starts the stopwatch
            Console.WriteLine($"[REQUEST] {context.Request.Method} {context.Request.Path}");

            await _next(context); //pass to next middleware
            
            stopwatch.Stop(); // stop timer and log time to complete in milliseconds
            Console.WriteLine($"[RESPONSE] {context.Request.Method} {context.Request.Path} completed in {stopwatch.ElapsedMilliseconds}ms");
        }

    }
}