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

Set-StrictMode -Version Latest

$RidOperatingSystem="linux"
$OperatingSystem="ubuntu"
$OperatingSystemVersion="18"

# Store current directory
$Current = Get-Location
$OpenJpegDotNetRoot = (Split-Path (Get-Location) -Parent)
$DockerDir = Join-Path $OpenJpegDotNetRoot docker

# https://github.com/dotnet/coreclr/issues/9265
# linux-x86 does not support
$BuildTargets = @()
# $BuildTargets += New-Object PSObject -Property @{Target = "cpu";  Architecture = 64; Package = "OpenJpegDotNet";     PlatformTarget="x64";   Postfix = "/x64";   RID = "$RidOperatingSystem-x64"; }
$BuildTargets += New-Object PSObject -Property @{Target = "arm";  Architecture = 64; Package = "OpenJpegDotNet.ARM"; PlatformTarget="arm64"; Postfix = "/arm64"; RID = "$RidOperatingSystem-arm64"; }
# $BuildTargets += New-Object PSObject -Property @{Target = "arm";  Architecture = 32; Package = "OpenJpegDotNet.ARM"; PlatformTarget="arm";   Postfix = "/arm";   RID = "$RidOperatingSystem-arm"; }

Set-Location -Path $DockerDir

foreach($BuildTarget in $BuildTargets)
{
   $target = $BuildTarget.Target
   $package = $BuildTarget.Package
   $platformTarget = $BuildTarget.PlatformTarget
   $rid = $BuildTarget.RID
   $postfix = $BuildTarget.Postfix
   $versionStr = $Version

   if ([string]::IsNullOrEmpty($Version))
   {
      $packages = Get-ChildItem "${Current}/*" -include *.nupkg | `
                  Where-Object -FilterScript {$_.Name -match "${package}\.([0-9\.]+).nupkg"} | `
                  Sort-Object -Property Name -Descending
      foreach ($file in $packages)
      {
         Write-Host $file -ForegroundColor Blue
      }

      foreach ($file in $packages)
      {
         $file = Split-Path $file -leaf
         $file = $file -replace "${package}\.",""
         $file = $file -replace "\.nupkg",""
         $versionStr = $file
         break
      }

      if ([string]::IsNullOrEmpty($versionStr))
      {
         Write-Host "Version is not specified" -ForegroundColor Red
         exit -1
      }
   }

   $dockername = "openjpegdotnet/test/$OperatingSystem/$OperatingSystemVersion/$Target" + $postfix
   $imagename  = "openjpegdotnet/runtime/$OperatingSystem/$OperatingSystemVersion/$Target" + $postfix

   # for cross compile by qemu
   if ($Target -eq "arm")
   {
      Write-Host "Start 'docker run --rm --privileged multiarch/qemu-user-static --reset -p yes" -ForegroundColor Blue
      docker run --rm --privileged multiarch/qemu-user-static --reset -p yes
   }

   $DockerFileDir = Join-Path $DockerDir test  | `
                    Join-Path -ChildPath $OperatingSystem | `
                    Join-Path -ChildPath $OperatingSystemVersion | `
                    Join-Path -ChildPath $target | `
                    Join-Path -ChildPath $platformTarget

   Write-Host "Start docker build -t $dockername $DockerFileDir --build-arg IMAGE_NAME=""$imagename""" -ForegroundColor Green
   docker build --network host --force-rm=true -t $dockername $DockerFileDir --build-arg IMAGE_NAME="$imagename"

   if ($lastexitcode -ne 0)
   {
      Write-Host "Test Fail for $package" -ForegroundColor Red
      Set-Location -Path $Current
      exit -1
   }
   
   Write-Host "Start docker run --network host --rm -v ""$($OpenJpegDotNetRoot):/opt/data/OpenJpegDotNet"" -e LOCAL_UID=$(id -u $env:USER) -e LOCAL_GID=$(id -g $env:USER) -t ""$dockername"" $versionStr $package $platformTarget $rid" -ForegroundColor Green
   docker run --network host `
              --rm `
              -v "$($OpenJpegDotNetRoot):/opt/data/OpenJpegDotNet" `
              -e "LOCAL_UID=$(id -u $env:USER)" `
              -e "LOCAL_GID=$(id -g $env:USER)" `
              -t "$dockername" $versionStr $package $platformTarget $rid

   if ($lastexitcode -ne 0)
   {
      Set-Location -Path $Current
      exit -1
   }
}

# Move to Root directory
Set-Location -Path $Current