using System.Runtime.InteropServices;
using System.Text;

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
            var ptr = NativeMethods.openjpeg_openjp2_opj_version();
            var str = NativeMethods.string_c_str(ptr);
            return Marshal.PtrToStringAnsi(str);
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