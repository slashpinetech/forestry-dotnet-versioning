using System;
using System.Reflection;

namespace SlashPineTech.Forestry.Versioning;

/// <summary>
/// Provides <see cref="BuildMetadata"/> from an assembly.
/// </summary>
public sealed class BuildMetadataProvider
{
    private readonly Assembly _assembly;

    public BuildMetadataProvider(Assembly assembly)
    {
        _assembly = assembly;
    }

    public BuildMetadata Provide()
    {
        var buildDate = _assembly.GetCustomAttribute<BuildDateAttribute>()
            ?.DateTime ?? DateTime.UtcNow;

        var buildNumber = _assembly.GetCustomAttribute<BuildNumberAttribute>()
            ?.BuildNumber;

        var sourceBranch = _assembly.GetCustomAttribute<SourceBranchAttribute>()
            ?.Branch;

        var sourceCommit = _assembly.GetCustomAttribute<SourceCommitAttribute>()
            ?.Commit;

        var version = _assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()!
            .InformationalVersion;

        return new BuildMetadata(
            sourceBranch,
            buildNumber,
            buildDate,
            sourceCommit,
            version
        );
    }
}
