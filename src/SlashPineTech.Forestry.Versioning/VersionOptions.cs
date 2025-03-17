using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SlashPineTech.Forestry.Versioning;

/// <summary>
/// Contains options for the <see cref="VersionMiddleware"/>.
/// </summary>
public class VersionOptions
{
    /// <summary>
    /// Gets or sets a delegate used to write the response.
    /// </summary>
    /// <remarks>
    /// The default value is a delegate that will write an <c>application/json</c>
    /// response.
    /// </remarks>
    public Func<HttpContext, VersionMetadata, Task> ResponseWriter { get; set; } = VersionResponseWriters.WriteJson;

    /// <summary>
    /// Gets or sets a value that controls whether responses from the version
    /// middleware can be cached.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The version middleware does not perform caching of any kind. This setting
    /// configures whether the middleware will apply headers to the HTTP response
    /// that instruct clients to avoid caching.
    /// </para>
    /// <para>
    /// If the value is <c>false</c> the version middleware will set or override
    /// the <c>Cache-Control</c>, <c>Expires</c>, and <c>Pragma</c> headers to
    /// prevent response caching. If the value is <c>true</c> the version
    /// middleware will not modify the cache headers of the response.
    /// </para>
    /// </remarks>
    public bool AllowCachingResponses { get; set; }
}
