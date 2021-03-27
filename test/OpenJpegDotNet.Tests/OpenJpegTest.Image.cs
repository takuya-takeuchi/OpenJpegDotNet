using System.Drawing.Imaging;
using System.IO;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJpegDotNet.Tests
{

    public sealed partial class OpenJpegTest
    {

        #region Not Native Functions

        [Fact]
        public void ToBitmap()
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

                using (var bitmap = image.ToBitmap())
                {
                    var bitmapPath = Path.ChangeExtension(path, "bmp");
                    bitmap.Save(bitmapPath, ImageFormat.Bmp);
                }

                this.DisposeAndCheckDisposedState(image);
                this.DisposeAndCheckDisposedState(stream);
                this.DisposeAndCheckDisposedState(decompressionParameters);
                this.DisposeAndCheckDisposedState(codec);
            }
        }

        #endregion

    }

}
