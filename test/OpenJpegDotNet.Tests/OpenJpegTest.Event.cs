using System;
using System.IO;
using System.Runtime.InteropServices;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJpegDotNet.Tests
{

    public sealed partial class OpenJpegTest
    {

        #region Functions

        [Fact]
        public void SetInfoHandler()
        {
            using var codec = OpenJpeg.CreateCompress(CodecFormat.J2k);
            OpenJpeg.SetInfoHandler(codec, new DelegateHandler<MsgCallback>(MsgInfoCallback), IntPtr.Zero);
            this.DisposeAndCheckDisposedState(codec);
        }

        [Fact]
        public void SetWarnHandler()
        {
            using var codec = OpenJpeg.CreateCompress(CodecFormat.J2k);
            OpenJpeg.SetWarnHandler(codec, new DelegateHandler<MsgCallback>(MsgWarnCallback), IntPtr.Zero);
            this.DisposeAndCheckDisposedState(codec);
        }

        [Fact]
        public void SetErrorHandler()
        {
            using var codec = OpenJpeg.CreateCompress(CodecFormat.J2k);
            OpenJpeg.SetErrorHandler(codec, new DelegateHandler<MsgCallback>(MsgErrorCallback), IntPtr.Zero);
            this.DisposeAndCheckDisposedState(codec);
        }

        #endregion

        #region Helpers

        private static void MsgInfoCallback(IntPtr msg, IntPtr userData)
        {
            if (msg != IntPtr.Zero)
                Console.WriteLine($"[Info] {Marshal.PtrToStringAnsi(msg)}");
        }

        private static void MsgWarnCallback(IntPtr msg, IntPtr userData)
        {
            if (msg != IntPtr.Zero)
                Console.WriteLine($"[Warn] {Marshal.PtrToStringAnsi(msg)}");
        }

        private static void MsgErrorCallback(IntPtr msg, IntPtr userData)
        {
            if (msg != IntPtr.Zero)
                Console.WriteLine($"[Error] {Marshal.PtrToStringAnsi(msg)}");
        }

        #endregion

    }

}
