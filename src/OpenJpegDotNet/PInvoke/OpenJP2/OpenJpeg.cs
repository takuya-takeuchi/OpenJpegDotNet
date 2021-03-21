﻿using System;
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

        #region opj_image

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_get_x0(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_get_y0(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_get_x1(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_get_y1(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_get_numcomps(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ColorSpace openjpeg_openjp2_opj_image_get_color_space(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_image_get_comps(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_image_get_icc_profile_buf(IntPtr image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_image_get_icc_profile_len(IntPtr image);
        
        #endregion

        #region opj_dparameters_t

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_dparameters_t_get_cp_layer(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_dparameters_t_set_cp_layer(IntPtr parameters, uint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_dparameters_t_get_cp_reduce(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_dparameters_t_set_cp_reduce(IntPtr parameters, uint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_dparameters_t_get_cod_format(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_dparameters_t_set_cod_format(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_dparameters_t_get_decod_format(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_dparameters_t_set_decod_format(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_dparameters_t_get_jpwl_exp_comps(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_dparameters_t_set_jpwl_exp_comps(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int openjpeg_openjp2_opj_dparameters_t_get_jpwl_max_tiles(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_dparameters_t_set_jpwl_max_tiles(IntPtr parameters, int value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool openjpeg_openjp2_opj_dparameters_t_get_jpwl_correct(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_dparameters_t_set_jpwl_correct(IntPtr parameters, bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool openjpeg_openjp2_opj_dparameters_t_get_m_verbose(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_dparameters_t_set_m_verbose(IntPtr parameters, bool value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_dparameters_t_get_DA_x0(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_dparameters_t_set_DA_x0(IntPtr parameters, uint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_dparameters_t_get_DA_x1(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_dparameters_t_set_DA_x1(IntPtr parameters, uint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_dparameters_t_get_DA_y0(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_dparameters_t_set_DA_y0(IntPtr parameters, uint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_dparameters_t_get_DA_y1(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_dparameters_t_set_DA_y1(IntPtr parameters, uint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_dparameters_t_get_nb_tile_to_decode(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_dparameters_t_set_nb_tile_to_decode(IntPtr parameters, uint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_dparameters_t_get_tile_index(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_dparameters_t_set_tile_index(IntPtr parameters, uint value);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint openjpeg_openjp2_opj_dparameters_t_get_flags(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_dparameters_t_set_flags(IntPtr parameters, uint value);

        #endregion

        #endregion

        #region Version

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_version();

        #endregion

        #region Image

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_image_destroy(IntPtr image);

        #endregion

        #region Steram

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_stream_destroy(IntPtr p_stream);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_stream_create_default_file_stream(byte[] fname,
                                                                                           uint fname_len,
                                                                                           bool p_is_read_stream);

        #endregion

        #region Codec

        #region Decompress

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_create_decompress(CodecFormat format);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_destroy_codec(IntPtr p_codec);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool openjpeg_openjp2_opj_end_decompress(IntPtr p_codec, IntPtr p_stream);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_set_default_decoder_parameters(IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool openjpeg_openjp2_opj_setup_decoder(IntPtr p_codec, IntPtr parameters);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool openjpeg_openjp2_opj_read_header(IntPtr p_stream, IntPtr p_codec, out IntPtr p_image);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool openjpeg_openjp2_opj_set_decode_area(IntPtr p_codec,
                                                                       IntPtr p_image,
                                                                       uint p_start_x,
                                                                       uint p_start_y,
                                                                       uint p_end_x,
                                                                       uint p_end_y);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool openjpeg_openjp2_opj_decode(IntPtr p_codec,
                                                              IntPtr p_stream,
                                                              IntPtr p_image);

        #endregion

        #region Compress

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_create_compress(CodecFormat format);

        #endregion

        #endregion

        #region Not Official

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_opj_dparameters_t_new();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_opj_dparameters_t_delete(IntPtr parameters);

        #endregion

    }

}