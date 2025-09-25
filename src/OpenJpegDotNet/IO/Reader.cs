using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace OpenJpegDotNet.IO
{

    public sealed class Reader : IDisposable
    {

        #region Fields

        private readonly Buffer _Buffer;

        private readonly IntPtr _UserData;

        private readonly DelegateHandler<StreamRead> _ReadCallback;

        private readonly DelegateHandler<StreamSeek> _SeekCallback;

        private readonly DelegateHandler<StreamSkip> _SkipCallback;

        private Codec _Codec;

        private DecompressionParameters _DecompressionParameters;

        private Image _Image;

        private readonly Stream _Stream;

        #endregion

        #region Constructors

        public Reader(byte[] data)
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

            this._ReadCallback = new DelegateHandler<StreamRead>(Read);
            this._SeekCallback = new DelegateHandler<StreamSeek>(Seek);
            this._SkipCallback = new DelegateHandler<StreamSkip>(Skip);

            this._Stream = OpenJpeg.StreamDefaultCreate(true);
            OpenJpeg.StreamSetUserData(this._Stream, this._UserData);
            OpenJpeg.StreamSetUserDataLength(this._Stream, this._Buffer.Length);
            OpenJpeg.StreamSetReadFunction(this._Stream, this._ReadCallback);
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

        /// <summary>
        /// Reads the header of the image stream and initializes the decoder with the specified codec format.
        /// </summary>
        /// <param name="codecFormat">The codec format to use for decompression. Default is <see cref="CodecFormat.Jp2"/>.</param>
        /// <returns><c>true</c> if the header was read successfully; otherwise, <c>false</c>.</returns>
        public bool ReadHeader(CodecFormat codecFormat = CodecFormat.Jp2)
        {
            this._Codec?.Dispose();
            this._DecompressionParameters?.Dispose();
            this._Image?.Dispose();

            this._Codec = null;
            this._DecompressionParameters = null;
            this._Image = null;

            // Set codec format
            this._Codec = OpenJpeg.CreateDecompress(codecFormat);

            this._DecompressionParameters = new DecompressionParameters();
            OpenJpeg.SetDefaultDecoderParameters(this._DecompressionParameters);

            if (!OpenJpeg.SetupDecoder(this._Codec, this._DecompressionParameters))
                return false;

            if (!OpenJpeg.ReadHeader(this._Stream, this._Codec, out var image))
                return false;

            this.Width = (int)(image.X1 - image.X0);
            this.Height = (int)(image.Y1 - image.Y0);
            this._Image = image;

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

        public RawBitmap ReadRawBitmap()
        {
            if (this._Image == null || this._Image.IsDisposed)
                throw new InvalidOperationException();

            if (!OpenJpeg.Decode(this._Codec, this._Stream, this._Image))
                throw new InvalidOperationException();

            return this._Image.ToRawBitmap();
        }

        #region Event Handlers

        private static ulong Read(IntPtr buffer, ulong bytes, IntPtr userData)
        {
            unsafe
            {
                var buf = (Buffer*)userData;
                var bytesToRead = (int)Math.Min((ulong)(buf->Length - buf->Position), bytes);
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
                this._DecompressionParameters?.Dispose();
                this._Stream.Dispose();

                Marshal.FreeHGlobal(this._Buffer.Data);
                Marshal.FreeHGlobal(this._UserData);
            }
        }

        #endregion

    }

}
