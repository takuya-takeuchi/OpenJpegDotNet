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

        public static string GetVersion()
        {
            return StringHelper.FromStdString(NativeMethods.openjpeg_openjp2_opj_version(), true);
        }

        #endregion

        #region Image

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

        public static Codec CreateDecompress(CodecFormat format)
        {
            var ptr = NativeMethods.openjpeg_openjp2_opj_create_decompress(format);
            return new Codec(ptr);
        }

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

        public static void SetDefaultDecoderParameters(DecompressionParameters parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            parameters.ThrowIfDisposed();

            NativeMethods.openjpeg_openjp2_opj_set_default_decoder_parameters(parameters.NativePtr);
        }

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

        public static Codec CreateCompress(CodecFormat format)
        {
            var ptr = NativeMethods.openjpeg_openjp2_opj_create_compress(format);
            return new Codec(ptr);
        }

        #endregion

        #endregion

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