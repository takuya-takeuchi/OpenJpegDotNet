using System;

namespace OpenJpegDotNet
{

    /// <summary>
    /// Describes the JPEG2000 Stream. This class cannot be inherited.
    /// </summary>
    public sealed class Stream : OpenJpegObject
    {

        #region Constructors

        internal Stream(IntPtr ptr) :
            base(true)
        {
            this.NativePtr = ptr;
        }

        #endregion

        #region Overrides 

        /// <summary>
        /// Releases all unmanaged resources.
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();

            if (this.NativePtr == IntPtr.Zero)
                return;

            NativeMethods.openjpeg_openjp2_opj_stream_destroy(this.NativePtr);
        }

        #endregion

    }

}