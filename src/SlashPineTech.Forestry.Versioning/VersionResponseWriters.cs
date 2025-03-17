using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace SlashPineTech.Forestry.Versioning;

public static class VersionResponseWriters
{
    public static async Task WriteJson(HttpContext httpContext, VersionMetadata version)
    {
        httpContext.Response.ContentType = "application/json";

        var options = httpContext.RequestServices.GetRequiredService<IOptions<JsonOptions>>().Value;
        var json = JsonSerializer.Serialize(version, options.JsonSerializerOptions);

        await httpContext.Response.WriteAsync(json).ConfigureAwait(false);
    }
}
