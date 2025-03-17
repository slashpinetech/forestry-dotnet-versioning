using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace SlashPineTech.Forestry.Versioning;

/// <summary>
/// Middleware that exposes a version info endpoint that describes which
/// version/build of the application is currently deployed.
/// </summary>
public class VersionMiddleware(
    RequestDelegate next,
    VersionMetadata versionMetadata,
    IOptions<VersionOptions> versionOptions)
{
    private readonly VersionOptions versionOptions = versionOptions.Value;

    public async Task InvokeAsync(HttpContext httpContext)
    {
        ArgumentNullException.ThrowIfNull(httpContext);

        httpContext.Response.StatusCode = 200;

        if (!versionOptions.AllowCachingResponses)
        {
            var headers = httpContext.Response.Headers;
            headers.CacheControl = "no-store, no-cache";
            headers.Pragma = "no-cache";
            headers.Expires = "Thu, 01 Jan 1970 00:00:00 GMT";
        }

        await versionOptions.ResponseWriter(httpContext, versionMetadata).ConfigureAwait(false);
    }
}
