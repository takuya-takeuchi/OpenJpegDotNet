using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using ViewJpeg2000.Models;
using ViewJpeg2000.Services.Interfaces;

namespace ViewJpeg2000.Services
{

    public sealed class ImageService : IImageService
    {

        #region IImageService Members

        public RawImage ToPng(byte[] content)
        {
            using var reader = new OpenJpegDotNet.IO.Reader(content);
            var result = reader.ReadHeader();
            using var rawBitmap = reader.ReadRawBitmap();
            return new RawImage(rawBitmap.Data.ToArray(), rawBitmap.Width, rawBitmap.Height, 3);
        }

        #endregion

    }

}
