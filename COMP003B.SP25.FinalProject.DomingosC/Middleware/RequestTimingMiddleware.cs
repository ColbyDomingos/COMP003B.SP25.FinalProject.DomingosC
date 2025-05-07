namespace COMP003B.SP25.FinalProject.DomingosC.Middleware
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next; //cannot be edited
        private readonly ILogger<RequestTimingMiddleware> _logger; //adds the logger for the console

        public RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
        {
            _next = next;
            _logger = logger; //logs all tasks
        }

        public async Task InvokeAsync(HttpContext context) //syncs with the http requests
        {
            var startTime = DateTime.UtcNow;
            await _next(context);



            var duration = DateTime.UtcNow - startTime;
            _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path} took {duration.TotalMilliseconds} ms"); //displays to console what happens
        }
    }
}


