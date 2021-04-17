using System;
using System.Runtime.InteropServices;
using uint8_t = System.Byte;
using uint16_t = System.UInt16;
using uint32_t = System.UInt32;
using uint64_t = System.UInt64;
using int64_t = System.Int64;
using int8_t = System.SByte;
using int16_t = System.Int16;
using int32_t = System.Int32;

// ReSharper disable once CheckNamespace
namespace OpenJpegDotNet
{

    internal sealed partial class NativeMethods
    {

        #region Functions

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_set_info_handler(IntPtr p_codec,
                                                                          IntPtr p_function,
                                                                          IntPtr p_user_data);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_set_warning_handler(IntPtr p_codec,
                                                                             IntPtr p_function,
                                                                             IntPtr p_user_data);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_set_error_handler(IntPtr p_codec,
                                                                         IntPtr p_function,
                                                                         IntPtr p_user_data);

        #endregion

    }

}