$buildConfig = "Debug"
$BUILD_THIRDPARTY = "OFF"
$VisualStudio = "Visual Studio 16 2019"

$current = $PSScriptRoot

$openjpegDir = Split-Path $current -Parent
$openjpegDir = Join-Path $openjpegDir openjpeg

New-Item -ItemType Directory -Force build > $null
Set-Location build

$buildDir = Get-Location
$installDir = (Join-Path $buildDir install).Replace("`\", "/")

if ($global:IsWindows)
{
    # Build openjpeg
    New-Item -ItemType Directory -Force openjpeg > $null
    Set-Location $(Join-Path $buildDir openjpeg)
    cmake -G "${VisualStudio}" -A x64 -T host=x64 `
          -D BUILD_SHARED_LIBS:BOOL=ON `
          -D CMAKE_BUILD_TYPE:STRING=${buildConfig} `
          -D CMAKE_INSTALL_PREFIX:PATH=`"${installDir}`" `
          -D CMAKE_LIBRARY_PATH:PATH=`"${installDir}`" `
          -D CMAKE_INCLUDE_PATH:PATH=`"${installDir}/include`" `
          -D BUILD_THIRDPARTY:BOOL=${BUILD_THIRDPARTY} `
          "${openjpegDir}"
    cmake --build . --config ${buildConfig}
    cmake --install . --config ${buildConfig}
    
    # Build demo
    Set-Location $buildDir
    $env:OpenJPEG_DIR = $installDir
    cmake -G "${VisualStudio}" -A x64 -T host=x64 `
          -D OpenJPEG_DIR="${installDir}" `
          ..
}
else
{
    # Build openjpeg
    New-Item -ItemType Directory -Force openjpeg > $null
    Set-Location $(Join-Path $buildDir openjpeg)
    cmake -T host=x64 `
          -D BUILD_SHARED_LIBS:BOOL=ON `
          -D CMAKE_BUILD_TYPE:STRING=${buildConfig} `
          -D CMAKE_INSTALL_PREFIX:PATH=`"${installDir}`" `
          -D CMAKE_LIBRARY_PATH:PATH=`"${installDir}`" `
          -D CMAKE_INCLUDE_PATH:PATH=`"${installDir}/include`" `
          -D BUILD_THIRDPARTY:BOOL=${BUILD_THIRDPARTY} `
          "${openjpegDir}"
    cmake --build . --config ${buildConfig}
    cmake --install . --config ${buildConfig}
    
    # Build demo
    Set-Location $buildDir
    $env:OpenJPEG_DIR = $installDir
    cmake -T host=x64 `
          -D OpenJPEG_DIR="${installDir}" `
          ..
}

cmake --build . --config ${buildConfig}


$testdata = Join-Path $current "obama-240p.raw"

$runDir = Join-Path $buildDir ${buildConfig}
if ($global:IsWindows)
{
    $exe = Join-Path $runDir "openjpeg_memory_writer_demo.exe"
    Set-Location $runDir
    $library = Join-Path $buildDir install | `
               Join-Path -ChildPath bin | `
               Join-Path -ChildPath "openjp2.dll"
    Copy-Item ${library} $runDir
    Copy-Item ${testdata} $runDir
    & ${exe}
}
else
{
    $exe = Join-Path $runDir "openjpeg_memory_writer_demo"
    Set-Location $runDir
    $library = Join-Path $buildDir install | `
               Join-Path -ChildPath bin | `
               Join-Path -ChildPath "libopenjp2.so"
    Copy-Item ${library} $runDir
    Copy-Item ${testdata} $runDir
    & ${exe}
}

Set-Location $current