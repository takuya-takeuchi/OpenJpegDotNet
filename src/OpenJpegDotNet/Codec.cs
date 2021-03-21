using System;

namespace OpenJpegDotNet
{

    /// <summary>
    /// Defines the JPEG 2000 codec V2. This class cannot be inherited.
    /// </summary>
    public sealed class Codec : OpenJpegObject
    {

        #region Constructors

        internal Codec(IntPtr ptr) :
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

            NativeMethods.openjpeg_openjp2_opj_destroy_codec(this.NativePtr);
        }

        #endregion

    }

}