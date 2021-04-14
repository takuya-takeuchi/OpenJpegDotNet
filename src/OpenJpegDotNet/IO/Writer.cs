using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace OpenJpegDotNet.IO
{

    public sealed class Writer : IDisposable
    {

        #region Fields

        private readonly Buffer _Buffer;

        private readonly IntPtr _UserData;

        private readonly DelegateHandler<StreamRead> _ReadCallback;

        private readonly DelegateHandler<StreamWrite> _WriteCallback;

        private readonly DelegateHandler<StreamSeek> _SeekCallback;

        private readonly DelegateHandler<StreamSkip> _SkipCallback;

        private Codec _Codec;

        private CompressionParameters _CompressionParameters;

        private Image _Image;

        private readonly Stream _Stream;

        #endregion

        #region Constructors

        public Writer(byte[] data)
        {
            this._Buffer = new Buffer
            {
                Data = Marshal.AllocHGlobal(data.Length),
                Length = data.Length,
                Position = 0
            };

            Marshal.Copy(data, 0, this._Buffer.Data, this._Buffer.Length);

            var size = Marshal.SizeOf(this._Buffer);
            this._UserData = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(this._Buffer, this._UserData, false);

            this._WriteCallback = new DelegateHandler<StreamWrite>(Write);
            this._ReadCallback = new DelegateHandler<StreamRead>(Read);
            this._SeekCallback = new DelegateHandler<StreamSeek>(Seek);
            this._SkipCallback = new DelegateHandler<StreamSkip>(Skip);

            this._Stream = OpenJpeg.StreamDefaultCreate(true);
            OpenJpeg.StreamSetUserData(this._Stream, this._UserData);
            OpenJpeg.StreamSetUserDataLength(this._Stream, this._Buffer.Length);
            OpenJpeg.StreamSetReadFunction(this._Stream, this._ReadCallback);
            OpenJpeg.StreamSetWriteFunction(this._Stream, this._WriteCallback);
            OpenJpeg.StreamSetSeekFunction(this._Stream, this._SeekCallback);
            OpenJpeg.StreamSetSkipFunction(this._Stream, this._SkipCallback);
        }

        #endregion

        #region Properties

        public int Height
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether this instance has been disposed.
        /// </summary>
        /// <returns>true if this instance has been disposed; otherwise, false.</returns>
        public bool IsDisposed
        {
            get;
            private set;
        }

        public int Width
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        public bool WriteHeader(Parameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            this._Codec?.Dispose();
            this._CompressionParameters?.Dispose();
            this._Image?.Dispose();

            this._Codec = null;
            this._CompressionParameters = null;
            this._Image = null;

            // ToDo: Support to change format?
            this._Codec = OpenJpeg.CreateDecompress(CodecFormat.J2k);
            //this._Codec = OpenJpeg.CreateDecompress(CodecFormat.Jp2);
            this._CompressionParameters = this.SetupEncoderParameters(parameter);

            return true;
        }

        public Bitmap ReadData()
        {
            if (this._Image == null || this._Image.IsDisposed)
                throw new InvalidOperationException();

            if (!OpenJpeg.Decode(this._Codec, this._Stream, this._Image))
                throw new InvalidOperationException();

            return this._Image.ToBitmap();
        }

        public byte[] Write(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException(nameof(bitmap));

            this._Codec?.Dispose();
            this._CompressionParameters?.Dispose();
            this._Image?.Dispose();

            var channels = 0;
            var outPrecision = 0u;
            var colorSpace = ColorSpace.Gray;
            var format = bitmap.PixelFormat;
            var width = bitmap.Width;
            var height = bitmap.Height;
            switch (format)
            {
                case PixelFormat.Format24bppRgb:
                    channels = 3;
                    outPrecision = 24u / (uint)channels;
                    colorSpace = ColorSpace.Srgb;
                    break;
            }

            var componentParametersArray = new ImageComponentParameters[channels];
            for (var i = 0; i < channels; i++)
            {
                componentParametersArray[i].Precision = outPrecision;
                componentParametersArray[i].Bpp = outPrecision;
                componentParametersArray[i].Signed = false;
                componentParametersArray[i].Dx = (uint)this._CompressionParameters.SubsamplingDx;
                componentParametersArray[i].Dy = (uint)this._CompressionParameters.SubsamplingDy;
                componentParametersArray[i].Width = (uint)width;
                componentParametersArray[i].Height = (uint)height;
            }

            Image image = null;

            try
            {
                // ToDo: throw proper exception
                image = OpenJpeg.ImageCreate((uint) channels, componentParametersArray, colorSpace);
                if (image == null)
                    throw new ArgumentException();

                // ToDo: support alpha components
                //switch (channels)
                //{
                //    case 2:
                //    case 4:
                //        image.Components[(int)(channels - 1)].Alpha = 1;
                //        break;
                //}

                image.X0 = 0;
                image.Y0 = 0;
                image.X1 = componentParametersArray[0].Dx * componentParametersArray[0].Width;
                image.Y1 = componentParametersArray[0].Dy * componentParametersArray[0].Height;

                
                //std::vector<OPJ_INT32*> outcomps(channels, nullptr);
                //switch (channels)
                //{
                //    case 1:
                //        outcomps.assign({ image.Components[0].data });
                //        break;
                //    // Reversed order for BGR -> RGB conversion
                //    case 2:
                //        outcomps.assign({ image.Components[0].data, image.Components[1].data });
                //        break;
                //    case 3:
                //        outcomps.assign({ image.Components[2].data, image.Components[1].data, image.Components[0].data });
                //        break;
                //    case 4:
                //        outcomps.assign({
                //        image.Components[2].data, image.Components[1].data, image.Components[0].data,
                //        image.Components[3].data });
                //        break;
                //}
            }
            finally
            {
                image?.Dispose();
            }

            return null;
        }

        #region Event Handlers

        private static ulong Read(IntPtr buffer, ulong bytes, IntPtr userData)
        {
            unsafe
            {
                var buf = (Buffer*)userData;
                var bytesToRead = (int)Math.Min((ulong)buf->Length, bytes);
                if (bytesToRead > 0)
                {
                    NativeMethods.cstd_memcpy(buffer, IntPtr.Add(buf->Data, buf->Position), bytesToRead);
                    buf->Position += bytesToRead;
                    return (ulong)bytesToRead;
                }
                else
                {
                    return unchecked((ulong)-1);
                }
            }
        }

        private static int Seek(ulong bytes, IntPtr userData)
        {
            unsafe
            {
                var buf = (Buffer*)userData;
                var position = Math.Min((ulong)buf->Length, bytes);
                buf->Position = (int)position;
                return 1;
            }
        }

        private static long Skip(ulong bytes, IntPtr userData)
        {
            unsafe
            {
                var buf = (Buffer*)userData;
                var bytesToSkip = (int)Math.Min((ulong)buf->Length, bytes);
                if (bytesToSkip > 0)
                {
                    buf->Position += bytesToSkip;
                    return bytesToSkip;
                }
                else
                {
                    return unchecked(-1);
                }
            }
        }

        private static ulong Write(IntPtr buffer, ulong bytes, IntPtr userData)
        {
            unsafe
            {
                var buf = (Buffer*)userData;
                var bytesToRead = (int)Math.Min((ulong)buf->Length, bytes);
                if (bytesToRead > 0)
                {
                    NativeMethods.cstd_memcpy(buffer, IntPtr.Add(buf->Data, buf->Position), bytesToRead);
                    buf->Position += bytesToRead;
                    return (ulong)bytesToRead;
                }
                else
                {
                    return unchecked((ulong)-1);
                }
            }
        }

        #endregion

        #region Helpers

        private CompressionParameters SetupEncoderParameters(Parameter parameter)
        {
            var compressionParameters = new CompressionParameters();
            OpenJpeg.SetDefaultEncoderParameters(compressionParameters);

            if (parameter.Compression.HasValue)
                compressionParameters.TcpRates[0] = 1000f / Math.Min(Math.Max(parameter.Compression.Value, 1), 1000);

            compressionParameters.TcpNumLayers = 1;
            compressionParameters.CodingParameterDistortionAllocation = 1;

            if (!parameter.Compression.HasValue)
                compressionParameters.TcpRates[0] = 4;

            return compressionParameters;
        }

        #endregion

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Releases all resources used by this <see cref="Reader"/>.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            //GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources used by this <see cref="Reader"/>.
        /// </summary>
        /// <param name="disposing">Indicate value whether <see cref="IDisposable.Dispose"/> method was called.</param>
        private void Dispose(bool disposing)
        {
            if (this.IsDisposed)
            {
                return;
            }

            this.IsDisposed = true;

            if (disposing)
            {
                this._Codec?.Dispose();
                this._CompressionParameters?.Dispose();
                this._Stream.Dispose();

                Marshal.FreeHGlobal(this._Buffer.Data);
                Marshal.FreeHGlobal(this._UserData);
            }
        }

        #endregion

    }

}