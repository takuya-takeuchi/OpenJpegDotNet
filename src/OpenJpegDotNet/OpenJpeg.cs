using System;
using System.IO;
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

        #region Version

        public static string GetVersion()
        {
            return StringHelper.FromStdString(NativeMethods.openjpeg_openjp2_opj_version(), true);
        }

        #endregion

        #region Image

        public static Codec StreamCreateDefaultFileStream(string filepath, bool isReadStream)
        {
            if (filepath == null)
                throw new ArgumentNullException(nameof(filepath));
            if (!File.Exists(filepath))
                throw new FileNotFoundException($"The specified {nameof(filepath)} does not exist.", filepath);

            var str = Encoding.GetBytes(filepath);
            var ret = NativeMethods.openjpeg_openjp2_opj_stream_create_default_file_stream(str, (uint)str.Length, isReadStream);
            return new Codec(ret);
        }

        #endregion

        #region Codec

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

        #endregion

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