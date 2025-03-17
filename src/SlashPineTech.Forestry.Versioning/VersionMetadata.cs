using System;

namespace SlashPineTech.Forestry.Versioning;

/// <summary>
/// Version metadata describing a build of an application.
/// </summary>
public record VersionMetadata(
    string? Branch,
    string? BuildNumber,
    DateTime BuildTime,
    string? Commit,
    string Version
)
{
    /// <summary>
    /// The source code branch name used to build the artifact.
    /// </summary>
    public string? Branch { get; } = Branch;

    /// <summary>
    /// The CI build number. e.g., 123.
    /// </summary>
    public string? BuildNumber { get; } = BuildNumber;

    /// <summary>
    /// The date/time when the build was started.
    /// </summary>
    public DateTime BuildTime { get; } = BuildTime;

    /// <summary>
    /// The source code commit the artifact was built from.
    /// </summary>
    public string? Commit { get; } = Commit;

    /// <summary>
    /// The application version number.
    /// </summary>
    public string Version { get; } = Version;
}
