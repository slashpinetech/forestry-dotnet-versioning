using SlashPineTech.Forestry.Versioning;
using SlashPineTech.Forestry.Versioning.Tests;

[assembly:BuildDate(MetadataConstants.BuildDate)]
[assembly:BuildNumber(MetadataConstants.BuildNumber)]
[assembly:SourceBranch(MetadataConstants.Branch)]
[assembly:SourceCommit(MetadataConstants.Commit)]
namespace SlashPineTech.Forestry.Versioning.Tests;

/// <summary>
/// Constants that are used in the build metadata above and then in the
/// assertions in <see cref="BuildMetadataProviderTests"/>.
/// </summary>
public static class MetadataConstants
{
    public const string Branch = "ref/heads/main";
    public const string BuildNumber = "1";
    public const string BuildDate = "2021-10-25T00:00:00Z";
    public const string Commit = "ad000b67c561436a3d31e02fdfb586601f922acf";
    public const string Version = "1.0.0";
}
