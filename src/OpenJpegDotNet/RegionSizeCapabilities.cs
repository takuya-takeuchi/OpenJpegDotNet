namespace OpenJpegDotNet
{

    /// <summary>
    /// Specifies the region size capabilities.
    /// </summary>
    public enum RegionSizeCapabilities
    {

        /// <summary>
        /// Specifies that Standard JPEG 2000 profile. 
        /// </summary>
        Off = 0,

        /// <summary>
        /// Specifies that Profile name for a 2K image.
        /// </summary>
        Cinema2K = 3,

        /// <summary>
        /// Specifies that Profile name for a 4K image.
        /// </summary>
        Cinema4K = 4,

        /// <summary>
        /// Specifies that multiple component transformation.
        /// </summary>
        Mct = 0x8100

    }

}