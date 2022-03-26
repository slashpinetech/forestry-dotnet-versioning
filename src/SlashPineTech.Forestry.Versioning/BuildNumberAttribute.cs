using System;

namespace SlashPineTech.Forestry.Versioning;

/// <summary>
/// A custom attribute written to the AssemblyInfo.cs by MSBuild, specifying
/// the CI build number for the assembly.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly)]
public class BuildNumberAttribute : Attribute
{
    public BuildNumberAttribute(string buildNumber)
    {
        BuildNumber = buildNumber;
    }

    public string BuildNumber { get; }
}
