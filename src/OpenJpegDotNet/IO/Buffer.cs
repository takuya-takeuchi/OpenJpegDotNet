using System;
using System.Runtime.InteropServices;

namespace OpenJpegDotNet.IO
{

    [StructLayout(LayoutKind.Sequential)]
    internal struct Buffer
    {

        public IntPtr Data;

        public int Length;

        public int Position;

    }

}