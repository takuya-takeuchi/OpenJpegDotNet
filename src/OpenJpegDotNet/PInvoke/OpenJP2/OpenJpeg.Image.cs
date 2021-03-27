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

        #region Structs

        #region opj_image_t

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_t_get_x0(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_t_get_y0(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_t_get_x1(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_t_get_y1(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_t_get_numcomps(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ColorSpace openjpeg_openjp2_opj_image_t_get_color_space(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_image_t_get_comps(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_image_t_get_icc_profile_buf(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_t_get_icc_profile_len(IntPtr image);

        #endregion

        #region opj_image_cmptparm_t

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_cmptparm_t_get_bpp(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_image_cmptparm_t_set_bpp(IntPtr parameters, uint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_cmptparm_t_get_dx(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_image_cmptparm_t_set_dx(IntPtr parameters, uint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_cmptparm_t_get_dy(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_image_cmptparm_t_set_dy(IntPtr parameters, uint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_cmptparm_t_get_h(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_image_cmptparm_t_set_h(IntPtr parameters, uint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_cmptparm_t_get_prec(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_image_cmptparm_t_set_prec(IntPtr parameters, uint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_cmptparm_t_get_sgnd(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_image_cmptparm_t_set_sgnd(IntPtr parameters, uint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_cmptparm_t_get_w(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_image_cmptparm_t_set_w(IntPtr parameters, uint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_cmptparm_t_get_x0(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_image_cmptparm_t_set_x0(IntPtr parameters, uint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_cmptparm_t_get_y0(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_image_cmptparm_t_set_y0(IntPtr parameters, uint value);


        #endregion

        #endregion

        #region Functions

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_image_t_destroy(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_image_tile_create(uint numcmpts, IntPtr cmptparms, ColorSpace clrspc);

        #endregion

        #region Not Native Functions

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_image_cmptparm_t_new();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_image_cmptparm_t_delete(IntPtr parameters);

        #endregion

    }

}