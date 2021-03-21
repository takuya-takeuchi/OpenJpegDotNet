using System;
using System.IO;
using System.Text;

namespace OpenJpegDotNet
{

    /// <summary>
    /// Provides the methods of OpenJpeg.
    /// </summary>
    public static class OpenJpeg
    {

        #region Methods

        #region Version

        /// <summary>
        /// Get the string representation of the OpenJpeg version.
        /// </summary>
        /// <returns>The string representation of the OpenJpeg version.</returns>
        public static string GetVersion()
        {
            return StringHelper.FromStdString(NativeMethods.openjpeg_openjp2_opj_version(), true);
        }

        #endregion

        #region Image

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
            if (!File.Exists(filepath))
                throw new FileNotFoundException($"The specified {nameof(filepath)} does not exist.", filepath);

            var str = Encoding.GetBytes(filepath);
            var ret = NativeMethods.openjpeg_openjp2_opj_stream_create_default_file_stream(str, (uint)str.Length, isReadStream);
            return new Stream(ret);
        }

        #endregion

        #region Codec

        #region Decompress

        /// <summary>
        /// Creates a J2K/JP2 decompression structure.
        /// </summary>
        /// <param name="format">The codec format to create.</param>
        /// <returns>The <see cref="Codec"/>.</returns>
        public static Codec CreateDecompress(CodecFormat format)
        {
            var ptr = NativeMethods.openjpeg_openjp2_opj_create_decompress(format);
            return new Codec(ptr);
        }

        /// <summary>
        /// Decode an image from a JPEG 2000 codestream.
        /// </summary>
        /// <param name="codec">the Jpeg 2000 codec to read.</param>
        /// <param name="stream">The Jpeg 2000 stream.</param>
        /// <param name="image">The image that receives decoded datum.</param>
        /// <returns><code>true</code> if success; otherwise, <code>false</code>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="codec"/>, <paramref name="stream"/> or <paramref name="image"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="codec"/>, <paramref name="stream"/> or <paramref name="image"/>.</exception>
        public static bool Decode(Codec codec, Stream stream, Image image)
        {
            if (codec == null)
                throw new ArgumentNullException(nameof(codec));
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            codec.ThrowIfDisposed();
            stream.ThrowIfDisposed();
            image.ThrowIfDisposed();

            return NativeMethods.openjpeg_openjp2_opj_decode(codec.NativePtr, stream.NativePtr, image.NativePtr);
        }

        /// <summary>
        /// Read after the codestream if necessary.
        /// </summary>
        /// <param name="codec">the Jpeg 2000 codec to read.</param>
        /// <param name="stream">The Jpeg 2000 stream.</param>
        /// <returns><code>true</code> if success; otherwise, <code>false</code>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="codec"/> or <paramref name="stream"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="codec"/> or <paramref name="stream"/>.</exception>
        public static bool EndDecompress(Codec codec, Stream stream)
        {
            if (codec == null)
                throw new ArgumentNullException(nameof(codec));
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            codec.ThrowIfDisposed();
            stream.ThrowIfDisposed();

            return NativeMethods.openjpeg_openjp2_opj_end_decompress(codec.NativePtr, stream.NativePtr);
        }

        /// <summary>
        /// Decodes an image header.
        /// </summary>
        /// <param name="stream">The Jpeg 2000 stream.</param>
        /// <param name="codec">the Jpeg 2000 codec to read.</param>
        /// <param name="image">When this method returns, contains the <see cref="Image"/> read from stream. This parameter is passed uninitialized.</param>
        /// <returns><code>true</code> if the main header of the codestream and the JP2 header is correctly read; otherwise, <code>false</code>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> or <paramref name="codec"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="stream"/> or <paramref name="codec"/>.</exception>
        public static bool ReadHeader(Stream stream, Codec codec, out Image image)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            if (codec == null)
                throw new ArgumentNullException(nameof(codec));

            stream.ThrowIfDisposed();
            codec.ThrowIfDisposed();

            var ret = NativeMethods.openjpeg_openjp2_opj_read_header(stream.NativePtr, codec.NativePtr, out var pImage);
            image = ret ? new Image(pImage) : null;
            return ret;
        }

        /// <summary>
        /// Sets the given area to be decoded.
        /// </summary>
        /// <param name="codec">The Jpeg 2000 codec.</param>
        /// <param name="image">The decoded <see cref="Image"/> previously set by <see cref="ReadHeader"/>.</param>
        /// <param name="left">The left position of the rectangle to decode in image.</param>
        /// <param name="top">The top position of the rectangle to decode in image.</param>
        /// <param name="right">The right position of the rectangle to decode in image.</param>
        /// <param name="bottom">The bottom position of the rectangle to decode in image.</param>
        /// <returns><code>true</code> if the area is correctly set; otherwise, <code>false</code>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="codec"/> or <paramref name="image"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="codec"/> or <paramref name="image"/>.</exception>
        public static bool SetDecodeArea(Codec codec, Image image, uint left, uint top, uint right, uint bottom)
        {
            if (codec == null)
                throw new ArgumentNullException(nameof(codec));
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            codec.ThrowIfDisposed();
            image.ThrowIfDisposed();

            return NativeMethods.openjpeg_openjp2_opj_set_decode_area(codec.NativePtr,
                                                                      image.NativePtr,
                                                                      left,
                                                                      top,
                                                                      right,
                                                                      bottom);
        }

        /// <summary>
        /// Set decoding parameters to default values.
        /// </summary>
        /// <param name="parameters">The <see cref="DecompressionParameters"/> to decompress image.</param>
        /// <exception cref="ArgumentNullException"><paramref name="parameters"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="parameters"/>.</exception>
        public static void SetDefaultDecoderParameters(DecompressionParameters parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            parameters.ThrowIfDisposed();

            NativeMethods.openjpeg_openjp2_opj_set_default_decoder_parameters(parameters.NativePtr);
        }

        /// <summary>
        /// Setup the decoder with decompression parameters provided by the user and with the message handler provided by the user.
        /// </summary>
        /// <param name="codec">The <see cref="Codec"/> to decompress image.</param>
        /// <param name="parameters">The <see cref="DecompressionParameters"/> to decompress image.</param>
        /// <returns><code>true</code> if the decoder is correctly set; otherwise, <code>false</code>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="codec"/> or <paramref name="parameters"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="codec"/> or <paramref name="parameters"/>.</exception>
        public static bool SetupDecoder(Codec codec, DecompressionParameters parameters)
        {
            if (codec == null)
                throw new ArgumentNullException(nameof(codec));
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            codec.ThrowIfDisposed();
            parameters.ThrowIfDisposed();

            return NativeMethods.openjpeg_openjp2_opj_setup_decoder(codec.NativePtr, parameters.NativePtr);
        }

        #endregion

        #region Compress

        /// <summary>
        /// Creates a J2K/JP2 compression structure.
        /// </summary>
        /// <param name="format">The codec format to create.</param>
        /// <returns>The <see cref="Codec"/>.</returns>
        public static Codec CreateCompress(CodecFormat format)
        {
            var ptr = NativeMethods.openjpeg_openjp2_opj_create_compress(format);
            return new Codec(ptr);
        }

        #endregion

        #endregion

        /// <summary>
        /// Get the string representation of the version of wrapper library of OpenJpeg.
        /// </summary>
        /// <returns>The string representation of the version of wrapper library of OpenJpeg.</returns>
        public static string GetNativeVersion()
        {
            return StringHelper.FromStdString(NativeMethods.get_version(), true);
        }

        #endregion

        #region Properties

        private static Encoding _Encoding = Encoding.UTF8;

        public static Encoding Encoding
        {
            get => _Encoding;
            set => _Encoding = value ?? Encoding.UTF8;
        }

        #endregion

    }

}