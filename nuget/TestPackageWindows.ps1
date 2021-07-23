#***************************************
#Arguments
#%1: Version of Release (19.17.0.yyyyMMdd)
#***************************************
Param([Parameter(
      Mandatory=$False,
      Position = 1
      )][string]
      $Version
)

# import class and function
$ScriptPath = $PSScriptRoot
$OpenJpegDotNetRoot = Split-Path $ScriptPath -Parent
$ScriptPath = Join-Path $OpenJpegDotNetRoot "nuget" | `
              Join-Path -ChildPath "TestPackage.ps1"
import-module $ScriptPath -function *

Set-StrictMode -Version Latest

$OperatingSystem="win"

# Store current directory
$Current = Get-Location

$BuildTargets = @()
$BuildTargets += New-Object PSObject -Property @{Package = "OpenJpegDotNet";     PlatformTarget="x64"; RID = "$OperatingSystem-x64"; }
# $BuildTargets += New-Object PSObject -Property @{Package = "OpenJpegDotNet";     PlatformTarget="x86"; RID = "$OperatingSystem-x86"; }

foreach($BuildTarget in $BuildTargets)
{
   $package = $BuildTarget.Package
   $platformTarget = $BuildTarget.PlatformTarget
   $runtimeIdentifier = $BuildTarget.RID
   $versionStr = Get-Version $Version $Current

   $command = ".\\TestPackage.ps1 -Package ${package} -Version $versionStr -PlatformTarget ${platformTarget} -RuntimeIdentifier ${runtimeIdentifier}"
   Invoke-Expression $command

   if ($lastexitcode -ne 0)
   {
      Set-Location -Path $Current
      exit -1
   }
}