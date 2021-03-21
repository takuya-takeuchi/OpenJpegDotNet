namespace OpenJpegDotNet
{

    /// <summary>
    /// Specifies the supported codec.
    /// </summary>
    public enum CodecFormat
    {

        /// <summary>
        /// Specifies that the place-holder. 
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// Specifies that the JPEG 2000 codestream.
        /// </summary>
        J2k = 0,

        /// <summary>
        /// Specifies that the JPT-stream (JPEG 2000, JPIP).
        /// </summary>
        Jpt = 1,

        /// <summary>
        /// Specifies that the JP2 file format.
        /// </summary>
        Jp2 = 2,

        /// <summary>
        /// Specifies that the JPP-stream (JPEG 2000, JPIP).
        /// </summary>
        Jpp = 3,

        /// <summary>
        /// Specifies that the JPX file format(JPEG 2000 Part-2).
        /// </summary>
        Jpx = 4,

    }

}