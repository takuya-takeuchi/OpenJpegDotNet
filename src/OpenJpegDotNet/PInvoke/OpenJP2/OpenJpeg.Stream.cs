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
        public static extern void openjpeg_openjp2_opj_stream_destroy(IntPtr p_stream);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_stream_default_create(bool p_is_read_stream);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_stream_create(uint64_t p_buffer_size,
                                                                       bool p_is_read_stream);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_stream_set_read_function(IntPtr p_stream,
                                                                                  IntPtr p_function);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_stream_set_write_function(IntPtr p_stream,
                                                                                   IntPtr p_function);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_stream_set_skip_function(IntPtr p_stream,
                                                                                IntPtr p_function);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_stream_set_seek_function(IntPtr p_stream,
                                                                                IntPtr p_function);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_stream_set_user_data(IntPtr p_stream,
                                                                            IntPtr p_data,
                                                                            IntPtr p_function);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void openjpeg_openjp2_opj_stream_set_user_data_length(IntPtr p_stream,
                                                                                   uint64_t data_length);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_stream_create_default_file_stream(byte[] fname,
                                                                                           uint fname_len,
                                                                                           bool p_is_read_stream);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr openjpeg_openjp2_opj_stream_create_file_stream(byte[] fname,
                                                                                   uint fname_len,
                                                                                   uint64_t p_buffer_size,
                                                                                   bool p_is_read_stream);

        #endregion

    }

}