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

        public static Codec CreateCompress(CodecFormat format)
        {
            var ptr = NativeMethods.openjpeg_openjp2_opj_create_compress(format);
            return new Codec(ptr);
        }

        public static Codec CreateDecompress(CodecFormat format)
        {
            var ptr = NativeMethods.openjpeg_openjp2_opj_create_decompress(format);
            return new Codec(ptr);
        }

        public static string GetNativeVersion()
        {
            return StringHelper.FromStdString(NativeMethods.get_version(), true);
        }

        public static string GetVersion()
        {
            return StringHelper.FromStdString(NativeMethods.openjpeg_openjp2_opj_version(), true);
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