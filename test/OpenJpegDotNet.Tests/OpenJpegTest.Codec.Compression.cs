using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJpegDotNet.Tests
{

    public sealed partial class OpenJpegTest
    {

        #region CompressionParameters

        [Fact]
        public void CompressionParametersCodeBlockHeightInitial()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.CodeBlockHeightInitial = value;
                Assert.Equal(value, parameter.CodeBlockHeightInitial);
            }
        }

        [Fact]
        public void CompressionParametersCodeBlockWidthInitial()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.CodeBlockWidthInitial = value;
                Assert.Equal(value, parameter.CodeBlockWidthInitial);
            }
        }

        [Fact]
        public void CompressionParametersCodingFormat()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.CodingFormat = value;
                Assert.Equal(value, parameter.CodingFormat);
            }
        }

        [Fact]
        public void CompressionParametersCodingParameterCinema()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in Enum.GetValues(typeof(CinemaMode)).Cast<CinemaMode>())
            {
                parameter.CodingParameterCinema = value;
                Assert.Equal(value, parameter.CodingParameterCinema);
            }
        }

        [Fact]
        public void CompressionParametersCodingParameterDistortionAllocation()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.CodingParameterDistortionAllocation = value;
                Assert.Equal(value, parameter.CodingParameterDistortionAllocation);
            }
        }

        [Fact]
        public void CompressionParametersCodingParameterFixedAllocation()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.CodingParameterFixedAllocation = value;
                Assert.Equal(value, parameter.CodingParameterFixedAllocation);
            }
        }

        [Fact]
        public void CompressionParametersCodingParameterFixedQuality()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.CodingParameterFixedQuality = value;
                Assert.Equal(value, parameter.CodingParameterFixedQuality);
            }
        }

        [Fact]
        public void CompressionParametersCodingParameterRegionSize()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in Enum.GetValues(typeof(RegionSizeCapabilities)).Cast<RegionSizeCapabilities>())
            {
                parameter.CodingParameterRegionSize = value;
                Assert.Equal(value, parameter.CodingParameterRegionSize);
            }
        }

        [Fact]
        public void CompressionParametersCodingParameterTdx()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.CodingParameterTdx = value;
                Assert.Equal(value, parameter.CodingParameterTdx);
            }
        }

        [Fact]
        public void CompressionParametersCodingParameterTdy()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.CodingParameterTdy = value;
                Assert.Equal(value, parameter.CodingParameterTdy);
            }
        }

        [Fact]
        public void CompressionParametersCodingParameterTx0()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.CodingParameterTx0 = value;
                Assert.Equal(value, parameter.CodingParameterTx0);
            }
        }

        [Fact]
        public void CompressionParametersCodingParameterTy0()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.CodingParameterTy0 = value;
                Assert.Equal(value, parameter.CodingParameterTy0);
            }
        }

        [Fact]
        public void CompressionParametersCodingStyle()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.CodingStyle = value;
                Assert.Equal(value, parameter.CodingStyle);
            }
        }

        [Fact]
        public void CompressionParametersDecodingFormat()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.DecodingFormat = value;
                Assert.Equal(value, parameter.DecodingFormat);
            }
        }

        [Fact]
        public void CompressionParametersImageOffsetX0()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.ImageOffsetX0 = value;
                Assert.Equal(value, parameter.ImageOffsetX0);
            }
        }

        [Fact]
        public void CompressionParametersImageOffsetY0()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.ImageOffsetY0 = value;
                Assert.Equal(value, parameter.ImageOffsetY0);
            }
        }

        [Fact]
        public void CompressionParametersIndexOn()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.IndexOn = value;
                Assert.Equal(value, parameter.IndexOn);
            }
        }

        [Fact]
        public void CompressionParametersIrreversible()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { true, false })
            {
                parameter.Irreversible = value;
                Assert.Equal(value, parameter.Irreversible);
            }
        }

        [Fact]
        public void CompressionParametersJpipOn()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { true, false })
            {
                parameter.JpipOn = value;
                Assert.Equal(value, parameter.JpipOn);
            }
        }

        [Fact]
        public void CompressionParametersJpwlEpcOn()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { true, false })
            {
                parameter.JpwlEpcOn = value;
                Assert.Equal(value, parameter.JpwlEpcOn);
            }
        }

        [Fact]
        public void CompressionParametersJpwlHeaderProtectionMainHeader()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.JpwlHeaderProtectionMainHeader = value;
                Assert.Equal(value, parameter.JpwlHeaderProtectionMainHeader);
            }
        }

        [Fact]
        public void CompressionParametersJpwlHeaderProtectionTilePartHeader()
        {
            var random = new Random();
            using var parameter = new CompressionParameters();

            var array = parameter.JpwlHeaderProtectionTilePartHeader;
            var expectArray = Enumerable.Range(0, array.Length).Select(i => random.Next()).ToArray();
            parameter.JpwlHeaderProtectionTilePartHeader = expectArray;
            array = parameter.JpwlHeaderProtectionTilePartHeader;

            for (var index = 0; index < expectArray.Length; index++)
                Assert.Equal(expectArray[index], array[index]);
        }

        [Fact]
        public void CompressionParametersJpwlHeaderProtectionTilePartHeaderTileNumber()
        {
            var random = new Random();
            using var parameter = new CompressionParameters();

            var array = parameter.JpwlHeaderProtectionTilePartHeaderTileNumber;
            var expectArray = Enumerable.Range(0, array.Length).Select(i => random.Next()).ToArray();
            parameter.JpwlHeaderProtectionTilePartHeaderTileNumber = expectArray;
            array = parameter.JpwlHeaderProtectionTilePartHeaderTileNumber;

            for (var index = 0; index < expectArray.Length; index++)
                Assert.Equal(expectArray[index], array[index]);
        }

        [Fact]
        public void CompressionParametersJpwlPacketProtection()
        {
            var random = new Random();
            using var parameter = new CompressionParameters();

            var array = parameter.JpwlPacketProtection;
            var expectArray = Enumerable.Range(0, array.Length).Select(i => random.Next()).ToArray();
            parameter.JpwlPacketProtection = expectArray;
            array = parameter.JpwlPacketProtection;

            for (var index = 0; index < expectArray.Length; index++)
                Assert.Equal(expectArray[index], array[index]);
        }

        [Fact]
        public void CompressionParametersJpwlPacketProtectionPacketNumber()
        {
            var random = new Random();
            using var parameter = new CompressionParameters();

            var array = parameter.JpwlPacketProtectionPacketNumber;
            var expectArray = Enumerable.Range(0, array.Length).Select(i => random.Next()).ToArray();
            parameter.JpwlPacketProtectionPacketNumber = expectArray;
            array = parameter.JpwlPacketProtectionPacketNumber;

            for (var index = 0; index < expectArray.Length; index++)
                Assert.Equal(expectArray[index], array[index]);
        }

        [Fact]
        public void CompressionParametersJpwlPacketProtectionTileNumber()
        {
            var random = new Random();
            using var parameter = new CompressionParameters();

            var array = parameter.JpwlPacketProtectionTileNumber;
            var expectArray = Enumerable.Range(0, array.Length).Select(i => random.Next()).ToArray();
            parameter.JpwlPacketProtectionTileNumber = expectArray;
            array = parameter.JpwlPacketProtectionTileNumber;

            for (var index = 0; index < expectArray.Length; index++)
                Assert.Equal(expectArray[index], array[index]);
        }

        [Fact]
        public void CompressionParametersJpwlSensitivityAddressing()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.JpwlSensitivityAddressing = value;
                Assert.Equal(value, parameter.JpwlSensitivityAddressing);
            }
        }

        [Fact]
        public void CompressionParametersJpwlSensitivityMainHeader()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.JpwlSensitivityMainHeader = value;
                Assert.Equal(value, parameter.JpwlSensitivityMainHeader);
            }
        }

        [Fact]
        public void CompressionParametersJpwlSensitivityRange()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.JpwlSensitivityRange = value;
                Assert.Equal(value, parameter.JpwlSensitivityRange);
            }
        }

        [Fact]
        public void CompressionParametersJpwlSensitivitySize()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.JpwlSensitivitySize = value;
                Assert.Equal(value, parameter.JpwlSensitivitySize);
            }
        }

        [Fact]
        public void CompressionParametersJpwlSensitivityTilePartHeader()
        {
            var random = new Random();
            using var parameter = new CompressionParameters();

            var array = parameter.JpwlSensitivityTilePartHeader;
            var expectArray = Enumerable.Range(0, array.Length).Select(i => random.Next()).ToArray();
            parameter.JpwlSensitivityTilePartHeader = expectArray;
            array = parameter.JpwlSensitivityTilePartHeader;

            for (var index = 0; index < expectArray.Length; index++)
                Assert.Equal(expectArray[index], array[index]);
        }

        [Fact]
        public void CompressionParametersJpwlSensitivityTilePartHeaderTileNo()
        {
            var random = new Random();
            using var parameter = new CompressionParameters();

            var array = parameter.JpwlSensitivityTilePartHeaderTileNo;
            var expectArray = Enumerable.Range(0, array.Length).Select(i => random.Next()).ToArray();
            parameter.JpwlSensitivityTilePartHeaderTileNo = expectArray;
            array = parameter.JpwlSensitivityTilePartHeaderTileNo;

            for (var index = 0; index < expectArray.Length; index++)
                Assert.Equal(expectArray[index], array[index]);
        }

        [Fact]
        public void CompressionParametersMaximumCodestreamSize()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.MaximumCodestreamSize = value;
                Assert.Equal(value, parameter.MaximumCodestreamSize);
            }
        }

        [Fact]
        public void CompressionParametersMaximumComponentSize()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.MaximumComponentSize = value;
                Assert.Equal(value, parameter.MaximumComponentSize);
            }
        }

        [Fact]
        public void CompressionParametersMode()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.Mode = value;
                Assert.Equal(value, parameter.Mode);
            }
        }

        [Fact]
        public void CompressionParametersNumProgressionOrderChanges()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0u, 1u, 10u })
            {
                parameter.NumProgressionOrderChanges = value;
                Assert.Equal(value, parameter.NumProgressionOrderChanges);
            }
        }

        [Fact]
        public void CompressionParametersNumResolution()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.NumResolution = value;
                Assert.Equal(value, parameter.NumResolution);
            }
        }

        [Fact]
        public void CompressionParametersPrecinctHeightInitial()
        {
            var random = new Random();
            using var parameter = new CompressionParameters();

            var array = parameter.PrecinctHeightInitial;
            var expectArray = Enumerable.Range(0, array.Length).Select(i => random.Next()).ToArray();
            parameter.PrecinctHeightInitial = expectArray;
            array = parameter.PrecinctHeightInitial;

            for (var index = 0; index < expectArray.Length; index++)
                Assert.Equal(expectArray[index], array[index]);
        }

        [Fact]
        public void CompressionParametersPrecinctWidthInitial()
        {
            var random = new Random();
            using var parameter = new CompressionParameters();

            var array = parameter.PrecinctWidthInitial;
            var expectArray = Enumerable.Range(0, array.Length).Select(i => random.Next()).ToArray();
            parameter.PrecinctWidthInitial = expectArray;
            array = parameter.PrecinctWidthInitial;

            for (var index = 0; index < expectArray.Length; index++)
                Assert.Equal(expectArray[index], array[index]);
        }

        [Fact]
        public void CompressionParametersProgressionOrder()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in Enum.GetValues(typeof(ProgressionOrder)).Cast<ProgressionOrder>())
            {
                parameter.ProgressionOrder = value;
                Assert.Equal(value, parameter.ProgressionOrder);
            }
        }

        [Fact]
        public void CompressionParametersRegionOfInterestComponent()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.RegionOfInterestComponent = value;
                Assert.Equal(value, parameter.RegionOfInterestComponent);
            }
        }

        [Fact]
        public void CompressionParametersRegionOfInterestShift()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.RegionOfInterestShift = value;
                Assert.Equal(value, parameter.RegionOfInterestShift);
            }
        }

        [Fact]
        public void CompressionParametersRegionSize()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new ushort[] { 0, 1, 10 })
            {
                parameter.RegionSize = value;
                Assert.Equal(value, parameter.RegionSize);
            }
        }

        [Fact]
        public void CompressionParametersResSpec()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.ResSpec = value;
                Assert.Equal(value, parameter.ResSpec);
            }
        }

        [Fact]
        public void CompressionParametersSubsamplingDx()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.SubsamplingDx = value;
                Assert.Equal(value, parameter.SubsamplingDx);
            }
        }

        [Fact]
        public void CompressionParametersSubsamplingDy()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.SubsamplingDy = value;
                Assert.Equal(value, parameter.SubsamplingDy);
            }
        }

        [Fact]
        public void CompressionParametersTcpDistoratio()
        {
            var random = new Random();
            using var parameter = new CompressionParameters();

            var array = parameter.TcpDistoratio;
            var expectArray = Enumerable.Range(0, array.Length).Select(i => (float)random.NextDouble()).ToArray();
            parameter.TcpDistoratio = expectArray;
            array = parameter.TcpDistoratio;

            for (var index = 0; index < expectArray.Length; index++)
                Assert.Equal(expectArray[index], array[index]);
        }

        [Fact]
        public void CompressionParametersTcpMCT()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new sbyte[] { -10, -1, 0, 1, 10 })
            {
                parameter.TcpMCT = value;
                Assert.Equal(value, parameter.TcpMCT);
            }
        }

        [Fact]
        public void CompressionParametersTcpNumLayers()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.TcpNumLayers = value;
                Assert.Equal(value, parameter.TcpNumLayers);
            }
        }

        [Fact]
        public void CompressionParametersTcpRates()
        {
            var random = new Random();
            using var parameter = new CompressionParameters();

            var array = parameter.TcpRates;
            var expectArray = Enumerable.Range(0, array.Length).Select(i => (float)random.NextDouble()).ToArray();
            parameter.TcpRates = expectArray;
            array = parameter.TcpRates;

            for (var index = 0; index < expectArray.Length; index++)
                Assert.Equal(expectArray[index], array[index]);
        }

        [Fact]
        public void CompressionParametersTilePartFlag()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new sbyte[] { -10, -1, 0, 1, 10 })
            {
                parameter.TilePartFlag = value;
                Assert.Equal(value, parameter.TilePartFlag);
            }
        }

        [Fact]
        public void CompressionParametersTilePartOn()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new sbyte[] { -10, -1, 0, 1, 10 })
            {
                parameter.TilePartOn = value;
                Assert.Equal(value, parameter.TilePartOn);
            }
        }

        [Fact]
        public void CompressionParametersTileSizeOn()
        {
            using var parameter = new CompressionParameters();
            foreach (var value in new[] { true, false })
            {
                parameter.TileSizeOn = value;
                Assert.Equal(value, parameter.TileSizeOn);
            }
        }

        #endregion

        #region Functions

        [Fact]
        public void Compress()
        {
            var targets = new[]
            {
                new { Format = CodecFormat.Unknown, FileName = $"{nameof(this.Encode)}.ukn", Result = false },
                new { Format = CodecFormat.J2k,     FileName = $"{nameof(this.Encode)}.j2k", Result = true  },
                new { Format = CodecFormat.Jp2,     FileName = $"{nameof(this.Encode)}.jp2", Result = true  },
                new { Format = CodecFormat.Jpp,     FileName = $"{nameof(this.Encode)}.jpp", Result = false },
                new { Format = CodecFormat.Jpt,     FileName = $"{nameof(this.Encode)}.jpt", Result = false },
                new { Format = CodecFormat.Jpx,     FileName = $"{nameof(this.Encode)}.jpx", Result = false },
            };

            const int numCompsMax = 4;
            const int codeBlockWidthInitial = 64;
            const int codeBlockHeightInitial = 64;
            const int numComps = 3;
            const int imageWidth = 2000;
            const int imageHeight = 2000;
            const int tileWidth = 1000;
            const int tileHeight = 1000;
            const uint compPrec = 8;
            const bool irreversible = false;
            const uint offsetX = 0;
            const uint offsetY = 0;

            var tilesWidth = (offsetX + imageWidth + tileWidth - 1) / tileWidth;
            var tilesHeight = (offsetY + imageHeight + tileHeight - 1) / tileHeight;
            var tiles = tilesWidth * tilesHeight;
            var dataSize = tileWidth * tileHeight * numComps * (compPrec / 8);

            var data = new byte[dataSize];
            for (var index = 0; index < data.Length; index++)
                data[index] = (byte)(index % byte.MaxValue);

            foreach (var target in targets)
            {
                var codec = OpenJpeg.CreateCompress(target.Format);
                var compressionParameters = new CompressionParameters();
                OpenJpeg.SetDefaultEncoderParameters(compressionParameters);

                compressionParameters.TcpNumLayers = 1;
                compressionParameters.CodingParameterFixedQuality = 1;
                compressionParameters.TcpDistoratio[0] = 20;
                compressionParameters.CodingParameterTx0 = 0;
                compressionParameters.CodingParameterTy0 = 0;
                compressionParameters.TileSizeOn = true;
                compressionParameters.CodingParameterTdx = tileWidth;
                compressionParameters.CodingParameterTdy = tileHeight;
                compressionParameters.CodeBlockWidthInitial = codeBlockWidthInitial;
                compressionParameters.CodeBlockHeightInitial = codeBlockHeightInitial;
                compressionParameters.Irreversible = irreversible;

                var parameters = new ImageComponentParameters[numCompsMax];
                for (var index = 0; index < parameters.Length; index++)
                {
                    parameters[index] = new ImageComponentParameters
                    {
                        Dx = 1,
                        Dy = 1,
                        Height = imageHeight,
                        Width = imageWidth,
                        Signed = false,
                        Precision = compPrec,
                        X0 = offsetX,
                        Y0 = offsetY
                    };
                }

                var image = OpenJpeg.ImageTileCreate(numComps, parameters, ColorSpace.Srgb);
                image.X0 = offsetX;
                image.Y0 = offsetY;
                image.X1 = offsetX + imageWidth;
                image.Y1 = offsetY + imageHeight;
                image.ColorSpace = ColorSpace.Srgb;

                Directory.CreateDirectory(ResultDirectory);
                Directory.CreateDirectory(Path.Combine(ResultDirectory, nameof(this.Encode)));
                var path = Path.Combine(ResultDirectory, nameof(this.Encode), target.FileName);

                Assert.True(OpenJpeg.SetupEncoder(codec, compressionParameters, image) == target.Result, $"Failed to invoke {nameof(OpenJpeg.SetupDecoder)} for {target.Format}");
                if (!target.Result)
                {
                    this.DisposeAndCheckDisposedState(image);
                    this.DisposeAndCheckDisposedState(compressionParameters);
                    this.DisposeAndCheckDisposedState(codec);
                    continue;
                }

                var stream = OpenJpeg.StreamCreateDefaultFileStream(path, false);

                OpenJpeg.StartCompress(codec, image, stream);

                for (var i = 0; i < tiles; ++i)
                {
                    var tileY = (uint)(i / tilesWidth);
                    var tileX = (uint)(i % tilesHeight);
                    var tileX0 = Math.Max(image.X0, tileX * tileWidth);
                    var tileY0 = Math.Max(image.Y0, tileY * tileHeight);
                    var tileX1 = Math.Min(image.X1, (tileX + 1) * tileWidth);
                    var tileY1 = Math.Min(image.Y1, (tileY + 1) * tileHeight);
                    var tilesize = (tileX1 - tileX0) * (tileY1 - tileY0) * numComps * (compPrec / 8);
                    Assert.True(OpenJpeg.WriteTile(codec, i, data, tilesize, stream), $"Failed to invoke {nameof(OpenJpeg.WriteTile)}");
                }

                OpenJpeg.EndCompress(codec, stream);

                this.DisposeAndCheckDisposedState(stream);
                this.DisposeAndCheckDisposedState(image);
                this.DisposeAndCheckDisposedState(compressionParameters);
                this.DisposeAndCheckDisposedState(codec);
            }
        }

        [Fact]
        public void Encode()
        {
            const string testImage = "obama-240p.jpg";
            var path = Path.GetFullPath(Path.Combine(TestImageDirectory, testImage));
            using var bitmap = System.Drawing.Image.FromFile(path) as Bitmap;

            var channels = 0;
            var outPrecision = 0u;
            var colorSpace = ColorSpace.Gray;
            var format = bitmap.PixelFormat;
            var width = bitmap.Width;
            var height = bitmap.Height;
            switch (format)
            {
                case PixelFormat.Format24bppRgb:
                    channels = 3;
                    outPrecision = 24u / (uint)channels;
                    colorSpace = ColorSpace.Srgb;
                    break;
            }

            using var compressionParameters = new CompressionParameters();
            OpenJpeg.SetDefaultEncoderParameters(compressionParameters);
            compressionParameters.TcpNumLayers = 1;
            compressionParameters.CodingParameterDistortionAllocation = 1;

            var componentParametersArray = new ImageComponentParameters[channels];
            for (var i = 0; i < channels; i++)
            {
                componentParametersArray[i] = new ImageComponentParameters
                {
                    Precision = outPrecision,
                    Bpp = outPrecision,
                    Signed = false,
                    Dx = (uint) compressionParameters.SubsamplingDx,
                    Dy = (uint) compressionParameters.SubsamplingDy,
                    Width = (uint) width,
                    Height = (uint) height
                };
            }

            using var image = OpenJpeg.ImageCreate((uint)channels, componentParametersArray, colorSpace);
            image.X0 = 0;
            image.Y0 = 0;
            image.X1 = componentParametersArray[0].Dx * componentParametersArray[0].Width;
            image.Y1 = componentParametersArray[0].Dy * componentParametersArray[0].Height;

            using var codec = OpenJpeg.CreateCompress(CodecFormat.Jp2);
            OpenJpeg.SetupEncoder(codec, compressionParameters, image);

            var data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);

            using var stream = OpenJpeg.StreamDefaultCreate(false);
            OpenJpeg.StreamSetUserData(stream, data.Scan0);
            OpenJpeg.StreamSetUserDataLength(stream, data.Stride * data.Height);
            //OpenJpeg.StreamSetWriteFunction(stream, new DelegateHandler<StreamWrite>(StreamWriteCallback));
            //OpenJpeg.StreamSetReadFunction(stream, new DelegateHandler<StreamRead>(StreamReadCallback));
            //OpenJpeg.StreamSetSeekFunction(stream, new DelegateHandler<StreamSeek>(StreamSeekCallback));
            //OpenJpeg.StreamSetSkipFunction(stream, new DelegateHandler<StreamSkip>(StreamSkipCallback));

            OpenJpeg.StartCompress(codec, image, stream);
            OpenJpeg.Encode(codec, stream);
            OpenJpeg.EndCompress(codec, stream);
            
            this.DisposeAndCheckDisposedStates(componentParametersArray);
        }

        #endregion

    }

}