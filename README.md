[![MIT License](https://img.shields.io/github/license/slashpinetech/forestry-dotnet-versioning?color=1F3B2B&style=flat-square)](https://github.com/slashpinetech/forestry-dotnet-versioning/blob/main/LICENSE)

# Forestry .NET -- Versioning

Forestry .NET is a set of open-source libraries for building modern web
applications using ASP.NET Core.

This versioning package adds support for embedding build-time metadata into an
assembly for use when the application is running.

## Usage

### Configuring your .csproj

Add the following `<ItemGroup>` to the .csproj for your main assembly.

```xml
<ItemGroup>
  <AssemblyAttribute Include="SlashPineTech.Forestry.Versioning.BuildDateAttribute">
    <_Parameter1>$([System.DateTime]::UtcNow.ToString("o"))</_Parameter1>
  </AssemblyAttribute>
  <AssemblyAttribute Include="SlashPineTech.Forestry.Versioning.BuildNumberAttribute" Condition="$(BuildNumber) != ''">
    <_Parameter1>$(BuildNumber)</_Parameter1>
  </AssemblyAttribute>
  <AssemblyAttribute Include="SlashPineTech.Forestry.Versioning.SourceBranchAttribute" Condition="$(Branch) != ''">
    <_Parameter1>$(Branch)</_Parameter1>
  </AssemblyAttribute>
  <AssemblyAttribute Include="SlashPineTech.Forestry.Versioning.SourceCommitAttribute" Condition="$(Commit) != ''">
    <_Parameter1>$(Commit)</_Parameter1>
  </AssemblyAttribute>
</ItemGroup>
```

### Configuring your CI

Next, configure your CI to pass metadata to dotnet build (or package).

Note: All CI platforms expose environment variables containing the metadata you
need. The example below is using GitHub's environment variables. Consult the
documentation for your CI platform for the specific variables to use.

```
dotnet build -p:BuildNumber=$GITHUB_RUN_NUMBER -p:Branch=$GITHUB_REF -p:Commit=$GITHUB_SHA
```

### Startup

Use the `BuildMetadataProvider` to register a singleton instance of `BuildMetadata`
with all of the metadata that was compiled into the assembly in the prior step.

```c#
services.AddSingleton(_ => new BuildMetadataProvider(typeof(Startup).Assembly).Provide());
```

### Wrapping up

Now you can inject `BuildMetadata` anywhere you need to access this information,
such as a `/version` endpoint that will return this as JSON or an MVC or Razor Page
that will display this to administrators.
