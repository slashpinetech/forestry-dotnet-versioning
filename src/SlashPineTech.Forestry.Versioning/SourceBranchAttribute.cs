using System;

namespace SlashPineTech.Forestry.Versioning;

/// <summary>
/// A custom attribute written to the AssemblyInfo.cs by MSBuild, specifying
/// the VCS branch that the assembly was built from.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly)]
public class SourceBranchAttribute(string branch) : Attribute
{
    public string Branch { get; } = branch;
}
