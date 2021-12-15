
# Hyperbee Core

This solution containes foundational libraries for Hyperbee projects.

DO NOT PLACE BUSINESS LOGIC IN THESE LIBRARIES OR YOU WILL BE FIRED!


## Projects

| Project           | Description
|:------------------|:------------------------------
| Hyperbee.Core     | System classes 
| Hyperbee.Cloud    | Cloud services
| Hyperbee.Code     | Roslyn code and rules
| Hyperbee.Json     | JsonPath
| Hyperbee.Pipeline | Pipelines and Command patterns

## Publish Nuget Package

Publish your nugets

* Open Visual Studio `terminal window`
* Select `Developer PowerShell`

```powershell
# From Developer PowerShell
msbuild -v:m -p:PublishPackage=true
```
 
For convenience, the msbuild command is exposed in the solution powershell helper. See section below.

## Powershell Helpers

The solution includes a powershell helper. This helper includes:

| Command          | Description
| ---------------- | ----------------------------------------
| Publish-Packages | Publish packages to the default feed
| Remove-Packages  | Remove stale packages from the default feed

```powershell
# From Developer PowerShell
Import-Module ./solution-helper
Publish-Packages
```

### Solution Helper Auto Import
`Developer Powerhell` can be configured to auto import your helpers. This will eliminate the need to
manually call `Import-Module`.

* Open `Developer Powershell`
* From the powershell terminal window execute `code $profile`
* Add the following code

```powershell
if ( Test-Path ./solution-helper.psm1 ) {
    Write-Host 'Loading solution helpers ...'
    Import-Module ./solution-helper
}
```

* Save and restart Visual Studio


