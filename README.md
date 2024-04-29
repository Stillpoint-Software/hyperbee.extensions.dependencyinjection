
# Hyperbee Extensions Dependency Injection

This solution containes libraries for dependency injection.


## Projects

| Project                                 | Description
|:----------------------------------------|:------------------------------
| Hyperbee.Extensions.DependencyInjection | General purpose service registration helpers
| Hyperbee.Extensions.Lamar               | Lamar service registration helpers

## Publish Nuget Package

Publish your nugets

* Open Visual Studio `terminal window`
* Select `Developer PowerShell`

```powershell
# From Developer PowerShell
$timestamp = [System.DateTime]::UtcNow.ToString( 'yyMMddHHmmss' )
dotnet pack --no-build --configuration $Configuration --output ./output --version-suffix "local$timestamp" -p:PushAfterPack=true
```
 
For convenience, the msbuild command is exposed in the solution powershell helper. See section below.

## Powershell Helpers

The solution includes a powershell helper. This helper includes:

| Command          | Description
| ---------------- | -----------------------------------------
| Publish-Packages | Publish packages to the default feed
| Resize-Feed      | Feed package retention maintenance
| Update-Version   | Increment build Major,Minor,Patch Version

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


# Status

| Branch     | Action                                                                                                                                                                                                                      |
|------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `develop`  | [![Build status](https://github.com/Stillpoint-Software/Hyperbee.Extensions.DependencyInjection/actions/workflows/publish.yml/badge.svg?branch=develop)](https://github.com/Stillpoint-Software/Hyperbee.Extensions.DependencyInjection/actions/workflows/publish.yml)  |
| `main`     | [![Build status](https://github.com/Stillpoint-Software/Hyperbee.Extensions.DependencyInjection/actions/workflows/publish.yml/badge.svg)](https://github.com/Stillpoint-Software/Hyperbee.Extensions.DependencyInjection/actions/workflows/publish.yml)                 |


[![Hyperbee.Extensions.DependencyInjection](https://github.com/Stillpoint-Software/Hyperbee.Extensions.DependencyInjection/blob/main/assets/hyperbee.svg?raw=true)](https://github.com/Stillpoint-Software/Hyperbee.Extensions.DependencyInjection)

# Help
 See [Todo](https://github.com/Stillpoint-Software/Hyperbee.Extensions.DependencyInjection/blob/main/docs/todo.md)



