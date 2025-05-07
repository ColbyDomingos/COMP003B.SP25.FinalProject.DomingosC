namespace COMP003B.SP25.FinalProject.DomingosC.Middleware
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTimingMiddleware> _logger;

        public RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var startTime = DateTime.UtcNow;

            await _next(context);

            var duration = DateTime.UtcNow - startTime;
            _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path} took {duration.TotalMilliseconds} ms");
        }
    }
}


