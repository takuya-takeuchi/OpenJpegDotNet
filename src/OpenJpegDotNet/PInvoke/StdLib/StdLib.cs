using System;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenJpegDotNet
{

    internal sealed partial class NativeMethods
    {

        #region stdlib

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void stdlib_free(IntPtr ptr);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr stdlib_malloc(IntPtr size);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void stdlib_srand(uint seed);

        #endregion

        #region string

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr string_new();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr string_new2(StringBuilder c_str, int len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void string_append(IntPtr str, StringBuilder c_str, int len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr string_c_str(IntPtr str);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void string_delete(IntPtr str);

        #endregion

        #region ostringstream

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr ostringstream_new();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr ostringstream_str(IntPtr str);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void ostringstream_delete(IntPtr str);

        #endregion

        #region vector

        #region int32

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr std_vector_int32_new1();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr std_vector_int32_new2(IntPtr size);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr std_vector_int32_new3([In] int[] data, IntPtr dataLength);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr std_vector_int32_getSize(IntPtr vector);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr std_vector_int32_getPointer(IntPtr vector);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int std_vector_int32_at(IntPtr vector, int index);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void std_vector_int32_delete(IntPtr vector);

        #endregion

        #region uint32

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr std_vector_uint32_new1();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr std_vector_uint32_new2(IntPtr size);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr std_vector_uint32_new3([In] uint[] data, IntPtr dataLength);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr std_vector_uint32_getSize(IntPtr vector);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr std_vector_uint32_getPointer(IntPtr vector);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ulong std_vector_uint32_at(IntPtr vector, int index);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void std_vector_uint32_delete(IntPtr vector);

        #endregion

        #endregion

        #region random_device

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr std_random_device_new();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void std_random_device_delete(IntPtr ptr);

        #endregion
        
        #region random_device

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr std_mt19937_new(IntPtr device);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr std_mt19937_new2(uint seed);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void std_mt19937_delete(IntPtr ptr);

        #endregion
        
        #region random_device

        #region uniform_real_distribution

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr std_uniform_real_distribution_double_new(double a, double b);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void std_uniform_real_distribution_double_delete(IntPtr ptr);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern double std_uniform_real_distribution_double_xorshift_operator(IntPtr ptr, IntPtr xorshift);

        #endregion

        #endregion

    }

}