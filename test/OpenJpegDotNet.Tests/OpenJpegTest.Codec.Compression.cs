using System;
using System.Linq;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJpegDotNet.Tests
{

    public sealed partial class OpenJpegTest
    {

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

    }

}
