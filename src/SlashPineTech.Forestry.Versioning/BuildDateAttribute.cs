using System;

namespace SlashPineTech.Forestry.Versioning;

/// <summary>
/// A custom attribute written to the AssemblyInfo.cs by MSBuild, specifying
/// the UTC date and time the assembly was built.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly)]
public class BuildDateAttribute(string value) : Attribute
{
    public DateTime DateTime { get; } = DateTime.Parse(value, null, System.Globalization.DateTimeStyles.RoundtripKind);
}
