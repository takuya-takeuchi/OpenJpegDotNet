using System.Text;
using OpenJpegDotNet;

namespace OpenJpegDotNet
{

    /// <summary>
    /// Provides the methods of OpenJpeg.
    /// </summary>
    public static partial class OpenJpeg
    {

        #region Methods

        public static string GetNativeVersion()
        {
            return StringHelper.FromStdString(NativeMethods.get_version(), true);
        }

        public static string GetVersion()
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