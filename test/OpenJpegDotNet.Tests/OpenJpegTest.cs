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
                var codec = OpenJpeg.StreamCreateDefaultFileStream(path, target.IsReadStream);
                this.DisposeAndCheckDisposedState(codec);
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
        public void SetDefaultDecoderParameters()
        {
            var decompressionParameters = new DecompressionParameters();
            OpenJpeg.SetDefaultDecoderParameters(decompressionParameters);
            this.DisposeAndCheckDisposedState(decompressionParameters);
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
