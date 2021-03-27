using System.Drawing.Imaging;
using System.IO;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJpegDotNet.Tests
{

    public sealed partial class OpenJpegTest
    {

        #region ImageComponentParameters

        [Fact]
        public void ImageComponentParametersSigned()
        {
            using var parameter = new ImageComponentParameters();
            foreach (var value in new[] { true, false })
            {
                parameter.Signed = value;
                Assert.Equal(value, parameter.Signed);
            }
        }

        [Fact]
        public void ImageComponentParametersBpp()
        {
            using var parameter = new ImageComponentParameters();
            foreach (var value in new[] { 0u, 1u, 10u })
            {
                parameter.Bpp = value;
                Assert.Equal(value, parameter.Bpp);
            }
        }

        [Fact]
        public void ImageComponentParametersDx()
        {
            using var parameter = new ImageComponentParameters();
            foreach (var value in new[] { 0u, 1u, 10u })
            {
                parameter.Dx = value;
                Assert.Equal(value, parameter.Dx);
            }
        }

        [Fact]
        public void ImageComponentParametersDy()
        {
            using var parameter = new ImageComponentParameters();
            foreach (var value in new[] { 0u, 1u, 10u })
            {
                parameter.Dy = value;
                Assert.Equal(value, parameter.Dy);
            }
        }

        [Fact]
        public void ImageComponentParametersHeight()
        {
            using var parameter = new ImageComponentParameters();
            foreach (var value in new[] { 0u, 1u, 10u })
            {
                parameter.Height = value;
                Assert.Equal(value, parameter.Height);
            }
        }

        [Fact]
        public void ImageComponentParametersPrecision()
        {
            using var parameter = new ImageComponentParameters();
            foreach (var value in new[] { 0u, 1u, 10u })
            {
                parameter.Precision = value;
                Assert.Equal(value, parameter.Precision);
            }
        }

        [Fact]
        public void ImageComponentParametersWidth()
        {
            using var parameter = new ImageComponentParameters();
            foreach (var value in new[] { 0u, 1u, 10u })
            {
                parameter.Width = value;
                Assert.Equal(value, parameter.Width);
            }
        }

        [Fact]
        public void ImageComponentParametersX0()
        {
            using var parameter = new ImageComponentParameters();
            foreach (var value in new[] { 0u, 1u, 10u })
            {
                parameter.X0 = value;
                Assert.Equal(value, parameter.X0);
            }
        }

        [Fact]
        public void ImageComponentParametersY0()
        {
            using var parameter = new ImageComponentParameters();
            foreach (var value in new[] { 0u, 1u, 10u })
            {
                parameter.Y0 = value;
                Assert.Equal(value, parameter.Y0);
            }
        }

        #endregion

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
