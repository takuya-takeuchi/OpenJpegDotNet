using System;
using System.Linq;
using OpenJpegDotNet;
using OpenJpegDotNet.Tests;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJpegDotNet.Tests
{

    public class OpenJpegTest : TestBase
    {
        
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
        public void GetNativeVersion()
        {
            var version = OpenJpeg.GetNativeVersion();
            Assert.True(!string.IsNullOrWhiteSpace(version));
        }

        [Fact]
        public void GetVersion()
        {
            var version = OpenJpeg.GetVersion();
            Assert.True(!string.IsNullOrWhiteSpace(version));
        }

    }

}
