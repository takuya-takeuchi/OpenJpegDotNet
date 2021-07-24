# ![Alt text](nuget/jpeg48.png "OpenJpegDotNet") OpenJpegDotNet [![GitHub license](https://img.shields.io/github/license/mashape/apistatus.svg)]()

OpenJpeg wrapper written in C++ and C# for Windows, MacOS, Linux, iOS and Android

#### OpenJpegDotNet

|Package|OS|x86|x64|ARM|ARM64|Nuget|
|---|---|---|---|---|---|---|
|OpenJpegDotNet|Windows|✓|✓|-|-|[![NuGet version](https://img.shields.io/nuget/v/OpenJpegDotNet.svg)](https://www.nuget.org/packages/OpenJpegDotNet)|
||Linux|-|✓|✓|✓|[![NuGet version](https://img.shields.io/nuget/v/OpenJpegDotNet.svg)](https://www.nuget.org/packages/OpenJpegDotNet)|
||OSX|-|✓|-|-|[![NuGet version](https://img.shields.io/nuget/v/OpenJpegDotNet.svg)](https://www.nuget.org/packages/OpenJpegDotNet)|
|OpenJpegDotNet (Xamarin)|UWP|✓|✓|✓|✓|[![NuGet version](https://img.shields.io/nuget/v/OpenJpegDotNet.Xamarin.svg)](https://www.nuget.org/packages/OpenJpegDotNet.Xamarin)|
||Android|✓|✓|✓|✓|[![NuGet version](https://img.shields.io/nuget/v/OpenJpegDotNet.Xamarin.svg)](https://www.nuget.org/packages/OpenJpegDotNet.Xamarin)|
||iOS|-|✓|-|✓|[![NuGet version](https://img.shields.io/nuget/v/OpenJpegDotNet.Xamarin.svg)](https://www.nuget.org/packages/OpenJpegDotNet.Xamarin)|
 
## How to use?

OpenJpegDotNet provides **OpenJpeg APIs** and **Auxiliary APIs**. Auxiliary APIs allows developers to decode/encode jpeg 2000 data easily.

### :warning: Warning

Auxiliary APIs only wraps native OpenJpeg APIs. 
Auxiliary APIs may be changed in the future.

### Read

````csharp
byte[] image = System.IO.File.ReadAllBytes("test.j2k");
using OpenJpegDotNet.IO.Reader reader = new OpenJpegDotNet.IO.Reader(image);
bool result = reader.ReadHeader();
System.Drawing.Bitmap bitmap = reader.ReadData();
````

## Dependencies Libraries and Products

#### [OpenJpeg](https://github.com/uclouvain/openjpeg)

> **License:** BSD 2-clause "Simplified" License
>
> **Author:** Université de Louvain
> 
> **Principal Use:** An open-source JPEG 2000 codec written in C language. Main goal of OpenJpegDotNet is what wraps OpenJpeg by C#.