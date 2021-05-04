using System;
using System.IO;
using System.Linq;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJpegDotNet.Tests
{

    public sealed partial class OpenJpegTest
    {

        #region DecompressionParameters

        [Fact]
        public void DecompressionParametersCodingFormat()
        {
            using var parameter = new DecompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.CodingFormat = value;
                Assert.Equal(value, parameter.CodingFormat);
            }
        }

        [Fact]
        public void DecompressionParametersCodingParameterLayer()
        {
            using var parameter = new DecompressionParameters();
            foreach (var value in new[] { 0u, 1u, 10u })
            {
                parameter.CodingParameterLayer = value;
                Assert.Equal(value, parameter.CodingParameterLayer);
            }
        }

        [Fact]
        public void DecompressionParametersCodingParameterReduce()
        {
            using var parameter = new DecompressionParameters();
            foreach (var value in new[] { 0u, 1u, 10u })
            {
                parameter.CodingParameterReduce = value;
                Assert.Equal(value, parameter.CodingParameterReduce);
            }
        }

        [Fact]
        public void DecompressionParametersDecodingAreaX0()
        {
            using var parameter = new DecompressionParameters();
            foreach (var value in new[] { 0u, 1u, 10u })
            {
                parameter.DecodingAreaX0 = value;
                Assert.Equal(value, parameter.DecodingAreaX0);
            }
        }

        [Fact]
        public void DecompressionParametersDecodingAreaX1()
        {
            using var parameter = new DecompressionParameters();
            foreach (var value in new[] { 0u, 1u, 10u })
            {
                parameter.DecodingAreaX1 = value;
                Assert.Equal(value, parameter.DecodingAreaX1);
            }
        }

        [Fact]
        public void DecompressionParametersDecodingAreaY0()
        {
            using var parameter = new DecompressionParameters();
            foreach (var value in new[] { 0u, 1u, 10u })
            {
                parameter.DecodingAreaY0 = value;
                Assert.Equal(value, parameter.DecodingAreaY0);
            }
        }

        [Fact]
        public void DecompressionParametersDecodingAreaY1()
        {
            using var parameter = new DecompressionParameters();
            foreach (var value in new[] { 0u, 1u, 10u })
            {
                parameter.DecodingAreaY1 = value;
                Assert.Equal(value, parameter.DecodingAreaY1);
            }
        }

        [Fact]
        public void DecompressionParametersDecodingFormat()
        {
            using var parameter = new DecompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.DecodingFormat = value;
                Assert.Equal(value, parameter.DecodingFormat);
            }
        }

        [Fact]
        public void DecompressionParametersFlags()
        {
            using var parameter = new DecompressionParameters();
            foreach (var value in new[] { 0u, 1u, 10u })
            {
                parameter.Flags = value;
                Assert.Equal(value, parameter.Flags);
            }
        }

        [Fact]
        public void DecompressionParametersJpwlCorrect()
        {
            using var parameter = new DecompressionParameters();
            foreach (var value in new[] { true, false })
            {
                parameter.JpwlCorrect = value;
                Assert.Equal(value, parameter.JpwlCorrect);
            }
        }

        [Fact]
        public void DecompressionParametersJpwlExpectedComponents()
        {
            using var parameter = new DecompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.JpwlExpectedComponents = value;
                Assert.Equal(value, parameter.JpwlExpectedComponents);
            }
        }

        [Fact]
        public void DecompressionParametersJpwlMaxTiles()
        {
            using var parameter = new DecompressionParameters();
            foreach (var value in new[] { 0, 1, 10 })
            {
                parameter.JpwlMaxTiles = value;
                Assert.Equal(value, parameter.JpwlMaxTiles);
            }
        }

        [Fact]
        public void DecompressionParametersNumberBlockTileToDecide()
        {
            using var parameter = new DecompressionParameters();
            foreach (var value in new[] { 0u, 1u, 10u })
            {
                parameter.NumberBlockTileToDecide = value;
                Assert.Equal(value, parameter.NumberBlockTileToDecide);
            }
        }

        [Fact]
        public void DecompressionParametersTileIndex()
        {
            using var parameter = new DecompressionParameters();
            foreach (var value in new[] { 0u, 1u, 10u })
            {
                parameter.TileIndex = value;
                Assert.Equal(value, parameter.TileIndex);
            }
        }

        [Fact]
        public void DecompressionParametersVerboseMode()
        {
            using var parameter = new DecompressionParameters();
            foreach (var value in new[] { true, false })
            {
                parameter.VerboseMode = value;
                Assert.Equal(value, parameter.VerboseMode);
            }
        }

        #endregion

        #region Functions

        [Fact]
        public void Decode()
        {
            var targets = new[]
            {
                //new { Name = "Bretagne1_0.j2k", IsReadStream = true, Format = CodecFormat.Unknown,  Result = false },
                new { Name = "Bretagne1_0.j2k", IsReadStream = true, Format = CodecFormat.J2k,      Result = true  },
                //new { Name = "Bretagne1_0.j2k", IsReadStream = true, Format = CodecFormat.Jp2,      Result = false  },
                //new { Name = "Bretagne1_0.j2k", IsReadStream = true, Format = CodecFormat.Jpp,      Result = false },
                //new { Name = "Bretagne1_0.j2k", IsReadStream = true, Format = CodecFormat.Jpt,      Result = false },
                //new { Name = "Bretagne1_0.j2k", IsReadStream = true, Format = CodecFormat.Jpx,      Result = false }
            };

            foreach (var target in targets)
            {
                var path = Path.GetFullPath(Path.Combine(TestImageDirectory, target.Name));

                var stream = OpenJpeg.StreamCreateDefaultFileStream(path, target.IsReadStream);
                var codec = OpenJpeg.CreateDecompress(target.Format);
                var decompressionParameters = new DecompressionParameters();
                OpenJpeg.SetDefaultDecoderParameters(decompressionParameters);
                Assert.True(OpenJpeg.SetupDecoder(codec, decompressionParameters) == target.Result, $"Failed to invoke {nameof(OpenJpeg.SetupDecoder)} for {target.Format} and {target.IsReadStream}");
                Assert.True(OpenJpeg.ReadHeader(stream, codec, out var image) == target.Result, $"Failed to invoke {nameof(OpenJpeg.ReadHeader)} for {target.Format} and {target.IsReadStream}");
                Assert.True(OpenJpeg.SetDecodeArea(codec, image, 0, 0, 0, 0) == target.Result, $"Failed to invoke {nameof(OpenJpeg.SetDecodeArea)} for {target.Format} and {target.IsReadStream}");
                Assert.True(OpenJpeg.Decode(codec, stream, image) == target.Result, $"Failed to invoke {nameof(OpenJpeg.Decode)} for {target.Format} and {target.IsReadStream}");
                Assert.True(OpenJpeg.EndDecompress(codec, stream) == target.Result, $"Failed to invoke {nameof(OpenJpeg.EndDecompress)} for {target.Format} and {target.IsReadStream}");

                this.DisposeAndCheckDisposedState(image);
                this.DisposeAndCheckDisposedState(stream);
                this.DisposeAndCheckDisposedState(decompressionParameters);
                this.DisposeAndCheckDisposedState(codec);
            }
        }

        [Fact]
        public void CodecSetThreads()
        {
            var targets = new[]
            {
                //new { Name = "Bretagne1_0.j2k", IsReadStream = true, Format = CodecFormat.Unknown,  Result = false },
                new { Name = "Bretagne1_0.j2k", IsReadStream = true, Format = CodecFormat.J2k,      Result = true  },
                //new { Name = "Bretagne1_0.j2k", IsReadStream = true, Format = CodecFormat.Jp2,      Result = false  },
                //new { Name = "Bretagne1_0.j2k", IsReadStream = true, Format = CodecFormat.Jpp,      Result = false },
                //new { Name = "Bretagne1_0.j2k", IsReadStream = true, Format = CodecFormat.Jpt,      Result = false },
                //new { Name = "Bretagne1_0.j2k", IsReadStream = true, Format = CodecFormat.Jpx,      Result = false }
            };

            foreach (var target in targets)
            {
                var codec = OpenJpeg.CreateDecompress(target.Format);
                Assert.True(OpenJpeg.CodecSetThreads(codec, 2));
                Assert.True(OpenJpeg.CodecSetThreads(codec, 0));
                Assert.False(OpenJpeg.CodecSetThreads(codec, -1));
                this.DisposeAndCheckDisposedState(codec);
            }
        }

        #endregion

    }

}
