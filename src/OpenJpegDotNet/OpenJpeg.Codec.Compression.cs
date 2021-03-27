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

    }

}