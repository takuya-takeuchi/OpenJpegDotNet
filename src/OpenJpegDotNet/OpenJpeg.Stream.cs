using System;
using System.IO;

namespace OpenJpegDotNet
{

    /// <summary>
    /// Provides the methods of OpenJpeg.
    /// </summary>
    public static partial class OpenJpeg
    {

        /// <summary>
        /// Creates an abstract stream.
        /// </summary>
        /// <param name="isReadStream">The value whether the stream is a read stream.</param>
        /// <returns>The <see cref="Stream"/>.</returns>
        public static Stream StreamDefaultCreate(bool isReadStream)
        {
            var ret = NativeMethods.openjpeg_openjp2_opj_stream_default_create(isReadStream);
            return new Stream(ret);
        }

        /// <summary>
        /// Creates an abstract stream with a specific buffer size.
        /// </summary>
        /// <param name="bufferSize">The size of the chunk used to stream.</param>
        /// <param name="isReadStream">The value whether the stream is a read stream.</param>
        /// <returns>The <see cref="Stream"/>.</returns>
        public static Stream StreamCreate(ulong bufferSize, bool isReadStream)
        {
            var ret = NativeMethods.openjpeg_openjp2_opj_stream_create(bufferSize, isReadStream);
            return new Stream(ret);
        }

        /// <summary>
        /// Sets the given callback to be used as a read function.
        /// </summary>
        /// <param name="stream">The stream to modify.</param>
        /// <param name="callback">The callback to free user data when <see cref="Stream"/> reads data stream.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> or <paramref name="callback"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="stream"/> is disposed.</exception>
        public static void StreamSetReadFunction(Stream stream, DelegateHandler<StreamRead> callback = null)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            stream.ThrowIfDisposed();

            NativeMethods.openjpeg_openjp2_opj_stream_set_read_function(stream.NativePtr, callback.Handle);
        }

        /// <summary>
        /// Sets the given callback to be used as a write function.
        /// </summary>
        /// <param name="stream">The stream to modify.</param>
        /// <param name="callback">The callback to free user data when <see cref="Stream"/> writes data stream.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> or <paramref name="callback"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="stream"/> is disposed.</exception>
        public static void StreamSetWriteFunction(Stream stream, DelegateHandler<StreamWrite> callback = null)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            stream.ThrowIfDisposed();

            NativeMethods.openjpeg_openjp2_opj_stream_set_write_function(stream.NativePtr, callback.Handle);
        }

        /// <summary>
        /// Sets the given callback to be used as a skip function.
        /// </summary>
        /// <param name="stream">The stream to modify.</param>
        /// <param name="callback">The callback to free user data when <see cref="Stream"/> skips data stream.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> or <paramref name="callback"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="stream"/> is disposed.</exception>
        public static void StreamSetSkipFunction(Stream stream, DelegateHandler<StreamSkip> callback = null)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            stream.ThrowIfDisposed();

            NativeMethods.openjpeg_openjp2_opj_stream_set_skip_function(stream.NativePtr, callback.Handle);
        }

        /// <summary>
        /// Sets the given callback to be used as a seek function, the stream is then seekable,
        /// </summary>
        /// <param name="stream">The stream to modify.</param>
        /// <param name="callback">The callback to free user data when <see cref="Stream"/> seeks data stream.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> or <paramref name="callback"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="stream"/> is disposed.</exception>
        public static void StreamSetSeekFunction(Stream stream, DelegateHandler<StreamSeek> callback = null)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            stream.ThrowIfDisposed();

            NativeMethods.openjpeg_openjp2_opj_stream_set_seek_function(stream.NativePtr, callback.Handle);
        }

        /// <summary>
        /// Sets the given data to be used as a user data for the stream.
        /// </summary>
        /// <param name="stream">The stream to modify.</param>
        /// <param name="data">The data to set.</param>
        /// <param name="callback">The callback to free user data when <see cref="Stream"/> is disposed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> or <paramref name="data"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="stream"/> is disposed.</exception>
        public static void StreamSetUserData(Stream stream, IntPtr data, DelegateHandler<StreamFreeUserData> callback = null)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            stream.ThrowIfDisposed();

            var function = callback == null ? IntPtr.Zero : callback.Handle;
            NativeMethods.openjpeg_openjp2_opj_stream_set_user_data(stream.NativePtr, data, function);
        }

        /// <summary>
        /// Sets the length of the user data for the stream.
        /// </summary>
        /// <param name="stream">The stream to modify.</param>
        /// <param name="dataLength">The length of the user_data.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="stream"/> is disposed.</exception>
        public static void StreamSetUserDataLength(Stream stream, int dataLength)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            stream.ThrowIfDisposed();

            NativeMethods.openjpeg_openjp2_opj_stream_set_user_data_length(stream.NativePtr, (ulong)dataLength);
        }

        /// <summary>
        /// Create a stream from a file identified with its filename with default parameters.
        /// </summary>
        /// <param name="filepath">The filename of the file to input to stream.</param>
        /// <param name="isReadStream">The value whether the stream is a read stream.</param>
        /// <returns>The <see cref="Stream"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="filepath"/> is null.</exception>
        /// <exception cref="FileNotFoundException">The specified path does not exist.</exception>
        public static Stream StreamCreateDefaultFileStream(string filepath, bool isReadStream)
        {
            if (filepath == null)
                throw new ArgumentNullException(nameof(filepath));
            if (isReadStream && !File.Exists(filepath))
                throw new FileNotFoundException($"The specified {nameof(filepath)} does not exist.", filepath);

            var str = Encoding.GetBytes(filepath);
            var ret = NativeMethods.openjpeg_openjp2_opj_stream_create_default_file_stream(str, (uint)str.Length, isReadStream);
            return new Stream(ret);
        }

        /// <summary>
        /// Create a stream from a file identified with its filename with a specific buffer size.
        /// </summary>
        /// <param name="filepath">The filename of the file to input to stream.</param>
        /// <param name="bufferSize">The size of the chunk used to stream.</param>
        /// <param name="isReadStream">The value whether the stream is a read stream.</param>
        /// <returns>The <see cref="Stream"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="filepath"/> is null.</exception>
        /// <exception cref="FileNotFoundException">The specified path does not exist.</exception>
        public static Stream StreamCreateFileStream(string filepath, ulong bufferSize, bool isReadStream)
        {
            if (filepath == null)
                throw new ArgumentNullException(nameof(filepath));
            if (isReadStream && !File.Exists(filepath))
                throw new FileNotFoundException($"The specified {nameof(filepath)} does not exist.", filepath);

            var str = Encoding.GetBytes(filepath);
            var ret = NativeMethods.openjpeg_openjp2_opj_stream_create_file_stream(str, (uint)str.Length, bufferSize, isReadStream);
            return new Stream(ret);
        }

    }

}