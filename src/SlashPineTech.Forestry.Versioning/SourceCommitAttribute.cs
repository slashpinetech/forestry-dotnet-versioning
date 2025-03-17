using System;

namespace SlashPineTech.Forestry.Versioning;

/// <summary>
/// A custom attribute written to the AssemblyInfo.cs by MSBuild, specifying
/// the VCS commit that the assembly was built from.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly)]
public class SourceCommitAttribute(string commit) : Attribute
{
    public string Commit { get; } = commit;
}
