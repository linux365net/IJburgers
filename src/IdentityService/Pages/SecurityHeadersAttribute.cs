using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityService.Pages;

public sealed class SecurityHeadersAttribute : ActionFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        var result = context.Result;
        if (result is PageResult)
        {
            // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Content-Type-Options
            if (!context.HttpContext.Response.Headers.ContainsKey("X-Content-Type-Options"))
            {
                context.HttpContext.Response.Headers.Append("X-Content-Type-Options", "nosniff");
            }

            // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Frame-Options
            if (!context.HttpContext.Response.Headers.ContainsKey("X-Frame-Options"))
            {
                context.HttpContext.Response.Headers.Append("X-Frame-Options", "DENY");
            }

            // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy
            var csp = "default-src 'self'; object-src 'none'; frame-ancestors 'none'; base-uri 'self';";
            
            // Configure different sandbox policies for development vs production
            if (context.HttpContext.RequestServices.GetRequiredService<IWebHostEnvironment>().IsDevelopment())
            {
                // More permissive for development, allow WebSocket connections for hot reload
                csp += " sandbox allow-forms allow-same-origin allow-scripts; connect-src 'self' ws: wss:;";
            }
            else
            {
                // More restrictive for production, avoid allow-scripts + allow-same-origin combination
                csp += " sandbox allow-forms allow-scripts;";
            }
            
            // also consider adding upgrade-insecure-requests once you have HTTPS in place for production
            //csp += "upgrade-insecure-requests;";
            // also an example if you need client images to be displayed from twitter
            // csp += "img-src 'self' https://pbs.twimg.com;";

            // once for standards compliant browsers
            if (!context.HttpContext.Response.Headers.ContainsKey("Content-Security-Policy"))
            {
                context.HttpContext.Response.Headers.Append("Content-Security-Policy", csp);
            }
            // and once again for IE
            if (!context.HttpContext.Response.Headers.ContainsKey("X-Content-Security-Policy"))
            {
                context.HttpContext.Response.Headers.Append("X-Content-Security-Policy", csp);
            }

            // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Referrer-Policy
            var referrer_policy = "no-referrer";
            if (!context.HttpContext.Response.Headers.ContainsKey("Referrer-Policy"))
            {
                context.HttpContext.Response.Headers.Append("Referrer-Policy", referrer_policy);
            }
        }
    }
}
