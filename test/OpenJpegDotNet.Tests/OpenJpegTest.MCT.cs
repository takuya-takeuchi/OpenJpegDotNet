using System.IO;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJpegDotNet.Tests
{

    public sealed partial class OpenJpegTest
    {

        #region Functions

        [Fact]
        public void SetMCT()
        {
            var mct = new float[]
            {
                1, 0, 0,
                0, 1, 0,
                0, 0, 1
            };

            var dcShift = new[]
            {
                128, 128, 128
            };

            using var parameter = new CompressionParameters();
            Assert.True(OpenJpeg.SetMCT(parameter, mct, dcShift, 4));
        }

        #endregion

    }

}
