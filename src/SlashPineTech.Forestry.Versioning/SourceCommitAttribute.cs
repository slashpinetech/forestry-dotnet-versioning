using System;

namespace SlashPineTech.Forestry.Versioning;

/// <summary>
/// A custom attribute written to the AssemblyInfo.cs by MSBuild, specifying
/// the VCS commit that the assembly was built from.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly)]
public class SourceCommitAttribute : Attribute
{
    public SourceCommitAttribute(string commit)
    {
        Commit = commit;
    }

    public string Commit { get; }
}
