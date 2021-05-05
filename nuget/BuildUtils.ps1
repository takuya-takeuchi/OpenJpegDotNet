class Config
{

   $ConfigurationArray =
   @(
      "Debug",
      "Release"
   )

   $TargetArray =
   @(
      "cpu",
      "arm"
   )

   $PlatformArray =
   @(
      "desktop",
      "android",
      "ios",
      "uwp"
   )

   $ArchitectureArray =
   @(
      32,
      64
   )

   $VisualStudio = "Visual Studio 16 2019"

   $VisualStudioConsole = "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\VC\Auxiliary\Build\vcvars64.bat"
   
   static $BuildLibraryWindowsHash = 
   @{
      "OpenJpegDotNet.Native"     = "OpenJpegDotNetNative.dll";
   }
   
   static $BuildLibraryLinuxHash = 
   @{
      "OpenJpegDotNet.Native"     = "libOpenJpegDotNetNative.so";
   }
   
   static $BuildLibraryOSXHash = 
   @{
      "OpenJpegDotNet.Native"     = "libOpenJpegDotNetNative.dylib";
   }
   
   static $BuildLibraryIOSHash = 
   @{
      "OpenJpegDotNet.Native"     = "libOpenJpegDotNetNative.a";
   }

   [string]   $_Root
   [string]   $_Configuration
   [int]      $_Architecture
   [string]   $_Target
   [string]   $_Platform
   [string]   $_MklDirectory
   [string]   $_AndroidABI
   [string]   $_AndroidNativeAPILevel

   #***************************************
   # Arguments
   #  %1: Root directory of OpenJpegDotNet
   #  %2: Build Configuration (Release/Debug)
   #  %3: Target (cpu/arm)
   #  %4: Architecture (32/64)
   #  %5: Platform (desktop/android/ios/uwp)
   #  %6: Optional Argument
   #***************************************
   Config(  [string]$Root,
            [string]$Configuration,
            [string]$Target,
            [int]   $Architecture,
            [string]$Platform,
            [string]$Option
         )
   {
      if ($this.ConfigurationArray.Contains($Configuration) -eq $False)
      {
         $candidate = $this.ConfigurationArray -join "/"
         Write-Host "Error: Specify build configuration [${candidate}]" -ForegroundColor Red
         exit -1
      }

      if ($this.TargetArray.Contains($Target) -eq $False)
      {
         $candidate = $this.TargetArray -join "/"
         Write-Host "Error: Specify Target [${candidate}]" -ForegroundColor Red
         exit -1
      }

      if ($this.ArchitectureArray.Contains($Architecture) -eq $False)
      {
         $candidate = $this.ArchitectureArray -join "/"
         Write-Host "Error: Specify Architecture [${candidate}]" -ForegroundColor Red
         exit -1
      }

      if ($this.PlatformArray.Contains($Platform) -eq $False)
      {
         $candidate = $this.PlatformArray -join "/"
         Write-Host "Error: Specify Platform [${candidate}]" -ForegroundColor Red
         exit -1
      }

      switch ($Platform)
      {
         "android"
         {
            $decoded = [Config]::Base64Decode($Option)
            $setting = ConvertFrom-Json $decoded
            $this._AndroidABI            = $setting.ANDROID_ABI
            $this._AndroidNativeAPILevel = $setting.ANDROID_NATIVE_API_LEVEL
         }
      }

      $this._Root = $Root
      $this._Configuration = $Configuration
      $this._Architecture = $Architecture
      $this._Target = $Target
      $this._Platform = $Platform
   }

   static [string] Base64Encode([string]$text)
   {
      $byte = ([System.Text.Encoding]::Default).GetBytes($text)
      return [Convert]::ToBase64String($byte)
   }

   static [string] Base64Decode([string]$base64)
   {
      $byte = [System.Convert]::FromBase64String($base64)
      return [System.Text.Encoding]::Default.GetString($byte)
   }

   static [hashtable] GetBinaryLibraryWindowsHash()
   {
      return [Config]::BuildLibraryWindowsHash
   }

   static [hashtable] GetBinaryLibraryOSXHash()
   {
      return [Config]::BuildLibraryOSXHash
   }

   static [hashtable] GetBinaryLibraryLinuxHash()
   {
      return [Config]::BuildLibraryLinuxHash
   }

   static [hashtable] GetBinaryLibraryIOSHash()
   {
      return [Config]::BuildLibraryIOSHash
   }

   [string] GetRootDir()
   {
      return $this._Root
   }

   [string] GetOpenJpegRootDir()
   {
      return   Join-Path $this.GetRootDir() src |
               Join-Path -ChildPath openjpeg
   }

   [string] GetNugetDir()
   {
      return   Join-Path $this.GetRootDir() nuget
   }

   [int] GetArchitecture()
   {
      return $this._Architecture
   }

   [string] GetConfigurationName()
   {
      return $this._Configuration
   }

   [string] GetAndroidABI()
   {
      return $this._AndroidABI
   }

   [string] GetAndroidNativeAPILevel()
   {
      return $this._AndroidNativeAPILevel
   }

   [string] GetArtifactDirectoryName()
   {
      $target = $this._Target
      $platform = $this._Platform
      $name = ""

      switch ($platform)
      {
         "desktop"
         {
            $name = $target
         }
         "android"
         {
            $name = $platform
         }
         "ios"
         {
            $name = $platform
         }
         "uwp"
         {
            $name = Join-Path $platform $target
         }
      }

      return $name
   }

   [string] GetOSName()
   {
      $os = ""

      if ($global:IsWindows)
      {
         $os = "win"
      }
      elseif ($global:IsMacOS)
      {
         $os = "osx"
      }
      elseif ($global:IsLinux)
      {
         $os = "linux"
      }
      else
      {
         Write-Host "Error: This plaform is not support" -ForegroundColor Red
         exit -1
      }

      return $os
   }

   [string] GetIntelMklDirectory()
   {
      return [string]$this._MklDirectory
   }

   [string] GetArchitectureName()
   {
      $arch = ""
      $target = $this._Target
      $architecture = $this._Architecture

      if ($target -eq "arm")
      {
         if ($architecture -eq 32)
         {
            $arch = "arm"
         }
         elseif ($architecture -eq 64)
         {
            $arch = "arm64"
         }
      }
      else
      {
         if ($architecture -eq 32)
         {
            $arch = "x86"
         }
         elseif ($architecture -eq 64)
         {
            $arch = "x64"
         }
      }

      return $arch
   }

   [string] GetTarget()
   {
      return $this._Target
   }

   [string] GetPlatform()
   {
      return $this._Platform
   }

   [string] GetBuildDirectoryName([string]$os="")
   {
      if (![string]::IsNullOrEmpty($os))
      {
         $osname = $os
      }
      elseif (![string]::IsNullOrEmpty($env:TARGETRID))
      {
         $osname = $env:TARGETRID
      }
      else
      {
         $osname = $this.GetOSName()
      }
      
      $target = $this._Target
      $platform = $this._Platform
      $architecture = $this.GetArchitectureName()

      return "build_${osname}_${platform}_${target}_${architecture}"
   }

   [string] GetVisualStudio()
   {
      return $this.VisualStudio
   }

   [string] GetVisualStudioConsole()
   {
      return $this.VisualStudioConsole
   }

   [string] GetVisualStudioArchitecture()
   {
      $architecture = $this._Architecture
      $target = $this._Target
      
      if ($target -eq "arm")
      {
         if ($architecture -eq 32)
         {
            return "ARM"
         }
         elseif ($architecture -eq 64)
         {
            return "ARM64"
         }
      }
      else
      {
         if ($architecture -eq 32)
         {
            return "Win32"
         }
         elseif ($architecture -eq 64)
         {
            return "x64"
         }
      }

      Write-Host "${architecture} and ${target} do not support" -ForegroundColor Red
      exit -1
   }

}

function CallVisualStudioDeveloperConsole([Config]$Config)
{
   $console = $Config.GetVisualStudioConsole()
   cmd.exe /c "call `"${console}`" && set > %temp%\vcvars.txt"

   Get-Content "${env:temp}\vcvars.txt" | Foreach-Object {
      if ($_ -match "^(.*?)=(.*)$") {
        Set-Content "env:\$($matches[1])" $matches[2]
      }
    }
}

class ThirdPartyBuilder
{

   [Config]   $_Config

   ThirdPartyBuilder( [Config]$Config )
   {
      $this._Config = $Config
   }

   [string] BuildOpenJpeg()
   {
      $ret = ""
      $current = Get-Location
      $buildConfig = $this._Config.GetConfigurationName()

      try
      {
         Write-Host "Start Build OpenJpeg" -ForegroundColor Green

         $openjpegDir = $this._Config.GetOpenJpegRootDir()
         $openjpegTarget = Join-Path $current openjpeg
         New-Item $openjpegTarget -Force -ItemType Directory
         Set-Location $openjpegTarget
         $current2 = Get-Location
         $installDir = (Join-Path $current2 install).Replace("`\", "/")
         $ret = $installDir

         # OSX failed to build due to zlib
         $BUILD_THIRDPARTY="OFF"

         if ($global:IsWindows)
         {
            $VS = $this._Config.GetVisualStudio()
            $VSARC = $this._Config.GetVisualStudioArchitecture()

            if ($this._Config.GetPlatform() -eq "uwp")
            {
               Write-Host "   cmake -G `"${VS}`" -A ${VSARC} -T host=x64 `
         -D BUILD_SHARED_LIBS:BOOL=OFF `
         -D CMAKE_SYSTEM_NAME=WindowsStore `
         -D CMAKE_SYSTEM_VERSION=`"10.0`" `
         -D CMAKE_BUILD_TYPE:STRING=${buildConfig} `
         -D CMAKE_INSTALL_PREFIX:PATH=`"${installDir}`" `
         -D CMAKE_LIBRARY_PATH:PATH=`"${installDir}`" `
         -D CMAKE_INCLUDE_PATH:PATH=`"${installDir}/include`" `
         -D BUILD_THIRDPARTY:BOOL=${BUILD_THIRDPARTY} `
         `"$openjpegDir`"" -ForegroundColor Yellow
               cmake -G "${VS}" -A ${VSARC} -T host=x64 `
                     -D BUILD_SHARED_LIBS:BOOL=OFF `
                     -D CMAKE_SYSTEM_NAME=WindowsStore `
                     -D CMAKE_SYSTEM_VERSION="10.0" `
                     -D CMAKE_BUILD_TYPE:STRING=${buildConfig} `
                     -D CMAKE_INSTALL_PREFIX:PATH="${installDir}" `
                     -D CMAKE_LIBRARY_PATH:PATH="${installDir}" `
                     -D CMAKE_INCLUDE_PATH:PATH="${installDir}/include" `
                     -D BUILD_THIRDPARTY:BOOL=${BUILD_THIRDPARTY} `
                     "${openjpegDir}"
               Write-Host "   cmake --build . --config ${buildConfig}" -ForegroundColor Yellow
               cmake --build . --config ${buildConfig}
               Write-Host "   cmake --install . --config ${buildConfig}" -ForegroundColor Yellow
               cmake --install . --config ${buildConfig}
            }
            else
            {
               $VS = $this._Config.GetVisualStudio()
               $VSARC = $this._Config.GetVisualStudioArchitecture()
               Write-Host "   cmake -G `"${VS}`" -A ${VSARC} -T host=x64 `
         -D BUILD_SHARED_LIBS:BOOL=OFF `
         -D CMAKE_BUILD_TYPE:STRING=${buildConfig} `
         -D CMAKE_INSTALL_PREFIX:PATH=`"${installDir}`" `
         -D CMAKE_LIBRARY_PATH:PATH=`"${installDir}`" `
         -D CMAKE_INCLUDE_PATH:PATH=`"${installDir}/include`" `
         -D BUILD_THIRDPARTY:BOOL=${BUILD_THIRDPARTY} `
         `"$openjpegDir`"" -ForegroundColor Yellow
               cmake -G "${VS}" -A ${VSARC} -T host=x64 `
                     -D BUILD_SHARED_LIBS:BOOL=OFF `
                     -D CMAKE_BUILD_TYPE:STRING=${buildConfig} `
                     -D CMAKE_INSTALL_PREFIX:PATH="${installDir}" `
                     -D CMAKE_LIBRARY_PATH:PATH="${installDir}" `
                     -D CMAKE_INCLUDE_PATH:PATH="${installDir}/include" `
                     -D BUILD_THIRDPARTY:BOOL=${BUILD_THIRDPARTY} `
                     "${openjpegDir}"
               Write-Host "   cmake --build . --config ${buildConfig}" -ForegroundColor Yellow
               cmake --build . --config ${buildConfig}
               Write-Host "   cmake --install . --config ${buildConfig}" -ForegroundColor Yellow
               cmake --install . --config ${buildConfig}
            }
         }
         else
         {
            Write-Host "   cmake -D CMAKE_BUILD_TYPE=${buildConfig} `
            -D BUILD_SHARED_LIBS:BOOL=OFF `
            -D CMAKE_BUILD_TYPE:STRING=${buildConfig} `
            -D CMAKE_INSTALL_PREFIX:PATH=`"${installDir}`" `
            -D CMAKE_LIBRARY_PATH:PATH=`"${installDir}`" `
            -D CMAKE_INCLUDE_PATH:PATH=`"${installDir}/include`" `
            -D CMAKE_POSITION_INDEPENDENT_CODE:BOOL=ON `
            -D BUILD_THIRDPARTY:BOOL=${BUILD_THIRDPARTY} `
            `"$openjpegDir`"" -ForegroundColor Yellow
               cmake -D CMAKE_BUILD_TYPE=${buildConfig} `
                     -D BUILD_SHARED_LIBS:BOOL=OFF `
                     -D CMAKE_BUILD_TYPE:STRING=${buildConfig} `
                     -D CMAKE_INSTALL_PREFIX:PATH="${installDir}" `
                     -D CMAKE_LIBRARY_PATH:PATH="${installDir}" `
                     -D CMAKE_INCLUDE_PATH:PATH="${installDir}/include" `
                     -D CMAKE_POSITION_INDEPENDENT_CODE:BOOL=ON `
                     -D BUILD_THIRDPARTY:BOOL=${BUILD_THIRDPARTY} `
                     "${openjpegDir}"
               Write-Host "   cmake --build . --config ${buildConfig}" -ForegroundColor Yellow
               cmake --build . --config ${buildConfig}
               Write-Host "   cmake --install . --config ${buildConfig}" -ForegroundColor Yellow
               cmake --install . --config ${buildConfig}
         }
      }
      finally
      {
         Set-Location $current
         Write-Host "End Build OpenJpeg" -ForegroundColor Green
      }

      return $ret
   }
}

function ConfigCPU([Config]$Config)
{
   if ($IsWindows)
   {
      CallVisualStudioDeveloperConsole($Config)
   }

   $Builder = [ThirdPartyBuilder]::new($Config)
      
   # Build opnejpeg
   $installOpenJpegDir = $Builder.BuildOpenJpeg()

   if ($IsWindows)
   {
      $VS = $Config.GetVisualStudio()
      $VSARC = $Config.GetVisualStudioArchitecture()

      $env:OpenJPEG_DIR = $installOpenJpegDir
      Write-Host "   cmake -G `"${VS}`" -A ${VSARC} -T host=x64 `
         -D OpenJPEG_DIR=`"${installOpenJpegDir}`" `
         .." -ForegroundColor Yellow
      cmake -G "${VS}" -A ${VSARC} -T host=x64 `
            -D OpenJPEG_DIR="${installOpenJpegDir}" `
            ..
   }
   else
   {
      $arch_type = $Config.GetArchitecture()

      $env:OpenJPEG_DIR = $installOpenJpegDir
      Write-Host "   cmake -D ARCH_TYPE=`"${arch_type}`" `
         -D OpenJPEG_DIR=`"${installOpenJpegDir}`" `
         .." -ForegroundColor Yellow
      cmake -D ARCH_TYPE="$arch_type" `
            -D OpenJPEG_DIR="${installOpenJpegDir}" `
            ..
   }
}

function ConfigARM([Config]$Config)
{
   if ($Config.GetArchitecture() -eq 32)
   {
      cmake -D DLIB_USE_CUDA=OFF `
            -D ENABLE_NEON=ON `
            -D DLIB_USE_BLAS=ON `
            -D DLIB_USE_LAPACK=OFF `
            -D CMAKE_C_COMPILER="/usr/bin/arm-linux-gnueabihf-gcc" `
            -D CMAKE_CXX_COMPILER="/usr/bin/arm-linux-gnueabihf-g++" `
            -D LIBPNG_IS_GOOD=OFF `
            -D PNG_FOUND=OFF `
            -D PNG_LIBRARY_RELEASE="" `
            -D PNG_LIBRARY_DEBUG="" `
            -D PNG_PNG_INCLUDE_DIR="" `
            ..
   }
   else
   {
      cmake -D DLIB_USE_CUDA=OFF `
            -D ENABLE_NEON=ON `
            -D DLIB_USE_BLAS=ON `
            -D DLIB_USE_LAPACK=OFF `
            -D CMAKE_C_COMPILER="/usr/bin/aarch64-linux-gnu-gcc" `
            -D CMAKE_CXX_COMPILER="/usr/bin/aarch64-linux-gnu-g++" `
            -D LIBPNG_IS_GOOD=OFF `
            -D PNG_FOUND=OFF `
            -D PNG_LIBRARY_RELEASE="" `
            -D PNG_LIBRARY_DEBUG="" `
            -D PNG_PNG_INCLUDE_DIR="" `
            ..
   }
}

function ConfigUWP([Config]$Config)
{
   if ($IsWindows)
   {
      CallVisualStudioDeveloperConsole($Config)
   }

   $Builder = [ThirdPartyBuilder]::new($Config)
      
   # Build opnejpeg
   $installOpenJpegDir = $Builder.BuildOpenJpeg()
   
   if ($IsWindows)
   {
      $VS = $Config.GetVisualStudio()
      $VSARC = $Config.GetVisualStudioArchitecture()

      $env:OpenJPEG_DIR = $installOpenJpegDir
      Write-Host "   cmake -G `"${VS}`" -A ${VSARC} -T host=x64 `
         -D CMAKE_SYSTEM_NAME=WindowsStore `
         -D CMAKE_SYSTEM_VERSION=10.0 `
         -D WINAPI_FAMILY=WINAPI_FAMILY_APP `
         -D _WINDLL=ON `
         -D _WIN32_UNIVERSAL_APP=ON `
         -D OpenJPEG_DIR=`"${installOpenJpegDir}`" `
         .." -ForegroundColor Yellow
      cmake -G "${VS}" -A ${VSARC} -T host=x64 `
            -D CMAKE_SYSTEM_NAME=WindowsStore `
            -D CMAKE_SYSTEM_VERSION=10.0 `
            -D WINAPI_FAMILY=WINAPI_FAMILY_APP `
            -D _WINDLL=ON `
            -D _WIN32_UNIVERSAL_APP=ON `
            -D OpenJPEG_DIR="${installOpenJpegDir}" `
            ..
   }
}

function ConfigANDROID([Config]$Config)
{
   if ($IsLinux)
   {
      if (!${env:ANDROID_NDK_HOME})
      {
         Write-Host "Error: Specify ANDROID_NDK_HOME environmental value" -ForegroundColor Red
         exit -1
      }

      if ((Test-Path "${env:ANDROID_NDK_HOME}/build/cmake/android.toolchain.cmake") -eq $False)
      {
         Write-Host "Error: Specified Android NDK toolchain '${env:ANDROID_NDK_HOME}/build/cmake/android.toolchain.cmake' does not found" -ForegroundColor Red
         exit -1
      }

      $level = $Config.GetAndroidNativeAPILevel()
      $abi = $Config.GetAndroidABI()

      cmake -G Ninja `
            -D CMAKE_TOOLCHAIN_FILE=${env:ANDROID_NDK_HOME}/build/cmake/android.toolchain.cmake `
            -D ANDROID_NDK=${env:ANDROID_NDK_HOME} `
            -D CMAKE_MAKE_PROGRAM=ninja `
            -D ANDROID_NATIVE_API_LEVEL=${level} `
            -D ANDROID_ABI=${abi} `
            -D ANDROID_TOOLCHAIN=clang `
            -D DLIB_USE_CUDA=OFF `
            -D DLIB_USE_BLAS=OFF `
            -D DLIB_USE_LAPACK=OFF `
            -D mkl_include_dir="" `
            -D mkl_intel="" `
            -D mkl_rt="" `
            -D mkl_thread="" `
            -D mkl_pthread="" `
            -D LIBPNG_IS_GOOD=OFF `
            -D PNG_FOUND=OFF `
            -D PNG_LIBRARY_RELEASE="" `
            -D PNG_LIBRARY_DEBUG="" `
            -D PNG_PNG_INCLUDE_DIR="" `
            -D DLIB_NO_GUI_SUPPORT=ON `
            ..
   }
   else
   {      
      Write-Host "Error: This platform can not build android binary" -ForegroundColor Red
      exit -1
   }
}

function ConfigIOS([Config]$Config)
{
   if ($IsMacOS)
   {
      cmake -G Xcode `
            -D CMAKE_TOOLCHAIN_FILE=../../ios-cmake/ios.toolchain.cmake `
            -D PLATFORM=OS64COMBINED `
            -D DLIB_USE_CUDA=OFF `
            -D DLIB_USE_BLAS=OFF `
            -D DLIB_USE_LAPACK=OFF `
            -D mkl_include_dir="" `
            -D mkl_intel="" `
            -D mkl_rt="" `
            -D mkl_thread="" `
            -D mkl_pthread="" `
            -D LIBPNG_IS_GOOD=OFF `
            -D PNG_FOUND=OFF `
            -D PNG_LIBRARY_RELEASE="" `
            -D PNG_LIBRARY_DEBUG="" `
            -D PNG_PNG_INCLUDE_DIR="" `
            -D DLIB_NO_GUI_SUPPORT=ON `
            ..
   }
   else
   {      
      Write-Host "Error: This platform can not build iOS binary" -ForegroundColor Red
      exit -1
   }
}

function Reset-OpenJpeg-Modification([Config]$Config, [string]$currentDir)
{
   $openjpegDir = $Config.GetOpenJpegRootDir()
   Set-Location -Path $openjpegDir
   Write-Host "Reset modification of ${openjpegDir}" -ForegroundColor Yellow
   git checkout .
   Set-Location -Path $currentDir
}

function Build([Config]$Config)
{
   $Current = Get-Location

   $Output = $Config.GetBuildDirectoryName("")
   if ((Test-Path $Output) -eq $False)
   {
      New-Item $Output -ItemType Directory
   }

   Set-Location -Path $Output

   $Target = $Config.GetTarget()
   $Platform = $Config.GetPlatform()

   # revert openjpeg
   Reset-OpenJpeg-Modification $Config (Join-Path $Current $Output)

   switch ($Platform)
   {
      "desktop"
      {
         switch ($Target)
         {
            "cpu"
            {
               ConfigCPU $Config
            }
            "arm"
            {
               ConfigARM $Config
            }
         }
      }
      "android"
      {
         ConfigANDROID $Config
      }
      "ios"
      {
         ConfigIOS $Config
      }
      "uwp"
      {
         ConfigUWP $Config
      }
   }

   cmake --build . --config $Config.GetConfigurationName()

   # Move to Root directory
   Set-Location -Path $Current
}

function CopyToArtifact()
{
   Param([string]$srcDir, [string]$build, [string]$libraryName, [string]$dstDir, [string]$rid, [string]$configuration="")

   if ($configuration)
   {
      $binary = Join-Path ${srcDir} ${build}  | `
               Join-Path -ChildPath ${configuration} | `
               Join-Path -ChildPath ${libraryName}
   }
   else
   {
      $binary = Join-Path ${srcDir} ${build}  | `
               Join-Path -ChildPath ${libraryName}
   }

   $output = Join-Path $dstDir runtimes | `
            Join-Path -ChildPath ${rid} | `
            Join-Path -ChildPath native | `
            Join-Path -ChildPath $libraryName

   Write-Host "Copy ${libraryName} to ${output}" -ForegroundColor Green
   Copy-Item ${binary} ${output}
}