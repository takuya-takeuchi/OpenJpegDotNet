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

    }

}