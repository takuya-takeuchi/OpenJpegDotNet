Param()

$baseDockerfiles = Get-ChildItem  -Recurse base -include Dockerfile

foreach($dockerfile in $baseDockerfiles)
{
   $relativePath = Resolve-Path $dockerfile -Relative
   $dockerfileDirectory = Resolve-Path ((Get-ChildItem $relativePath).Directory.FullName) -Relative
   $basetag = "openjpegdotnet" + $dockerfileDirectory.Trim('.').Replace('\', '/')

   # for cross compile by qemu
   if ($basetag.Contains("/arm/arm"))
   {
      Write-Host "Start 'docker run --rm --privileged multiarch/qemu-user-static --reset -p yes" -ForegroundColor Blue
      docker run --rm --privileged multiarch/qemu-user-static --reset -p yes
   }

   Write-Host "Start 'docker build -t $basetag $dockerfileDirectory'" -ForegroundColor Green
   docker build --force-rm=true -t $basetag $dockerfileDirectory

   if ($lastexitcode -ne 0)
   {
      Write-Host "Failed 'docker build -t $basetag $dockerfileDirectory'" -ForegroundColor Red
      exit -1
   }

   $dockerfileDirectory = $dockerfileDirectory.Replace('base', 'runtime')
   if (Test-Path $dockerfileDirectory)
   {
      $runtimeDockerfileDirectory = $dockerfileDirectory
      $runtimeNameBase = $dockerfileDirectory.Replace('\', '/').Trim('.')
   }
   else
   {
      $path = $dockerfileDirectory.Replace('\', '/').Split('/')
      $os = $path[2]
      $version = $path[3]
      $runtimeDockerfileDirectory = Join-Path 'runtime' $os  | `
                                    Join-Path -ChildPath $version -Resolve
      $runtimeNameBase = $dockerfileDirectory.Replace('\', '/').Trim('.')
   }

   $runtimetag = "openjpegdotnet" + $runtimeNameBase.Replace('base', 'runtime')
   Write-Host "Start 'docker build -t $runtimetag $runtimeDockerfileDirectory --build-arg IMAGE_NAME=""$basetag""'" -ForegroundColor Green
   docker build --network host --force-rm=true -t $runtimetag $runtimeDockerfileDirectory --build-arg IMAGE_NAME="$basetag"

   if ($lastexitcode -ne 0)
   {
      Write-Host "Failed 'docker build -t $runtimetag $runtimeDockerfileDirectory --build-arg IMAGE_NAME=""$basetag""'" -ForegroundColor Red
      exit -1
   }
}