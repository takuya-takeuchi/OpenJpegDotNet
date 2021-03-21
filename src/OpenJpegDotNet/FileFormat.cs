namespace OpenJpegDotNet
{

    /// <summary>
    /// Specifies the supported codec.
    /// </summary>
    public enum FileFormat
    {

        /// <summary>
        /// Specifies that the place-holder. 
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// Specifies that the JPEG 2000 codestream.
        /// </summary>
        J2kCompressedFormat = 0,

        /// <summary>
        /// Specifies that the JP2 file format.
        /// </summary>
        Jp2CompressedFormat = 1,

        /// <summary>
        /// Specifies that the JPT-stream (JPEG 2000, JPIP).
        /// </summary>
        JptCompressedFormat = 2,

        /// <summary>
        /// Specifies that the Pixelmator file format.
        /// </summary>
        PxmDecompressedFormat = 10,

        /// <summary>
        /// Specifies that the PGX (JPEG 2000) file format.
        /// </summary>
        PgxDecompressedFormat = 11,

        /// <summary>
        /// Specifies that the Bitmap file format.
        /// </summary>
        BmpDecompressedFormat = 12,

        /// <summary>
        /// Specifies that the YUV file format.
        /// </summary>
        YuvDecompressedFormat = 13,

        /// <summary>
        /// Specifies that the Tagged Image file format.
        /// </summary>
        TifDecompressedFormat = 14,

        /// <summary>
        /// Specifies that the Raw (big endian) Image file format.
        /// </summary>
        RawDecompressedFormat = 15,

        /// <summary>
        /// Specifies that the Truevision Graphics Adapter file format.
        /// </summary>
        TgaDecompressedFormat = 16,

        /// <summary>
        /// Specifies that the Portable Network Graphics file format.
        /// </summary>
        PngDecompressedFormat = 17,

        /// <summary>
        /// Specifies that the Raw (little endian) Image file format.
        /// </summary>
        RawLDecompressedFormat = 18

    }

}