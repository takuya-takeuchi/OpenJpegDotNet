using System;
using System.IO;
using System.Text;

namespace OpenJpegDotNet
{

    /// <summary>
    /// Provides the methods of OpenJpeg.
    /// </summary>
    public static partial class OpenJpeg
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