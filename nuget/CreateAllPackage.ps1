$targets = @(
   "CPU"
)

$ScriptPath = $PSScriptRoot
$OpenJpegDotNetRoot = Split-Path $ScriptPath -Parent

$source = Join-Path $OpenJpegDotNetRoot src | `
          Join-Path -ChildPath OpenJpegDotNet
dotnet restore ${source}
dotnet build -c Release ${source}

foreach ($target in $targets)
{
   pwsh CreatePackage.ps1 $target
}