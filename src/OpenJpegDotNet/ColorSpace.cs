namespace OpenJpegDotNet
{

    /// <summary>
    /// Specifies the Supported image color spaces.
    /// </summary>
    public enum ColorSpace
    {

        /// <summary>
        /// Specifies that not supported by the library. 
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// Specifies that not specified in the codestream.
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// Specifies that the sRGB.
        /// </summary>
        Srgb = 1,

        /// <summary>
        /// Specifies that the Grayscale.
        /// </summary>
        Gray = 2,

        /// <summary>
        /// Specifies that the sYCC.
        /// </summary>
        Sycc = 3,

        /// <summary>
        /// Specifies that the e-YCC.
        /// </summary>
        Eycc = 4,

        /// <summary>
        /// Specifies that the CMYK.
        /// </summary>
        Cmyk = 5

    }

}