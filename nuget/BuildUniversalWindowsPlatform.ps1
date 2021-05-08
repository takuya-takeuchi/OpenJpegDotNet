Param()

# import class and function
$ScriptPath = $PSScriptRoot
$OpenJpegDotNetRoot = Split-Path $ScriptPath -Parent
$NugetPath = Join-Path $OpenJpegDotNetRoot "nuget" | `
             Join-Path -ChildPath "BuildUtils.ps1"
import-module $NugetPath -function *

$OperatingSystem="win"

# Store current directory
$Current = Get-Location
$OpenJpegDotNetRoot = (Split-Path (Get-Location) -Parent)
$OpenJpegDotNetSourceRoot = Join-Path $OpenJpegDotNetRoot src

$BuildSourceHash = [Config]::GetBinaryLibraryWindowsHash()

$BuildTargets = @()
$BuildTargets += New-Object PSObject -Property @{ Platform = "uwp"; Target = "cpu";  Architecture = 64; RID = "${OperatingSystem}10-x64"; }
$BuildTargets += New-Object PSObject -Property @{ Platform = "uwp"; Target = "cpu";  Architecture = 32; RID = "${OperatingSystem}10-x86"; }
$BuildTargets += New-Object PSObject -Property @{ Platform = "uwp"; Target = "arm";  Architecture = 32; RID = "${OperatingSystem}10-arm"; }
$BuildTargets += New-Object PSObject -Property @{ Platform = "uwp"; Target = "arm";  Architecture = 64; RID = "${OperatingSystem}10-arm64"; }

foreach ($BuildTarget in $BuildTargets)
{
   $platform = $BuildTarget.Platform
   $target = $BuildTarget.Target
   $architecture = $BuildTarget.Architecture
   $rid = $BuildTarget.RID
   $option = ""

   $Config = [Config]::new($OpenJpegDotNetRoot, "Release", $target, $architecture, $platform, $option)
   $libraryDir = Join-Path "artifacts" $Config.GetArtifactDirectoryName()
   $build = $Config.GetBuildDirectoryName($OperatingSystem)

   foreach ($key in $BuildSourceHash.keys)
   {
      $srcDir = Join-Path $OpenJpegDotNetSourceRoot $key

      # Move to build target directory
      Set-Location -Path $srcDir

      $arc = $Config.GetArchitectureName()
      Write-Host "Build $key [$arc] for $target" -ForegroundColor Green
      Build -Config $Config

      if ($lastexitcode -ne 0)
      {
         Set-Location -Path $Current
         exit -1
      }
   }

   # Copy output binary
   foreach ($key in $BuildSourceHash.keys)
   {
      $srcDir = Join-Path $OpenJpegDotNetSourceRoot $key
      $dll = $BuildSourceHash[$key]
      $dstDir = Join-Path $Current $libraryDir

      CopyToArtifact -configuration "Release" -srcDir $srcDir -build $build -libraryName $dll -dstDir $dstDir -rid $rid
   }
}

# Move to Root directory 
Set-Location -Path $Current