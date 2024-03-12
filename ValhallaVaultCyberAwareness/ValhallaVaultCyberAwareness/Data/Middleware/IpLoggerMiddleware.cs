using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data.Models;
using ValhallaVaultCyberAwareness.Repositories;

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

        public async Task InvokeAsync(HttpContext context, ApplicationDbContext _context)
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

                    if (model != null)
                    {
                        _context.LoggedIpUsers.Add(model);
                        await _context.SaveChangesAsync();
                    }
                }
                else
                {

                }
            }

            await _next(context);
        }
    }

}
