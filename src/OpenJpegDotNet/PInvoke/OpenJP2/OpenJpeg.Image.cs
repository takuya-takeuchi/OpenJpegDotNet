using System;
using System.Runtime.InteropServices;
using uint8_t = System.Byte;
using uint16_t = System.UInt16;
using uint32_t = System.UInt32;
using int64_t = System.Int64;
using int8_t = System.SByte;
using int16_t = System.Int16;
using int32_t = System.Int32;
using size_t = System.Int64;

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
        public static extern void openjpeg_openjp2_opj_image_t_set_x0(IntPtr image, uint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_t_get_y0(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_image_t_set_y0(IntPtr image, uint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_t_get_x1(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_image_t_set_x1(IntPtr image, uint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_t_get_y1(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_image_t_set_y1(IntPtr image, uint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_t_get_numcomps(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_image_t_set_numcomps(IntPtr image, uint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ColorSpace openjpeg_openjp2_opj_image_t_get_color_space(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_image_t_set_color_space(IntPtr image, ColorSpace value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_image_t_get_comps(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_image_t_get_comps_by_index(IntPtr image, uint32_t index);

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

        #region opj_image_comp_t

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_image_comp_t_get_data(IntPtr comp);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint16_t openjpeg_openjp2_opj_image_comp_t_get_alpha(IntPtr comp);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint32_t openjpeg_openjp2_opj_image_comp_t_get_bpp(IntPtr comp);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint32_t openjpeg_openjp2_opj_image_comp_t_get_dx(IntPtr comp);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint32_t openjpeg_openjp2_opj_image_comp_t_get_dy(IntPtr comp);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint32_t openjpeg_openjp2_opj_image_comp_t_get_factor(IntPtr comp);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint32_t openjpeg_openjp2_opj_image_comp_t_get_h(IntPtr comp);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint32_t openjpeg_openjp2_opj_image_comp_t_get_prec(IntPtr comp);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint32_t openjpeg_openjp2_opj_image_comp_t_get_resno_decoded(IntPtr comp);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint32_t openjpeg_openjp2_opj_image_comp_t_get_sgnd(IntPtr comp);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint32_t openjpeg_openjp2_opj_image_comp_t_get_w(IntPtr comp);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint32_t openjpeg_openjp2_opj_image_comp_t_get_x0(IntPtr comp);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint32_t openjpeg_openjp2_opj_image_comp_t_get_y0(IntPtr comp);

        #endregion

        #endregion

        #region Functions

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_image_create(uint32_t numcmpts, IntPtr[] cmptparms, uint32_t cmptparms_len, ColorSpace clrsp);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_image_t_destroy(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_image_tile_create(uint numcmpts, IntPtr[] cmptparms, uint cmptparms_len, ColorSpace clrspc);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_image_data_alloc(size_t size);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_image_data_free(IntPtr ptr);

        #endregion

        #region Not Native Functions

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_image_cmptparm_t_new();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_image_cmptparm_t_delete(IntPtr parameters);

        #endregion

    }

}