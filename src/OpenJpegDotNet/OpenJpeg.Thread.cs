namespace OpenJpegDotNet
{

    /// <summary>
    /// Provides the methods of OpenJpeg.
    /// </summary>
    public static partial class OpenJpeg
    {

        /// <summary>
        /// Returns if the library is built with thread support.
        /// </summary>
        /// <returns><code>true</code> if mutex, condition, thread, thread pool are available; otherwise, <code>false</code>.</returns>
        public static bool HasThreadSupport()
        {
            return NativeMethods.openjpeg_openjp2_opj_has_thread_support();
        }

        /// <summary>
        /// Return the number of virtual CPUs.
        /// </summary>
        /// <returns>The number of virtual CPUs.</returns>
        public static int GetNumCpus()
        {
            return NativeMethods.openjpeg_openjp2_opj_get_num_cpus();
        }

    }

}