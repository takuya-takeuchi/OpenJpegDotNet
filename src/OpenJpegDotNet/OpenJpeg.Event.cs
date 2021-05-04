using System;

namespace OpenJpegDotNet
{
    
    public static partial class OpenJpeg
    {

        /// <summary>
        /// Set the info handler.
        /// </summary>
        /// <param name="codec">The codec previously initialise.</param>
        /// <param name="callback">The callback function which will be used.</param>
        /// <param name="userData">The client object where will be returned the message.</param>
        /// <exception cref="ArgumentNullException"><paramref name="codec"/> or <paramref name="callback"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="codec"/> is disposed.</exception>
        public static void SetInfoHandler(Codec codec, DelegateHandler<MsgCallback> callback, IntPtr userData)
        {
            if (codec == null)
                throw new ArgumentNullException(nameof(codec));
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            codec.ThrowIfDisposed();

            NativeMethods.openjpeg_openjp2_opj_set_info_handler(codec.NativePtr, callback.Handle, userData);
        }

        /// <summary>
        /// Set the warning handler.
        /// </summary>
        /// <param name="codec">The codec previously initialise.</param>
        /// <param name="callback">The callback function which will be used.</param>
        /// <param name="userData">The client object where will be returned the message.</param>
        /// <exception cref="ArgumentNullException"><paramref name="codec"/> or <paramref name="callback"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="codec"/> is disposed.</exception>
        public static void SetWarnHandler(Codec codec, DelegateHandler<MsgCallback> callback, IntPtr userData)
        {
            if (codec == null)
                throw new ArgumentNullException(nameof(codec));
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            codec.ThrowIfDisposed();

            NativeMethods.openjpeg_openjp2_opj_set_warning_handler(codec.NativePtr, callback.Handle, userData);
        }

        /// <summary>
        /// Set the warning handler.
        /// </summary>
        /// <param name="codec">The codec previously initialise.</param>
        /// <param name="callback">The callback function which will be used.</param>
        /// <param name="userData">The client object where will be returned the message.</param>
        /// <exception cref="ArgumentNullException"><paramref name="codec"/> or <paramref name="callback"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="codec"/> is disposed.</exception>
        public static void SetErrorHandler(Codec codec, DelegateHandler<MsgCallback> callback, IntPtr userData)
        {
            if (codec == null)
                throw new ArgumentNullException(nameof(codec));
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            codec.ThrowIfDisposed();

            NativeMethods.openjpeg_openjp2_opj_set_error_handler(codec.NativePtr, callback.Handle, userData);
        }

    }

}