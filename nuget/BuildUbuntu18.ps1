Param()

# import class and function
$ScriptPath = $PSScriptRoot
$OpenJpegDotNetRoot = Split-Path $ScriptPath -Parent
$ScriptPath = Join-Path $OpenJpegDotNetRoot "nuget" | `
              Join-Path -ChildPath "BuildUtils.ps1"
import-module $ScriptPath -function *

$OperatingSystem="linux"
$Distribution="ubuntu"
$DistributionVersion="18"

# Store current directory
$Current = Get-Location

$BuildSourceHash = [Config]::GetBinaryLibraryLinuxHash()

# https://github.com/dotnet/coreclr/issues/9265
# linux-x86 does not support
$BuildTargets = @()
$BuildTargets += [BuildTarget]::new("desktop", "cpu", 64, "$OperatingSystem-x64",   "/x64" )
$BuildTargets += [BuildTarget]::new("desktop", "arm", 64, "$OperatingSystem-arm64", "/arm64" )
$BuildTargets += [BuildTarget]::new("desktop", "arm", 32, "$OperatingSystem-arm",   "/arm" )

foreach($BuildTarget in $BuildTargets)
{
   $BuildTarget.OperatingSystem     = ${OperatingSystem}
   $BuildTarget.Distribution        = ${Distribution}
   $BuildTarget.DistributionVersion = ${DistributionVersion}
   
   $ret = [Config]::Build($OpenJpegDotNetRoot, $True, $BuildSourceHash, $BuildTarget)
   if ($ret -eq $False)
   {
      Set-Location -Path $Current
      exit -1
   }
}

# Move to Root directory 
Set-Location -Path $Current
