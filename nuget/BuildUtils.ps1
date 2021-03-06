class BuildTarget
{
   [string] $Platform
   [string] $Target
   [int]    $Architecture
   [string] $Postfix
   [string] $RID

   BuildTarget( [string]$Platform,
                [string]$Target,
                [int]   $Architecture,
                [string]$RID,
                [string]$Postfix = ""
              )
   {
      $this.Platform = $Platform
      $this.Target = $Target
      $this.Architecture = $Architecture
      $this.Postfix = $Postfix
      $this.RID = $RID
   }

   [string] $OperatingSystem
   [string] $Distribution
   [string] $DistributionVersion

   [string] $CudaVersion

   [string] $AndroidVersion
   [string] $AndroidNativeApiLevel
}

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

   $VisualStudio = "Visual Studio 15 2017"

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
      "OpenJpegDotNet.Native"     = "libOpenJpegDotNetNative_merged.a";
   }

   [string]   $_Root
   [string]   $_Configuration
   [int]      $_Architecture
   [string]   $_Target
   [string]   $_Platform
   [string]   $_AndroidABI
   [string]   $_AndroidNativeAPILevel
   [string]   $_OSXArchitectures

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
         "ios"
         {
            $this._OSXArchitectures = $Option
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

   [string] GetToolchainDir()
   {
      return   Join-Path $this.GetRootDir() src |
               Join-Path -ChildPath toolchains
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
         if (![string]::IsNullOrEmpty($this._OSXArchitectures))
         {
            $os = "ios"
         }
         else
         {
            $os = "osx"
         }
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

      switch ($platform)
      {
         "android"
         {
            $architecture = $this._AndroidABI
         }
         "ios"
         {
            $architecture = $this._OSXArchitectures
         }
      }

      if ($this._Configuration -eq "Debug")
      {
         return "build_${osname}_${platform}_${target}_${architecture}_d"
      }
      else
      {
         return "build_${osname}_${platform}_${target}_${architecture}"
      }
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

   [string] GetToolchainFile()
   {
      $architecture = $this._Architecture
      $target = $this._Target
      $toolchainDir = $this.GetToolchainDir()
      $toolchain = Join-Path $toolchainDir "empty.cmake"

      if ($global:IsLinux)
      {
         if ($target -eq "arm")
         {
            if ($architecture -eq 64)
            {
               $toolchain = Join-Path $toolchainDir "aarch64-linux-gnu.toolchain.cmake"
            }
         }
      }
      else
      {
         $Platform = $this._Platform
         switch ($Platform)
         {
            "ios"
            {
               $osxArchitectures = $this.GetOSXArchitectures()
               $toolchain = Join-Path $toolchainDir "${osxArchitectures}-ios.cmake"
            }
         }
      }

      return $toolchain
   }

   [string] GetDeveloperDir()
   {
      return $env:DEVELOPER_DIR
   }

   [string] GetOSXArchitectures()
   {
      return $this._OSXArchitectures
   }

   [string] GetIOSSDK([string]$osxArchitectures, [string]$developerDir)
   {
      switch ($osxArchitectures)
      {
         "arm64e"
         {
            return "${developerDir}/Platforms/iPhoneOS.platform/Developer/SDKs/iPhoneOS.sdk"
         }
         "arm64"
         {
            return "${developerDir}/Platforms/iPhoneOS.platform/Developer/SDKs/iPhoneOS.sdk"
         }
         "arm"
         {
            return "${developerDir}/Platforms/iPhoneOS.platform/Developer/SDKs/iPhoneOS.sdk"
         }
         "armv7"
         {
            return "${developerDir}/Platforms/iPhoneOS.platform/Developer/SDKs/iPhoneOS.sdk"
         }
         "armv7s"
         {
            return "${developerDir}/Platforms/iPhoneOS.platform/Developer/SDKs/iPhoneOS.sdk"
         }
         "i386"
         {
            return "${developerDir}/Platforms/iPhoneSimulator.platform/Developer/SDKs/iPhoneSimulator.sdk"
         }
         "x86_64"
         {
            return "${developerDir}/Platforms/iPhoneSimulator.platform/Developer/SDKs/iPhoneSimulator.sdk"
         }
      }
      return $this._OSXArchitectures
   }

   static [bool] Build([string]$root, [bool]$docker, [hashtable]$buildHashTable, [BuildTarget]$buildTarget)
   {
      $current = $PSScriptRoot

      $platform              = $buildTarget.Platform
      $target                = $buildTarget.Target
      $architecture          = $buildTarget.Architecture
      $postfix               = $buildTarget.Postfix
      $rid                   = $buildTarget.RID
      $operatingSystem       = $buildTarget.OperatingSystem
      $distribution          = $buildTarget.Distribution
      $distributionVersion   = $buildTarget.DistributionVersion
      $cudaVersion           = $buildTarget.CudaVersion
      $androidVersion        = $buildTarget.AndroidVersion
      $androidNativeApiLevel = $buildTarget.AndroidNativeApiLevel
      $configuration         = "Release"

      $option = ""

      $sourceRoot = Join-Path $root src

      if ($docker -eq $True)
      {
         $dockerDir = Join-Path $root docker

         Set-Location -Path $dockerDir

         $dockerFileDir = Join-Path $dockerDir build  | `
                          Join-Path -ChildPath $distribution | `
                          Join-Path -ChildPath $distributionVersion

         if ($platform -eq "android")
         {
            $setting =
            @{
               'ANDROID_ABI' = $rid;
               'ANDROID_NATIVE_API_LEVEL' = $androidNativeApiLevel
            }
            $option = [Config]::Base64Encode((ConvertTo-Json -Compress $setting))

            $dockername = "openjpegdotnet/build/$distribution/$distributionVersion/android/$androidVersion"
            $imagename  = "openjpegdotnet/devel/$distribution/$distributionVersion/android/$androidVersion"
         }
         else
         {
            if ($target -ne "cuda")
            {
               $option = ""

               $dockername = "openjpegdotnet/build/$distribution/$distributionVersion/$Target" + $postfix
               $imagename  = "openjpegdotnet/devel/$distribution/$distributionVersion/$Target" + $postfix
            }
            else
            {
               $option = $cudaVersion

               $cudaVersion = ($cudaVersion / 10).ToString("0.0")
               $dockername = "openjpegdotnet/build/$distribution/$distributionVersion/$Target/$cudaVersion"
               $imagename  = "openjpegdotnet/devel/$distribution/$distributionVersion/$Target/$cudaVersion"
            }
         }

         $config = [Config]::new($root, $configuration, $target, $architecture, $platform, $option)
         $libraryDir = Join-Path "artifacts" $config.GetArtifactDirectoryName()
         $build = $config.GetBuildDirectoryName($operatingSystem)

         Write-Host "Start 'docker build -t $dockername $dockerFileDir --build-arg IMAGE_NAME=""$imagename""'" -ForegroundColor Green
         docker build --network host --force-rm=true -t $dockername $dockerFileDir --build-arg IMAGE_NAME="$imagename" | Write-Host

         if ($lastexitcode -ne 0)
         {
            Write-Host "Failed to docker build: $lastexitcode" -ForegroundColor Red
            return $False
         }

         if ($platform -eq "desktop")
         {
            if ($target -eq "arm")
            {
               Write-Host "Start 'docker run --rm --privileged multiarch/qemu-user-static --reset -p yes'" -ForegroundColor Green
               docker run --rm --privileged multiarch/qemu-user-static --reset -p yes
            }
         }

         # Build binary
         foreach ($key in $buildHashTable.keys)
         {
            Write-Host "Start 'docker run --rm -v ""$($root):/opt/data/OpenJpegDotNet"" -e LOCAL_UID=$(id -u $env:USER) -e LOCAL_GID=$(id -g $env:USER) -t $dockername $key $target $architecture $platform $option'" -ForegroundColor Green
            docker run --rm --network host `
                        -v "$($root):/opt/data/OpenJpegDotNet" `
                        -e "LOCAL_UID=$(id -u $env:USER)" `
                        -e "LOCAL_GID=$(id -g $env:USER)" `
                        -t "$dockername" $key $target $architecture $platform $option | Write-Host

            if ($lastexitcode -ne 0)
            {
               Write-Host "Failed to docker run: $lastexitcode" -ForegroundColor Red
               return $False
            }
         }

         # Copy output binary
         foreach ($key in $buildHashTable.keys)
         {
            $srcDir = Join-Path $sourceRoot $key
            $dll = $buildHashTable[$key]
            $dstDir = Join-Path $current $libraryDir

            CopyToArtifact -srcDir $srcDir -build $build -libraryName $dll -dstDir $dstDir -rid $rid
         }
      }
      else
      {
         if ($platform -eq "ios")
         {
            $option = $rid
         }

         $config = [Config]::new($root, $configuration, $target, $architecture, $platform, $option)
         $libraryDir = Join-Path "artifacts" $config.GetArtifactDirectoryName()
         $build = $config.GetBuildDirectoryName($operatingSystem)

         foreach ($key in $buildHashTable.keys)
         {
            $srcDir = Join-Path $sourceRoot $key

            # Move to build target directory
            Set-Location -Path $srcDir

            $arc = $config.GetArchitectureName()
            Write-Host "Build $key [$arc] for $target" -ForegroundColor Green
            Build -Config $config

            if ($lastexitcode -ne 0)
            {
               return $False
            }
         }

         # Copy output binary
         foreach ($key in $buildHashTable.keys)
         {
            $srcDir = Join-Path $sourceRoot $key
            $dll = $buildHashTable[$key]
            $dstDir = Join-Path $current $libraryDir

            if ($global:IsWindows)
            {
               CopyToArtifact -configuration "Release" -srcDir $srcDir -build $build -libraryName $dll -dstDir $dstDir -rid $rid
            }
            else
            {
               CopyToArtifact -srcDir $srcDir -build $build -libraryName $dll -dstDir $dstDir -rid $rid
            }
         }
      }

      return $True
   }

}

function CallVisualStudioDeveloperConsole([Config]$Config)
{
   # $console = $Config.GetVisualStudioConsole()
   # cmd.exe /c "call `"${console}`" && set > %temp%\vcvars.txt"

   # Get-Content "${env:temp}\vcvars.txt" | Foreach-Object {
   #    if ($_ -match "^(.*?)=(.*)$") {
   #      Set-Content "env:\$($matches[1])" $matches[2]
   #    }
   #  }
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
         
         $Platform = $this._Config.GetPlatform()
         $Configuration = $this._Config.GetConfigurationName()

         switch ($Platform)
         {
            "desktop"
            {
               if ($global:IsWindows)
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

                  Write-Host "   cmake --build . --config ${Configuration} --target install" -ForegroundColor Yellow
                  cmake --build . --config $Configuration --target install
               }
               else
               {
                  switch ($this._Config.GetTarget())
                  {
                     "cpu"
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

                           Write-Host "   cmake --build . --config ${Configuration} --target install" -ForegroundColor Yellow
                           cmake --build . --config $Configuration --target install
                     }
                     "arm"
                     {
                        if ($this._Config.GetArchitecture() -eq 32)
                        {
                           $CMAKE_C_COMPILER = "/usr/bin/arm-linux-gnueabihf-gcc"
                           $CMAKE_CXX_COMPILER = "/usr/bin/arm-linux-gnueabihf-g++"
                        }
                        else
                        {
                           $CMAKE_C_COMPILER = "/usr/bin/aarch64-linux-gnu-gcc"
                           $CMAKE_CXX_COMPILER = "/usr/bin/aarch64-linux-gnu-g++"
                        }
   
                        Write-Host "   cmake -D CMAKE_BUILD_TYPE=${buildConfig} `
            -D BUILD_SHARED_LIBS:BOOL=OFF `
            -D CMAKE_C_COMPILER=`"$CMAKE_C_COMPILER`" `
            -D CMAKE_CXX_COMPILER=`"$CMAKE_CXX_COMPILER`" `
            -D CMAKE_INSTALL_PREFIX:PATH=`"${installDir}`" `
            -D CMAKE_LIBRARY_PATH:PATH=`"${installDir}`" `
            -D CMAKE_INCLUDE_PATH:PATH=`"${installDir}/include`" `
            -D CMAKE_POSITION_INDEPENDENT_CODE:BOOL=ON `
            -D BUILD_THIRDPARTY:BOOL=${BUILD_THIRDPARTY} `
            `"$openjpegDir`"" -ForegroundColor Yellow
                           cmake -D CMAKE_BUILD_TYPE=${buildConfig} `
                                 -D BUILD_SHARED_LIBS:BOOL=OFF `
                                 -D CMAKE_C_COMPILER="$CMAKE_C_COMPILER" `
                                 -D CMAKE_CXX_COMPILER="$CMAKE_CXX_COMPILER" `
                                 -D CMAKE_INSTALL_PREFIX:PATH="${installDir}" `
                                 -D CMAKE_LIBRARY_PATH:PATH="${installDir}" `
                                 -D CMAKE_INCLUDE_PATH:PATH="${installDir}/include" `
                                 -D CMAKE_POSITION_INDEPENDENT_CODE:BOOL=ON `
                                 -D BUILD_THIRDPARTY:BOOL=${BUILD_THIRDPARTY} `
                                 "${openjpegDir}"

                           Write-Host "   cmake --build . --config ${Configuration} --target install" -ForegroundColor Yellow
                           cmake --build . --config $Configuration --target install
                     }
                  }
               }
            }
            "uwp"
            {
               $VS = $this._Config.GetVisualStudio()
               $VSARC = $this._Config.GetVisualStudioArchitecture()

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

               Write-Host "   cmake --build . --config ${Configuration} --target install" -ForegroundColor Yellow
               cmake --build . --config $Configuration --target install
            }
            "android"
            {
               $level = $this._Config.GetAndroidNativeAPILevel()
               $abi = $this._Config.GetAndroidABI()
               
               Write-Host "   cmake -D CMAKE_TOOLCHAIN_FILE=${env:ANDROID_NDK}/build/cmake/android.toolchain.cmake `
         -D CMAKE_BUILD_TYPE=$Configuration `
         -D BUILD_SHARED_LIBS:BOOL=OFF `
         -D CMAKE_BUILD_TYPE:STRING=${buildConfig} `
         -D CMAKE_INSTALL_PREFIX:PATH=`"${installDir}`" `
         -D CMAKE_LIBRARY_PATH:PATH=`"${installDir}`" `
         -D CMAKE_INCLUDE_PATH:PATH=`"${installDir}/include`" `
         -D CMAKE_POSITION_INDEPENDENT_CODE:BOOL=ON `
         -D ANDROID_ABI=$abi `
         -D ANDROID_PLATFORM=android-$level `
         -D BUILD_THIRDPARTY:BOOL=${BUILD_THIRDPARTY} `
         `"$openjpegDir`"" -ForegroundColor Yellow
               cmake -D CMAKE_TOOLCHAIN_FILE=${env:ANDROID_NDK}/build/cmake/android.toolchain.cmake `
                     -D CMAKE_BUILD_TYPE=$Configuration `
                     -D BUILD_SHARED_LIBS:BOOL=OFF `
                     -D CMAKE_BUILD_TYPE:STRING=${buildConfig} `
                     -D CMAKE_INSTALL_PREFIX:PATH="${installDir}" `
                     -D CMAKE_LIBRARY_PATH:PATH="${installDir}" `
                     -D CMAKE_INCLUDE_PATH:PATH="${installDir}/include" `
                     -D CMAKE_POSITION_INDEPENDENT_CODE:BOOL=ON `
                     -D ANDROID_ABI=$abi `
                     -D ANDROID_PLATFORM=android-$level `
                     -D BUILD_THIRDPARTY:BOOL=${BUILD_THIRDPARTY} `
                     "${openjpegDir}"

               Write-Host "   make" -ForegroundColor Yellow
               make -j4
               Write-Host "   make install" -ForegroundColor Yellow
               make install
            }
            "ios"
            {
               $developerDir = $this._Config.GetDeveloperDir()
               $osxArchitectures = $this._Config.GetOSXArchitectures()
               $toolchain = $this._Config.GetToolchainFile()

               $OSX_SYSROOT = $this._Config.GetIOSSDK($osxArchitectures, $developerDir)

               $CMAKE_IOS_INSTALL_COMBINED="NO"
               $CMAKE_XCODE_ATTRIBUTE_ONLY_ACTIVE_ARCH="NO"

               # use libc++ rather than libstdc++
               Write-Host "   cmake -D CMAKE_BUILD_TYPE=$Configuration `
         -D CMAKE_INSTALL_PREFIX:PATH=`"${installDir}`" `
         -D CMAKE_CXX_FLAGS=`"-std=c++11`" `
         -D CMAKE_EXE_LINKER_FLAGS=`"-stdlib=libc++ -lc++abi`" `
         -D CMAKE_SYSTEM_NAME=iOS `
         -D BUILD_SHARED_LIBS=OFF `
         -D BUILD_THIRDPARTY:BOOL=${BUILD_THIRDPARTY} `
         -D CMAKE_XCODE_ATTRIBUTE_ONLY_ACTIVE_ARCH=$CMAKE_XCODE_ATTRIBUTE_ONLY_ACTIVE_ARCH `
         -D CMAKE_IOS_INSTALL_COMBINED=$CMAKE_IOS_INSTALL_COMBINED `
         -D CMAKE_OSX_ARCHITECTURES=${osxArchitectures} `
         -D CMAKE_OSX_SYSROOT=${OSX_SYSROOT} `
         -D CMAKE_TOOLCHAIN_FILE=`"${toolchain}`" `
         -D CMAKE_INSTALL_PREFIX=`"${installDir}`" `
         ${openjpegDir}" -ForegroundColor Yellow
               cmake -D CMAKE_BUILD_TYPE=$Configuration `
                     -D CMAKE_INSTALL_PREFIX:PATH="${installDir}" `
                     -D CMAKE_CXX_FLAGS="-std=c++11" `
                     -D CMAKE_EXE_LINKER_FLAGS="-stdlib=libc++ -lc++abi" `
                     -D CMAKE_SYSTEM_NAME=iOS `
                     -D BUILD_SHARED_LIBS=OFF `
                     -D BUILD_THIRDPARTY:BOOL=${BUILD_THIRDPARTY} `
                     -D CMAKE_XCODE_ATTRIBUTE_ONLY_ACTIVE_ARCH=$CMAKE_XCODE_ATTRIBUTE_ONLY_ACTIVE_ARCH `
                     -D CMAKE_IOS_INSTALL_COMBINED=$CMAKE_IOS_INSTALL_COMBINED `
                     -D CMAKE_OSX_ARCHITECTURES=${osxArchitectures} `
                     -D CMAKE_OSX_SYSROOT=${OSX_SYSROOT} `
                     -D CMAKE_TOOLCHAIN_FILE="${toolchain}" `
                     -D CMAKE_INSTALL_PREFIX="${installDir}" `
                     "${openjpegDir}"

               Write-Host "   cmake --build . --config ${Configuration} --target install" -ForegroundColor Yellow
               cmake --build . --config $Configuration --target install

               # https://gitlab.kitware.com/cmake/cmake/-/issues/20956
               # CMake does not generate these files and it will occur failing find_package
               # so generates these manually
               # openjpeg/install/bin/opj_compress.app/Contents/MacOS/opj_compress
               # openjpeg/install/bin/opj_decompress.app/Contents/MacOS/opj_decompress
               # openjpeg/install/bin/opj_dump.app/Contents/MacOS/opj_dump
               $files = @("opj_compress", "opj_decompress", "opj_dump")
               foreach ($file in $files)
               {
                  $osx = Join-Path ${installDir} bin | `
                         Join-Path -ChildPath "${file}.app" | `
                         Join-Path -ChildPath Contents | `
                         Join-Path -ChildPath MacOS
                  if (!(Test-Path $osx))
                  {
                     New-Item $osx -Force -ItemType Directory
                  }

                  $openjpeg = Split-Path ${installDir} -Parent
                  $src = Join-Path ${openjpeg} bin | `
                         Join-Path -ChildPath "${file}.app" | `
                         Join-Path -ChildPath ${file}
                  Copy-Item $src $osx -Force
               }
            }
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

   if ($global:IsWindows)
   {
      $VS = $Config.GetVisualStudio()
      $VSARC = $Config.GetVisualStudioArchitecture()
      $target_arch = $Config.GetArchitectureName()

      $env:OpenJPEG_DIR = $installOpenJpegDir
      Write-Host "   cmake -G `"${VS}`" -A ${VSARC} -T host=x64 `
         -D OpenJPEG_DIR=`"${installOpenJpegDir}`" `
         -D TARGET_ARCH=`"${target_arch}`" `
         .." -ForegroundColor Yellow
      cmake -G "${VS}" -A ${VSARC} -T host=x64 `
            -D OpenJPEG_DIR="${installOpenJpegDir}" `
            -D TARGET_ARCH="${target_arch}" `
            ..
   }
   else
   {
      $arch_type = $Config.GetArchitecture()
      $target_arch = $Config.GetArchitectureName()

      $env:OpenJPEG_DIR = $installOpenJpegDir
      Write-Host "   cmake -D ARCH_TYPE=`"${arch_type}`" `
         -D OpenJPEG_DIR=`"${installOpenJpegDir}`" `
         -D TARGET_ARCH=`"${target_arch}`" `
         .." -ForegroundColor Yellow
      cmake -D ARCH_TYPE="$arch_type" `
            -D OpenJPEG_DIR="${installOpenJpegDir}" `
            -D TARGET_ARCH="${target_arch}" `
            ..
   }
}

function ConfigARM([Config]$Config)
{
   $Builder = [ThirdPartyBuilder]::new($Config)

   # Build opnejpeg
   $installOpenJpegDir = $Builder.BuildOpenJpeg()

   $arch_type = $Config.GetArchitecture()
   $target_arch = $Config.GetArchitectureName()
   $env:OpenJPEG_DIR = $installOpenJpegDir

   if ($Config.GetArchitecture() -eq 32)
   {
      Write-Host "   cmake -D ARCH_TYPE=`"${arch_type}`" `
         -D OpenJPEG_DIR=`"${installOpenJpegDir}`" `
         -D CMAKE_C_COMPILER=`"/usr/bin/arm-linux-gnueabihf-gcc`" `
         -D CMAKE_CXX_COMPILER=`"/usr/bin/arm-linux-gnueabihf-g++`" `
         -D TARGET_ARCH=`"${target_arch}`" `
         .." -ForegroundColor Yellow
      cmake -D ARCH_TYPE="$arch_type" `
            -D OpenJPEG_DIR="${installOpenJpegDir}" `
            -D CMAKE_C_COMPILER="/usr/bin/arm-linux-gnueabihf-gcc" `
            -D CMAKE_CXX_COMPILER="/usr/bin/arm-linux-gnueabihf-g++" `
            -D TARGET_ARCH="${target_arch}" `
            ..
   }
   else
   {
      Write-Host "   cmake -D ARCH_TYPE=`"${arch_type}`" `
         -D OpenJPEG_DIR=`"${installOpenJpegDir}`" `
         -D CMAKE_C_COMPILER=`"/usr/bin/aarch64-linux-gnu-gcc`" `
         -D CMAKE_CXX_COMPILER=`"/usr/bin/aarch64-linux-gnu-g++`" `
         -D TARGET_ARCH=`"${target_arch}`" `
         .." -ForegroundColor Yellow
      cmake -D ARCH_TYPE="$arch_type" `
            -D OpenJPEG_DIR="${installOpenJpegDir}" `
            -D CMAKE_C_COMPILER="/usr/bin/aarch64-linux-gnu-gcc" `
            -D CMAKE_CXX_COMPILER="/usr/bin/aarch64-linux-gnu-g++" `
            -D TARGET_ARCH="${target_arch}" `
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
      $target_arch = $Config.GetArchitectureName()

      $env:OpenJPEG_DIR = $installOpenJpegDir
      Write-Host "   cmake -G `"${VS}`" -A ${VSARC} -T host=x64 `
         -D CMAKE_SYSTEM_NAME=WindowsStore `
         -D CMAKE_SYSTEM_VERSION=10.0 `
         -D OpenJPEG_DIR=`"${installOpenJpegDir}`" `
         -D TARGET_ARCH=`"${target_arch}`" `
         .." -ForegroundColor Yellow
      cmake -G "${VS}" -A ${VSARC} -T host=x64 `
            -D CMAKE_SYSTEM_NAME=WindowsStore `
            -D CMAKE_SYSTEM_VERSION=10.0 `
            -D OpenJPEG_DIR="${installOpenJpegDir}" `
            -D TARGET_ARCH="${target_arch}" `
            ..
   }
}

function ConfigANDROID([Config]$Config)
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

   $Builder = [ThirdPartyBuilder]::new($Config)

   # Build opnejpeg
   $installOpenJpegDir = $Builder.BuildOpenJpeg()

   # # Build OpenJpegDotNet.Native
   Write-Host "Start Build OpenJpegDotNet.Native" -ForegroundColor Green

   $level = $Config.GetAndroidNativeAPILevel()
   $abi = $Config.GetAndroidABI()

   $arch_type = $Config.GetArchitecture()
   
   $env:OpenJPEG_DIR = "${installOpenJpegDir}/lib/openjpeg-2.4"
   Write-Host "   cmake -D CMAKE_TOOLCHAIN_FILE=${env:ANDROID_NDK}/build/cmake/android.toolchain.cmake `
      -D ANDROID_ABI=$abi `
      -D ANDROID_PLATFORM=android-$level `
      -D ANDROID_CPP_FEATURES:STRING=`"exceptions rtti`" `
      -D BUILD_SHARED_LIBS=ON `
      -D OpenJPEG_DIR=`"${env:OpenJPEG_DIR}`" `
      -D TARGET_ARCH=`"${target_arch}`" `
      .." -ForegroundColor Yellow
   cmake -D CMAKE_TOOLCHAIN_FILE=${env:ANDROID_NDK}/build/cmake/android.toolchain.cmake `
         -D ANDROID_ABI=$abi `
         -D ANDROID_PLATFORM=android-$level `
         -D ANDROID_CPP_FEATURES:STRING="exceptions rtti" `
         -D BUILD_SHARED_LIBS=ON `
         -D OpenJPEG_DIR="${env:OpenJPEG_DIR}" `
         -D TARGET_ARCH="${target_arch}" `
         ..
}

function ConfigIOS([Config]$Config)
{
   if ($IsMacOS)
   {
      $Builder = [ThirdPartyBuilder]::new($Config)

      # Build opnejpeg
      $installOpenJpegDir = $Builder.BuildOpenJpeg()

      # Build OpenJpegDotNet.Native
      Write-Host "Start Build OpenJpegDotNet.Native" -ForegroundColor Green

      $developerDir = $Config.GetDeveloperDir()
      $osxArchitectures = $Config.GetOSXArchitectures()
      $toolchain = $Config.GetToolchainFile()

      $OSX_SYSROOT = $Config.GetIOSSDK($osxArchitectures, $developerDir)

      $env:OpenJPEG_DIR = "${installOpenJpegDir}/lib/openjpeg-2.4"

      # use libc++ rather than libstdc++
      Write-Host "   cmake -D CMAKE_SYSTEM_NAME=iOS `
         -D CMAKE_OSX_ARCHITECTURES=${osxArchitectures} `
         -D CMAKE_OSX_SYSROOT=${OSX_SYSROOT} `
         -D CMAKE_TOOLCHAIN_FILE=`"${toolchain}`" `
         -D CMAKE_CXX_FLAGS=`"-std=c++11 -stdlib=libc++ -static`" `
         -D CMAKE_EXE_LINKER_FLAGS=`"-std=c++11 -stdlib=libc++ -static`" `
         -D BUILD_SHARED_LIBS=OFF `
         -D OpenJPEG_DIR=`"${env:OpenJPEG_DIR}`" `
         .." -ForegroundColor Yellow
      cmake -D CMAKE_SYSTEM_NAME=iOS `
            -D CMAKE_OSX_ARCHITECTURES=${osxArchitectures} `
            -D CMAKE_OSX_SYSROOT=${OSX_SYSROOT} `
            -D CMAKE_TOOLCHAIN_FILE="${toolchain}" `
            -D CMAKE_CXX_FLAGS="-std=c++11 -stdlib=libc++ -static" `
            -D CMAKE_EXE_LINKER_FLAGS="-std=c++11 -stdlib=libc++ -static" `
            -D BUILD_SHARED_LIBS=OFF `
            -D OpenJPEG_DIR="${env:OpenJPEG_DIR}" `
            ..
   }
   else
   {
      Write-Host "Error: This platform can not build iOS binary" -ForegroundColor Red
      exit -1
   }
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

   $Platform = $Config.GetPlatform()

   # Post build
   switch ($Platform)
   {
      "ios"
      {
         $BuildTargets = @()
         $BuildTargets += New-Object PSObject -Property @{ Platform = "arm64e"; }
         $BuildTargets += New-Object PSObject -Property @{ Platform = "arm64";  }
         $BuildTargets += New-Object PSObject -Property @{ Platform = "arm";    }
         $BuildTargets += New-Object PSObject -Property @{ Platform = "armv7";  }
         $BuildTargets += New-Object PSObject -Property @{ Platform = "armv7s"; }
         $BuildTargets += New-Object PSObject -Property @{ Platform = "i386";   }
         $BuildTargets += New-Object PSObject -Property @{ Platform = "x86_64"; }

         foreach($BuildTarget in $BuildTargets)
         {
            $platform = $BuildTarget.Platform
            $vulkan = $BuildTarget.Vulkan
            $osxArchitectures = $Config.GetOSXArchitectures()

            if ($osxArchitectures -eq $platform )
            {
               Write-Host "Invoke libtool for ${platform}" -ForegroundColor Yellow

               if (Test-Path "libOpenJpegDotNetNative_merged.a")
               {
                  Remove-Item "libOpenJpegDotNetNative_merged.a"
               }

               # https://github.com/abseil/abseil-cpp/issues/604
               libtool -o "libOpenJpegDotNetNative_merged.a" `
                          "libOpenJpegDotNetNative.a" `
                          "openjpeg/install/lib/libopenjp2.a"
            }
         }
      }
   }

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

   $dstDir = Join-Path $dstDir runtimes | `
             Join-Path -ChildPath ${rid} | `
             Join-Path -ChildPath native

   $output = Join-Path $dstDir $libraryName

   if (!(Test-Path($binary)))
   {
      Write-Host "${binary} does not exist" -ForegroundColor Red
   }

   if (!(Test-Path($dstDir)))
   {
      Write-Host "${dstDir} does not exist" -ForegroundColor Red
   }

   Write-Host "Copy ${libraryName} to ${output}" -ForegroundColor Green
   Copy-Item ${binary} ${output}
}