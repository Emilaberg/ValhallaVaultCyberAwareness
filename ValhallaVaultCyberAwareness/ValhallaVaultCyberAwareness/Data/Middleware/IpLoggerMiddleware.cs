using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ValhallaVaultCyberAwareness.Data.Models;

namespace ValhallaVaultCyberAwareness.Data.Middleware
{
    public class IpLoggerMiddleware
    {
       
        private readonly RequestDelegate _next;
        private HttpClient _httpClient;

        public IpLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
            _httpClient = new();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            if (endpoint != null)
            {

                var authorizeAttribute = endpoint.Metadata.GetMetadata<AuthorizeAttribute>();
                if (authorizeAttribute != null)
                {
                    // Your custom logic here
                    var response = await _httpClient.GetAsync("https://jsonip.com/");
                    IpLoggerModel? model = await response.Content.ReadFromJsonAsync<IpLoggerModel>();
                    
                }else
                {

                }
            }

            await _next(context);
        }
    }

}
