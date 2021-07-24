using System;
using System.IO;
using System.Runtime.InteropServices;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJpegDotNet.Tests
{

    public sealed partial class OpenJpegTest
    {

        #region Functions

        [Fact]
        public void HasThreadSupport()
        {
            Assert.True(OpenJpeg.HasThreadSupport());
        }

        [Fact]
        public void GetNumCpus()
        {
            var expected = System.Environment.ProcessorCount;
            var count = OpenJpeg.GetNumCpus();
            Assert.Equal(expected, count);
        }

        #endregion

    }

}
