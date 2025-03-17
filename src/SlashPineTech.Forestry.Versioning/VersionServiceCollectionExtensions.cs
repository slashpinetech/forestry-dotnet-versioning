using System;
using System.Reflection;
using SlashPineTech.Forestry.Versioning;

namespace Microsoft.Extensions.DependencyInjection;

public static class VersionServiceCollectionExtensions
{
    public static IServiceCollection AddVersionMetadata(this IServiceCollection services, Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(services);
        return services.AddSingleton(_ => new VersionMetadataProvider(assembly).Provide());
    }
}
