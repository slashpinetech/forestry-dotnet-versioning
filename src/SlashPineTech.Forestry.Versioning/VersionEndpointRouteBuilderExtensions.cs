using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using SlashPineTech.Forestry.Versioning;

namespace Microsoft.AspNetCore.Builder;

public static class VersionEndpointRouteBuilderExtensions
{
    private const string DefaultDisplayName = "Version";

    public static IEndpointConventionBuilder MapVersion(this IEndpointRouteBuilder endpoints, [StringSyntax("Route")] string pattern)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        return MapVersionCore(endpoints, pattern, null);
    }

    public static IEndpointConventionBuilder MapVersion(this IEndpointRouteBuilder endpoints, [StringSyntax("Route")] string pattern, VersionOptions? options)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        return MapVersionCore(endpoints, pattern, options);
    }

    private static IEndpointConventionBuilder MapVersionCore(IEndpointRouteBuilder endpoints, string pattern, VersionOptions? options)
    {
        if (endpoints.ServiceProvider.GetService(typeof(VersionMetadata)) == null)
        {
            throw new InvalidOperationException("Attempted to call .MapVersion() without calling .AddVersionMetadata() in ConfigureServices(...).");
        }

        var args = options != null ? new[] { Options.Create(options) } : Array.Empty<object>();

        var pipeline = endpoints.CreateApplicationBuilder()
            .UseMiddleware<VersionMiddleware>(args)
            .Build();

        return endpoints.Map(pattern, pipeline).WithDisplayName(DefaultDisplayName);
    }
}
