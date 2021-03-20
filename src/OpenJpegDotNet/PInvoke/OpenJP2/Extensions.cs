using System;
using System.Runtime.InteropServices;
using uint8_t = System.Byte;
using uint16_t = System.UInt16;
using uint32_t = System.UInt32;
using int64_t = System.Int64;
using int8_t = System.SByte;
using int16_t = System.Int16;
using int32_t = System.Int32;

// ReSharper disable once CheckNamespace
namespace OpenJpegDotNet
{

    internal sealed partial class NativeMethods
    {

        #region Version

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ErrorType openjpeg_openjp2_convertbmp_imagetobmp(IntPtr image,
                                                                              bool big_endian,
                                                                              out IntPtr planes,
                                                                              out uint out_w,
                                                                              out uint out_h,
                                                                              out uint out_c);

        #endregion

    }

}