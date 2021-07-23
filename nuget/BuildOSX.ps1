Param()

# import class and function
$ScriptPath = $PSScriptRoot
$OpenJpegDotNetRoot = Split-Path $ScriptPath -Parent
$ScriptPath = Join-Path $OpenJpegDotNetRoot "nuget" | `
              Join-Path -ChildPath "BuildUtils.ps1"
import-module $ScriptPath -function *

$OperatingSystem="osx"

# Store current directory
$Current = Get-Location

$BuildSourceHash = [Config]::GetBinaryLibraryOSXHash()

# https://docs.microsoft.com/ja-jp/dotnet/core/rid-catalog#macos-rids
# osx-x86 does not support
$BuildTargets = @()
$BuildTargets += [BuildTarget]::new("desktop", "cpu", 64, "$OperatingSystem-x64", "" )

foreach($BuildTarget in $BuildTargets)
{
   $BuildTarget.OperatingSystem = ${OperatingSystem}
   
   $ret = [Config]::Build($OpenJpegDotNetRoot, $False, $BuildSourceHash, $BuildTarget)
   if ($ret -eq $False)
   {
      Set-Location -Path $Current
      exit -1
   }
}

# Move to Root directory 
Set-Location -Path $Current