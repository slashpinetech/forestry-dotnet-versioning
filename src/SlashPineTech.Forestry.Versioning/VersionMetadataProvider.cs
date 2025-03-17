using System;
using System.Reflection;

namespace SlashPineTech.Forestry.Versioning;

/// <summary>
/// Provides <see cref="VersionMetadata"/> from an assembly.
/// </summary>
public sealed class VersionMetadataProvider(Assembly assembly)
{
    public VersionMetadata Provide()
    {
        var buildDate = assembly.GetCustomAttribute<BuildDateAttribute>()
            ?.DateTime ?? DateTime.UtcNow;

        var buildNumber = assembly.GetCustomAttribute<BuildNumberAttribute>()
            ?.BuildNumber;

        var sourceBranch = assembly.GetCustomAttribute<SourceBranchAttribute>()
            ?.Branch;

        var sourceCommit = assembly.GetCustomAttribute<SourceCommitAttribute>()
            ?.Commit;

        var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()!
            .InformationalVersion;

        return new VersionMetadata(
            sourceBranch,
            buildNumber,
            buildDate,
            sourceCommit,
            version
        );
    }
}
