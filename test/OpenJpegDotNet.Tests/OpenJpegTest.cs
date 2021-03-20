using System;
using System.IO;
using System.Linq;
using OpenJpegDotNet;
using OpenJpegDotNet.Tests;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJpegDotNet.Tests
{

    public class OpenJpegTest : TestBase
    {

        #region Fields

        private const string ResultDirectory = "Result";

        private const string TestImageDirectory = "TestImages";

        #endregion

        #region Version

        [Fact]
        public void GetVersion()
        {
            var version = OpenJpeg.GetVersion();
            Assert.True(!string.IsNullOrWhiteSpace(version));
        }

        #endregion

        #region Image



        #endregion

        #region Stream

        [Fact]
        public void StreamCreateDefaultFileStream()
        {
            var targets = new[]
            {
                new { Name = "Bretagne1_0.j2k", IsReadStream = true },
                new { Name = "Bretagne1_0.j2k", IsReadStream = false }
            };

            foreach (var target in targets)
            {
                var path = Path.Combine(TestImageDirectory, target.Name);
                var stream = OpenJpeg.StreamCreateDefaultFileStream(path, target.IsReadStream);
                this.DisposeAndCheckDisposedState(stream);
            }
        }

        #endregion

        #region Codec

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

        [Fact]
        public void CreateDecompress()
        {
            var formats = Enum.GetValues(typeof(CodecFormat)).Cast<CodecFormat>();
            foreach (var format in formats)
            {
                var codec = OpenJpeg.CreateDecompress(format);
                this.DisposeAndCheckDisposedState(codec);
            }
        }

        [Fact]
        public void ReadHeader()
        {
            var targets = new[]
            {
                new { Name = "Bretagne1_0.j2k", IsReadStream = true, Format = CodecFormat.Unknown,  Result = false },
                new { Name = "Bretagne1_0.j2k", IsReadStream = true, Format = CodecFormat.J2k,      Result = false  },
                new { Name = "Bretagne1_0.j2k", IsReadStream = true, Format = CodecFormat.Jp2,      Result = false  },
                new { Name = "Bretagne1_0.j2k", IsReadStream = true, Format = CodecFormat.Jpp,      Result = false },
                new { Name = "Bretagne1_0.j2k", IsReadStream = true, Format = CodecFormat.Jpt,      Result = false },
                new { Name = "Bretagne1_0.j2k", IsReadStream = true, Format = CodecFormat.Jpx,      Result = false },
                new { Name = "Bretagne1_0.j2k", IsReadStream = false, Format = CodecFormat.Unknown, Result = false },
                new { Name = "Bretagne1_0.j2k", IsReadStream = false, Format = CodecFormat.J2k,     Result = false  },
                new { Name = "Bretagne1_0.j2k", IsReadStream = false, Format = CodecFormat.Jp2,     Result = false  },
                new { Name = "Bretagne1_0.j2k", IsReadStream = false, Format = CodecFormat.Jpp,     Result = false },
                new { Name = "Bretagne1_0.j2k", IsReadStream = false, Format = CodecFormat.Jpt,     Result = false },
                new { Name = "Bretagne1_0.j2k", IsReadStream = false, Format = CodecFormat.Jpx,     Result = false },
            };

            foreach (var target in targets)
            {
                var path = Path.Combine(TestImageDirectory, target.Name);

                var stream = OpenJpeg.StreamCreateDefaultFileStream(path, target.IsReadStream);
                var codec = OpenJpeg.CreateDecompress(target.Format);
                var decompressionParameters = new DecompressionParameters();
                OpenJpeg.SetDefaultDecoderParameters(decompressionParameters);
                var ret = OpenJpeg.SetupDecoder(codec, decompressionParameters);
                Assert.True(OpenJpeg.ReadHeader(stream, codec, out var image) == target.Result, $"Failed to invoke {nameof(OpenJpeg.ReadHeader)} for {target.Format} and {target.IsReadStream}");
                
                this.DisposeAndCheckDisposedState(image);
                this.DisposeAndCheckDisposedState(stream);
                this.DisposeAndCheckDisposedState(decompressionParameters);
                this.DisposeAndCheckDisposedState(codec);
            }
        }

        [Fact]
        public void SetDefaultDecoderParameters()
        {
            var decompressionParameters = new DecompressionParameters();
            OpenJpeg.SetDefaultDecoderParameters(decompressionParameters);
            this.DisposeAndCheckDisposedState(decompressionParameters);
        }

        [Fact]
        public void SetupDecoder()
        {
            var targets = new[]
            {
                new { Format = CodecFormat.Unknown, Result = false },
                new { Format = CodecFormat.J2k,     Result = true  },
                new { Format = CodecFormat.Jp2,     Result = true  },
                new { Format = CodecFormat.Jpp,     Result = false },
                new { Format = CodecFormat.Jpt,     Result = false },
                new { Format = CodecFormat.Jpx,     Result = false },
            };

            foreach (var target in targets)
            {
                var codec = OpenJpeg.CreateDecompress(target.Format);
                var decompressionParameters = new DecompressionParameters();
                OpenJpeg.SetDefaultDecoderParameters(decompressionParameters);
                Assert.True(OpenJpeg.SetupDecoder(codec, decompressionParameters) == target.Result, $"Failed to invoke {nameof(OpenJpeg.SetupDecoder)} for {target.Format}");
                this.DisposeAndCheckDisposedState(decompressionParameters);
                this.DisposeAndCheckDisposedState(codec);
            }
        }

        #endregion

        #region Not Official

        [Fact]
        public void DecompressionParameters()
        {
            var decompressionParameters = new DecompressionParameters();
            this.DisposeAndCheckDisposedState(decompressionParameters);
        }

        #endregion

        [Fact]
        public void GetNativeVersion()
        {
            var version = OpenJpeg.GetNativeVersion();
            Assert.True(!string.IsNullOrWhiteSpace(version));
        }

    }

}
