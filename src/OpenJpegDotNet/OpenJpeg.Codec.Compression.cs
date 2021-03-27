using System;

namespace OpenJpegDotNet
{

    /// <summary>
    /// Provides the methods of OpenJpeg.
    /// </summary>
    public static partial class OpenJpeg
    {

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

        /// <summary>
        /// Set encoding parameters to default values.
        /// </summary>
        /// <param name="parameters">The <see cref="CompressionParameters"/> to compress image.</param>
        /// <exception cref="ArgumentNullException"><paramref name="parameters"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="parameters"/>.</exception>
        public static void SetDefaultEncoderParameters(CompressionParameters parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            parameters.ThrowIfDisposed();

            NativeMethods.openjpeg_openjp2_opj_set_default_encoder_parameters(parameters.NativePtr);
        }

        /// <summary>
        /// Setup the decoder with decompression parameters provided by the user and with the message handler provided by the user.
        /// </summary>
        /// <param name="codec">The <see cref="Codec"/> to compress image.</param>
        /// <param name="parameters">The <see cref="CompressionParameters"/> to ccompress image.</param>
        /// <param name="image">Input filled image.</param>
        /// <returns><code>true</code> if the decoder is correctly set; otherwise, <code>false</code>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="codec"/>, <paramref name="parameters"/> or <paramref name="image"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="codec"/>, <paramref name="parameters"/> or <paramref name="image"/>.</exception>
        public static bool SetupEncoder(Codec codec, CompressionParameters parameters, Image image)
        {
            if (codec == null)
                throw new ArgumentNullException(nameof(codec));
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            codec.ThrowIfDisposed();
            parameters.ThrowIfDisposed();
            image.ThrowIfDisposed();

            return NativeMethods.openjpeg_openjp2_opj_setup_encoder(codec.NativePtr, parameters.NativePtr, image.NativePtr);
        }

    }

}