using System;
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
        public void CreateCompress()
        {
            var formats = Enum.GetValues(typeof(CodecFormat)).Cast<CodecFormat>();
            foreach (var format in formats)
            {
                var codec = OpenJpeg.CreateCompress(format);
                this.DisposeAndCheckDisposedState(codec);
            }
        }

        #endregion

        #region Not Native Functions

        [Fact]
        public void CompressionParameters()
        {
            var compressionParameters = new CompressionParameters();
            this.DisposeAndCheckDisposedState(compressionParameters);
        }

        [Fact]
        public void SetDefaultEncoderParameters()
        {
            var compressionParameters = new CompressionParameters();
            OpenJpeg.SetDefaultEncoderParameters(compressionParameters);
            this.DisposeAndCheckDisposedState(compressionParameters);
        }

        #endregion

    }

}
