using System;

namespace SlashPineTech.Forestry.Versioning;

/// <summary>
/// A custom attribute written to the AssemblyInfo.cs by MSBuild, specifying
/// the CI build number for the assembly.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly)]
public class BuildNumberAttribute(string buildNumber) : Attribute
{
    public string BuildNumber { get; } = buildNumber;
}
