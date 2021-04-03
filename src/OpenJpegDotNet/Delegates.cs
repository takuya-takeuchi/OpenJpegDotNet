using System;
using System.Runtime.InteropServices;

namespace OpenJpegDotNet
{

    /// <summary>
    /// Callback function prototype for read.
    /// </summary>
    /// <param name="buffer">The position to read.</param>
    /// <param name="bytes">The length of <parameref name="buffer"/>.</param>
    /// <param name="userData">The data pointer to have beee passed to <see cref="OpenJpeg.StreamSetUserData"/>.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int StreamRead(IntPtr buffer, long bytes, IntPtr userData);

    /// <summary>
    /// Callback function prototype for write.
    /// </summary>
    /// <param name="buffer">The position to write.</param>
    /// <param name="bytes">The length of <parameref name="buffer"/>.</param>
    /// <param name="userData">The data pointer to have beee passed to <see cref="OpenJpeg.StreamSetUserData"/>.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int StreamWrite(IntPtr buffer, long bytes, IntPtr userData);

    /// <summary>
    /// Callback function prototype for skip.
    /// </summary>
    /// <param name="bytes">The position to skip.</param>
    /// <param name="userData">The data pointer to have beee passed to <see cref="OpenJpeg.StreamSetUserData"/>.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int StreamSkip(long bytes, IntPtr userData);

    /// <summary>
    /// Callback function prototype for seek.
    /// </summary>
    /// <param name="bytes">The position to seek.</param>
    /// <param name="userData">The data pointer to have beee passed to <see cref="OpenJpeg.StreamSetUserData"/>.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int StreamSeek(long bytes, IntPtr userData);

    /// <summary>
    /// Callback function to free user data.
    /// </summary>
    /// <param name="userData">The data pointer to have beee passed to <see cref="OpenJpeg.StreamSetUserData"/>.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void StreamFreeUserData(IntPtr userData);

}