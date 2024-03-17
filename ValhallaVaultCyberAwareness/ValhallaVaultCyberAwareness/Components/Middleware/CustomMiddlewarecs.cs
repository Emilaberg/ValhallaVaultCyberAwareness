namespace ValhallaVaultCyberAwareness.Components.Middleware;

using Microsoft.AspNetCore.Http;


public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine("Handling request: " + context.Request.Path);
        await _next(context);
        Console.WriteLine("Finished handling request.");
    }
}


// This is my custom middleware, it is used to log the request path to the console.
// It is used in the Program.cs file to log the request path to the console.





