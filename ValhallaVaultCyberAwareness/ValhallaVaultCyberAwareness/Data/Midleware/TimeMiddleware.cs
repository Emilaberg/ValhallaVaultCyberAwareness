namespace ValhallaVaultCyberAwareness.Midleware
{
    public class TimeMiddleware
    {
        private readonly ILogger<TimeMiddleware> _logger;
        private readonly RequestDelegate _next;


        public TimeMiddleware(ILogger<TimeMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }
        //Loggs the request path and time in milliseconds
        public async Task Invoke(HttpContext ctx)
        {
            var start = DateTime.Now;
            await _next.Invoke(ctx);//pass the context in the pipeline
            _logger.LogInformation($"time : {ctx.Request.Path} :{(DateTime.Now - start).TotalMilliseconds}ms");
        }




    }
}
