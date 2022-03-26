using System;

namespace SlashPineTech.Forestry.Versioning;

/// <summary>
/// A custom attribute written to the AssemblyInfo.cs by MSBuild, specifying
/// the UTC date and time the assembly was built.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly)]
public class BuildDateAttribute : Attribute
{
    public BuildDateAttribute(string value)
    {
        DateTime = DateTime.Parse(value, null, System.Globalization.DateTimeStyles.RoundtripKind);
    }

    public DateTime DateTime { get; }
}
