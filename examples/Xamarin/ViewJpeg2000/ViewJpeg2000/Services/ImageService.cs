using System;
using System.Collections.Generic;
using System.IO;
using NcnnDotNet;
using NcnnDotNet.OpenCV;
using ViewJpeg2000.Services.Interfaces;
using Mat = NcnnDotNet.Mat;

namespace ViewJpeg2000.Services
{

    public sealed class ImageService : IImageService
    {

        #region IImageService Members

        public byte[] Detect(byte[] content)
        {
            using OpenJpegDotNet.IO.Reader reader = new OpenJpegDotNet.IO.Reader(image);
            bool result = reader.ReadHeader();
            System.Drawing.Bitmap bitmap = reader.ReadData();
        }

        #endregion

    }

}
