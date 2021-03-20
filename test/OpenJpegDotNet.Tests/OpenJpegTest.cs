using OpenJpegDotNet;
using OpenJpegDotNet.Tests;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJpegDotNet.Tests
{

    public class OpenJpegTest : TestBase
    {

        [Fact]
        public void GetVersion()
        {
            var version = OpenJpeg.GetVersion();
            Assert.True(!string.IsNullOrWhiteSpace(version));
        }

    }

}
