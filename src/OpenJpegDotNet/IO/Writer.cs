using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace OpenJpegDotNet.IO
{

    public sealed class Writer : IDisposable
    {

        #region Fields

        private readonly Buffer _Buffer;

        private readonly IntPtr _UserData;

        private readonly DelegateHandler<StreamWrite> _WriteCallback;

        private readonly DelegateHandler<StreamSeek> _SeekCallback;

        private readonly DelegateHandler<StreamSkip> _SkipCallback;

        private Codec _Codec;

        private CompressionParameters _CompressionParameters;

        private OpenJpegDotNet.Image _Image;

        private readonly Stream _Stream;

        #endregion

        #region Constructors

        public Writer(Bitmap bitmap)
        {
            _Image = ImageHelper.FromBitmap(bitmap);
            int datalen = (int)(_Image.X1 * _Image.Y1 * _Image.NumberOfComponents + 1024);

            this._Buffer = new Buffer
            {
                Data = Marshal.AllocHGlobal(datalen),
                Length = datalen,
                Position = 0
            };

            var size = Marshal.SizeOf(this._Buffer);
            this._UserData = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(this._Buffer, this._UserData, false);

            this._WriteCallback = new DelegateHandler<StreamWrite>(Write);
            this._SeekCallback = new DelegateHandler<StreamSeek>(Seek);
            this._SkipCallback = new DelegateHandler<StreamSkip>(Skip);

            this._Stream = OpenJpeg.StreamCreate((ulong)_Buffer.Length, false);
            OpenJpeg.StreamSetUserData(this._Stream, this._UserData);
            OpenJpeg.StreamSetUserDataLength(this._Stream, this._Buffer.Length);
            OpenJpeg.StreamSetWriteFunction(this._Stream, this._WriteCallback);
            OpenJpeg.StreamSetSeekFunction(this._Stream, this._SeekCallback);
            OpenJpeg.StreamSetSkipFunction(this._Stream, this._SkipCallback);

            _Codec = OpenJpeg.CreateCompress(CodecFormat.J2k);

            this._CompressionParameters = new CompressionParameters();
            OpenJpeg.SetDefaultEncoderParameters(this._CompressionParameters);
            this._CompressionParameters.TcpNumLayers = 1;
            this._CompressionParameters.CodingParameterDistortionAllocation = 1;

            OpenJpeg.SetupEncoder(_Codec, _CompressionParameters, _Image);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether this instance has been disposed.
        /// </summary>
        /// <returns>true if this instance has been disposed; otherwise, false.</returns>
        public bool IsDisposed
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        public byte[] Encode()
        {
            if (_Codec == null || _Codec.IsDisposed || _Image == null || _Image.IsDisposed
                || _Stream == null || _Stream.IsDisposed) { throw new InvalidOperationException(); }

            if (!OpenJpeg.StartCompress(_Codec, _Image, _Stream)) { throw new InvalidOperationException(); }
            if (!OpenJpeg.Encode(_Codec, _Stream)) { throw new InvalidOperationException(); }
            if (!OpenJpeg.EndCompress(_Codec, _Stream)) { throw new InvalidOperationException(); }

            var data_st = Marshal.PtrToStructure<Buffer>(_UserData);
            var output = new byte[data_st.Position];
            Marshal.Copy(_Buffer.Data, output, 0, output.Length);

            return output;
        }

        #region Event Handlers

        private static int Seek(ulong bytes, IntPtr userData)
        {
            unsafe
            {
                var buf = (Buffer*)userData;
                if (buf == null || buf->Data == IntPtr.Zero || buf->Length == 0)
                    return 0;

                buf->Position = (int)Math.Min(bytes, (ulong)buf->Length);

                return 1;
            }
        }

        private static long Skip(ulong bytes, IntPtr userData)
        {
            unsafe
            {
                var buf = (Buffer*)userData;
                if (buf == null || buf->Data == IntPtr.Zero || buf->Length == 0)
                    return -1;

                buf->Position = (int)Math.Min((ulong)buf->Position + bytes, (ulong)buf->Length);

                return (long)bytes;
            }
        }

        private static ulong Write(IntPtr buffer, ulong bytes, IntPtr userData)
        {
            unsafe
            {
                var buf = (Buffer*)userData;
                if (buf == null || buf->Data == IntPtr.Zero || buf->Length == 0)
                    return unchecked((ulong)-1);

                if (buf->Position >= buf->Length)
                    return unchecked((ulong)-1);

                var bufLength = (ulong)(buf->Length - buf->Position);
                var writeLength = bytes < bufLength ? bytes : bufLength;

                System.Buffer.MemoryCopy((void*)buffer, (void*)IntPtr.Add(buf->Data, buf->Position), writeLength, writeLength);
                buf->Position += (int)writeLength;

                return (ulong)writeLength;
            }
        }

        #endregion

        #region Helpers

        public bool SetupEncoderParameters(CompressionParameters cparameters)
        {
            if (cparameters == null) { throw new ArgumentNullException(); }

            _CompressionParameters?.Dispose();

            _CompressionParameters = cparameters;
            return OpenJpeg.SetupEncoder(_Codec, _CompressionParameters, _Image);
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
