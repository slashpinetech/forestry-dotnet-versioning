using System.Reflection;
using Shouldly;
using Xunit;

namespace SlashPineTech.Forestry.Versioning.Tests;

/// <summary>
/// Unit tests for <see cref="VersionMetadataProvider"/>.
/// </summary>
public class VersionMetadataProviderTests
{
    [Fact]
    public void VersionMetadataProvider_Provide_Returns_VersionMetadata_With_Values_From_Assembly_Attributes()
    {
        var provider = new VersionMetadataProvider(Assembly.GetExecutingAssembly());
        var metadata = provider.Provide();

        metadata.Branch.ShouldBe(MetadataConstants.Branch);
        metadata.BuildNumber.ShouldBe(MetadataConstants.BuildNumber);
        metadata.BuildTime.Year.ShouldBe(2021);
        metadata.BuildTime.Month.ShouldBe(10);
        metadata.BuildTime.Day.ShouldBe(25);
        metadata.Commit.ShouldBe(MetadataConstants.Commit);
        metadata.Version.ShouldBe(MetadataConstants.Version);
    }
}
