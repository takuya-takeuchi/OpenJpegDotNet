using System.IO;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJpegDotNet.Tests
{

    public sealed partial class OpenJpegTest
    {

        #region Functions

        [Fact]
        public void StreamCreateDefaultFileStream()
        {
            var targets = new[]
            {
                new { Name = "Bretagne1_0.j2k", IsReadStream = true },
                //new { Name = "Bretagne1_0.j2k", IsReadStream = false }
            };

            foreach (var target in targets)
            {
                var path = Path.Combine(TestImageDirectory, target.Name);
                var stream = OpenJpeg.StreamCreateDefaultFileStream(path, target.IsReadStream);
                this.DisposeAndCheckDisposedState(stream);
            }
        }

        #endregion

    }

}
