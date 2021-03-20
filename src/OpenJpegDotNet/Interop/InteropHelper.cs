using System;

namespace OpenJpegDotNet.Interop
{

    internal static class InteropHelper
    {

        public static void Copy(IntPtr ptrSource, uint[] dest, uint elements)
        {
            Copy(ptrSource, dest, 0, elements);
        }

        public static unsafe void Copy(IntPtr ptrSource, uint[] dest, int startIndex, uint elements)
        {
            fixed (uint* ptrDest = &dest[startIndex])
                NativeMethods.cstd_memcpy((IntPtr)ptrDest, ptrSource, (int)(elements * sizeof(uint)));
        }

        public static unsafe void Copy(uint[] source, IntPtr ptrDest, uint elements)
        {
            fixed (uint* ptrSource = &source[0])
                NativeMethods.cstd_memcpy(ptrDest, (IntPtr)ptrSource, (int)(elements * sizeof(uint)));
        }

    }

}
