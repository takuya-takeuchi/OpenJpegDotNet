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

        #region Functions

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool openjpeg_openjp2_opj_set_MCT(IntPtr parameters,
                                                               float[] pEncodingMatrix,
                                                               int[] p_dc_shift,
                                                               uint pNbComp);

        #endregion

    }

}