using System;

namespace OpenJpegDotNet
{
    
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
        /// Start to compress the current image.
        /// </summary>
        /// <param name="codec">the Jpeg 2000 codec to compress.</param>
        /// <param name="image">The image that receives encoded datum.</param>
        /// <param name="stream">The Jpeg 2000 stream.</param>
        /// <returns><code>true</code> if the start to compress is correctly set; otherwise, <code>false</code>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="codec"/>, <paramref name="image"/> or <paramref name="stream"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="codec"/>, <paramref name="image"/> or <paramref name="stream"/> is disposed.</exception>
        public static bool StartCompress(Codec codec, Image image, Stream stream)
        {
            if (codec == null)
                throw new ArgumentNullException(nameof(codec));
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            codec.ThrowIfDisposed();
            image.ThrowIfDisposed();
            stream.ThrowIfDisposed();

            return NativeMethods.openjpeg_openjp2_opj_start_compress(codec.NativePtr, image.NativePtr, stream.NativePtr);
        }

        /// <summary>
        /// End to compress the current image.
        /// </summary>
        /// <param name="codec">the Jpeg 2000 codec to compress.</param>
        /// <param name="stream">The Jpeg 2000 stream.</param>
        /// <returns><code>true</code> if the end to compress is correctly set; otherwise, <code>false</code>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="codec"/> or <paramref name="stream"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="codec"/> or <paramref name="stream"/> is disposed.</exception>
        public static bool EndCompress(Codec codec, Stream stream)
        {
            if (codec == null)
                throw new ArgumentNullException(nameof(codec));
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            codec.ThrowIfDisposed();
            stream.ThrowIfDisposed();

            return NativeMethods.openjpeg_openjp2_opj_end_compress(codec.NativePtr, stream.NativePtr);
        }

        /// <summary>
        /// Encode an image into a JPEG-2000 codestream.
        /// </summary>
        /// <param name="codec">the Jpeg 2000 codec to compress.</param>
        /// <param name="stream">The Jpeg 2000 stream.</param>
        /// <returns><code>true</code> if the end to compress is correctly set; otherwise, <code>false</code>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="codec"/> or <paramref name="stream"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="codec"/> or <paramref name="stream"/> is disposed.</exception>
        public static bool Encode(Codec codec, Stream stream)
        {
            if (codec == null)
                throw new ArgumentNullException(nameof(codec));
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            codec.ThrowIfDisposed();
            stream.ThrowIfDisposed();

            return NativeMethods.openjpeg_openjp2_opj_encode(codec.NativePtr, stream.NativePtr);
        }

        /// <summary>
        /// Set encoding parameters to default values.
        /// </summary>
        /// <param name="parameters">The <see cref="CompressionParameters"/> to compress image.</param>
        /// <exception cref="ArgumentNullException"><paramref name="parameters"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="parameters"/> is disposed.</exception>
        public static void SetDefaultEncoderParameters(CompressionParameters parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            parameters.ThrowIfDisposed();

            NativeMethods.openjpeg_openjp2_opj_set_default_encoder_parameters(parameters.NativePtr);
        }

        /// <summary>
        /// Setup the encoder with compression parameters provided by the user and with the message handler provided by the user.
        /// </summary>
        /// <param name="codec">The <see cref="Codec"/> to compress image.</param>
        /// <param name="parameters">The <see cref="CompressionParameters"/> for image compression.</param>
        /// <param name="image">Input filled image.</param>
        /// <returns><code>true</code> if the decoder is correctly set; otherwise, <code>false</code>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="codec"/>, <paramref name="parameters"/> or <paramref name="image"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="codec"/>, <paramref name="parameters"/> or <paramref name="image"/> is disposed.</exception>
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
