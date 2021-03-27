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

        #region opj_cparameters_t

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern unsafe void openjpeg_openjp2_opj_cparameters_t_get_jpwl_hprot_TPH(IntPtr parameters, out int* value, out uint len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ErrorType openjpeg_openjp2_opj_cparameters_t_set_jpwl_hprot_TPH(IntPtr parameters, int[] value, uint len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern unsafe void openjpeg_openjp2_opj_cparameters_t_get_jpwl_hprot_TPH_tileno(IntPtr parameters, out int* value, out uint len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ErrorType openjpeg_openjp2_opj_cparameters_t_set_jpwl_hprot_TPH_tileno(IntPtr parameters, int[] value, uint len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern unsafe void openjpeg_openjp2_opj_cparameters_t_get_jpwl_pprot(IntPtr parameters, out int* value, out uint len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ErrorType openjpeg_openjp2_opj_cparameters_t_set_jpwl_pprot(IntPtr parameters, int[] value, uint len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern unsafe void openjpeg_openjp2_opj_cparameters_t_get_jpwl_pprot_packno(IntPtr parameters, out int* value, out uint len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ErrorType openjpeg_openjp2_opj_cparameters_t_set_jpwl_pprot_packno(IntPtr parameters, int[] value, uint len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern unsafe void openjpeg_openjp2_opj_cparameters_t_get_jpwl_pprot_tileno(IntPtr parameters, out int* value, out uint len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ErrorType openjpeg_openjp2_opj_cparameters_t_set_jpwl_pprot_tileno(IntPtr parameters, int[] value, uint len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern unsafe void openjpeg_openjp2_opj_cparameters_t_get_jpwl_sens_TPH(IntPtr parameters, out int* value, out uint len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ErrorType openjpeg_openjp2_opj_cparameters_t_set_jpwl_sens_TPH(IntPtr parameters, int[] value, uint len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern unsafe void openjpeg_openjp2_opj_cparameters_t_get_jpwl_sens_TPH_tileno(IntPtr parameters, out int* value, out uint len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ErrorType openjpeg_openjp2_opj_cparameters_t_set_jpwl_sens_TPH_tileno(IntPtr parameters, int[] value, uint len);

        //[DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        //public static extern unsafe void openjpeg_openjp2_opj_cparameters_t_get_POC(IntPtr parameters, out opj_poc_t* value, out uint len);

        //[DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        //public static extern ErrorType openjpeg_openjp2_opj_cparameters_t_set_POC(IntPtr parameters, opj_poc_t[] value, uint len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern unsafe void openjpeg_openjp2_opj_cparameters_t_get_prch_init(IntPtr parameters, out int* value, out uint len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ErrorType openjpeg_openjp2_opj_cparameters_t_set_prch_init(IntPtr parameters, int[] value, uint len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern unsafe void openjpeg_openjp2_opj_cparameters_t_get_prcw_init(IntPtr parameters, out int* value, out uint len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ErrorType openjpeg_openjp2_opj_cparameters_t_set_prcw_init(IntPtr parameters, int[] value, uint len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern unsafe void openjpeg_openjp2_opj_cparameters_t_get_tcp_distoratio(IntPtr parameters, out float* value, out uint len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ErrorType openjpeg_openjp2_opj_cparameters_t_set_tcp_distoratio(IntPtr parameters, float[] value, uint len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern unsafe void openjpeg_openjp2_opj_cparameters_t_get_tcp_rates(IntPtr parameters, out float* value, out uint len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ErrorType openjpeg_openjp2_opj_cparameters_t_set_tcp_rates(IntPtr parameters, float[] value, uint len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern CinemaMode openjpeg_openjp2_opj_cparameters_t_get_cp_cinema(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_cp_cinema(IntPtr parameters, CinemaMode value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern RegionSizeCapabilities openjpeg_openjp2_opj_cparameters_t_get_cp_rsiz(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_cp_rsiz(IntPtr parameters, RegionSizeCapabilities value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_cparameters_t_get_numpocs(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_numpocs(IntPtr parameters, uint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ProgressionOrder openjpeg_openjp2_opj_cparameters_t_get_prog_order(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_prog_order(IntPtr parameters, ProgressionOrder value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ushort openjpeg_openjp2_opj_cparameters_t_get_rsiz(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_rsiz(IntPtr parameters, ushort value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_cblockh_init(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_cblockh_init(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_cblockw_init(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_cblockw_init(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_cod_format(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_cod_format(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_cp_disto_alloc(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_cp_disto_alloc(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_cp_fixed_alloc(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_cp_fixed_alloc(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_cp_fixed_quality(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_cp_fixed_quality(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_cp_tdx(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_cp_tdx(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_cp_tdy(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_cp_tdy(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_cp_tx0(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_cp_tx0(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_cp_ty0(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_cp_ty0(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_csty(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_csty(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_decod_format(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_decod_format(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_image_offset_x0(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_image_offset_x0(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_image_offset_y0(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_image_offset_y0(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_index_on(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_index_on(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_irreversible(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_irreversible(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_jpwl_hprot_MH(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_jpwl_hprot_MH(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_jpwl_sens_addr(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_jpwl_sens_addr(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_jpwl_sens_MH(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_jpwl_sens_MH(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_jpwl_sens_range(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_jpwl_sens_range(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_jpwl_sens_size(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_jpwl_sens_size(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_max_comp_size(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_max_comp_size(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_max_cs_size(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_max_cs_size(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_mode(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_mode(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_numresolution(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_numresolution(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_res_spec(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_res_spec(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_roi_compno(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_roi_compno(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_roi_shift(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_roi_shift(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_subsampling_dx(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_subsampling_dx(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_subsampling_dy(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_subsampling_dy(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_cparameters_t_get_tcp_numlayers(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_tcp_numlayers(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool openjpeg_openjp2_opj_cparameters_t_get_jpip_on(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_jpip_on(IntPtr parameters, bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool openjpeg_openjp2_opj_cparameters_t_get_jpwl_epc_on(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_jpwl_epc_on(IntPtr parameters, bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool openjpeg_openjp2_opj_cparameters_t_get_tile_size_on(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_tile_size_on(IntPtr parameters, bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern sbyte openjpeg_openjp2_opj_cparameters_t_get_tcp_mct(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_tcp_mct(IntPtr parameters, sbyte value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern sbyte openjpeg_openjp2_opj_cparameters_t_get_tp_flag(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_tp_flag(IntPtr parameters, sbyte value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern sbyte openjpeg_openjp2_opj_cparameters_t_get_tp_on(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_set_tp_on(IntPtr parameters, sbyte value);

        #endregion

        #endregion

        #region Functions

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_create_compress(CodecFormat format);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_set_default_encoder_parameters(IntPtr parameters);

        #endregion

        #region Not Native Functions

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_cparameters_t_new();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_cparameters_t_delete(IntPtr parameters);

        #endregion

    }

}