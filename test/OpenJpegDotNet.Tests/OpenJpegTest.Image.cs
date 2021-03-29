using System;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJpegDotNet.Tests
{

    public sealed partial class OpenJpegTest
    {

        #region Image

        [Fact]
        public void ImageColorSpace()
        {
            using var image = CreateImage();
            foreach (var value in Enum.GetValues(typeof(ColorSpace)).Cast<ColorSpace>())
            {
                image.ColorSpace = value;
                Assert.Equal(value, image.ColorSpace);
            }
        }

        [Fact]
        public void ImageNumberOfComponents()
        {
            const uint numComps = 3;
            using var image = CreateImage(numComps);
            Assert.Equal(numComps, image.NumberOfComponents);
        }

        [Fact]
        public void ImageX0()
        {
            using var image = CreateImage();
            foreach (var value in new[] { 0u, 1u, 10u })
            {
                image.X0 = value;
                Assert.Equal(value, image.X0);
            }
        }

        [Fact]
        public void ImageX1()
        {
            using var image = CreateImage();
            foreach (var value in new[] { 0u, 1u, 10u })
            {
                image.X1 = value;
                Assert.Equal(value, image.X1);
            }
        }

        [Fact]
        public void ImageY0()
        {
            using var image = CreateImage();
            foreach (var value in new[] { 0u, 1u, 10u })
            {
                image.Y0 = value;
                Assert.Equal(value, image.Y0);
            }
        }

        [Fact]
        public void ImageY1()
        {
            using var image = CreateImage();
            foreach (var value in new[] { 0u, 1u, 10u })
            {
                image.Y1 = value;
                Assert.Equal(value, image.Y1);
            }
        }

        #endregion

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

        #region Helpers

        private static Image CreateImage(uint numComps = 3)
        {
            const int numCompsMax = 4;
            const int codeBlockWidthInitial = 64;
            const int codeBlockHeightInitial = 64;
            const int imageWidth = 2000;
            const int imageHeight = 2000;
            const int tileWidth = 1000;
            const int tileHeight = 1000;
            const uint compPrec = 8;
            const bool irreversible = false;
            const uint offsetX = 0;
            const uint offsetY = 0;

            using var codec = OpenJpeg.CreateCompress(CodecFormat.Jp2);
            using var compressionParameters = new CompressionParameters();
            OpenJpeg.SetDefaultEncoderParameters(compressionParameters);

            compressionParameters.TcpNumLayers = 1;
            compressionParameters.CodingParameterFixedQuality = 1;
            compressionParameters.TcpDistoratio[0] = 20;
            compressionParameters.CodingParameterTx0 = 0;
            compressionParameters.CodingParameterTy0 = 0;
            compressionParameters.TileSizeOn = true;
            compressionParameters.CodingParameterTdx = tileWidth;
            compressionParameters.CodingParameterTdy = tileHeight;
            compressionParameters.CodeBlockWidthInitial = codeBlockWidthInitial;
            compressionParameters.CodeBlockHeightInitial = codeBlockHeightInitial;
            compressionParameters.Irreversible = irreversible;

            var parameters = new ImageComponentParameters[numCompsMax];
            for (var index = 0; index < parameters.Length; index++)
            {
                parameters[index] = new ImageComponentParameters
                {
                    Dx = 1,
                    Dy = 1,
                    Height = imageHeight,
                    Width = imageWidth,
                    Signed = false,
                    Precision = compPrec,
                    X0 = offsetX,
                    Y0 = offsetY
                };
            }

            var data = new byte[imageWidth * imageHeight];
            for (var index = 0; index < data.Length; index++)
                data[index] = (byte)(index % byte.MaxValue);

            var image = OpenJpeg.ImageTileCreate(numComps, parameters, ColorSpace.Srgb);

            foreach (var parameter in parameters)
                parameter.Dispose();

            return image;
        }

        #endregion

    }

}
