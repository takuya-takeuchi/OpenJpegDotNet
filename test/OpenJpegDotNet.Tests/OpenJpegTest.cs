using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJpegDotNet.Tests
{

    public sealed partial class OpenJpegTest : TestBase
    {

        #region Fields

        private const string ResultDirectory = "Result";

        private const string TestImageDirectory = "TestImages";

        #endregion

        #region Functions

        [Fact]
        public void GetVersion()
        {
            var version = OpenJpeg.GetVersion();
            Assert.True(!string.IsNullOrWhiteSpace(version));
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
