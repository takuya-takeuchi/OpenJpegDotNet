using System;

namespace OpenJpegDotNet
{

    /// <summary>
    /// Defines the image data and characteristics. This class cannot be inherited.
    /// </summary>
    public sealed class Image : OpenJpegObject
    {

        #region Constructors

        internal Image(IntPtr ptr)
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

            NativeMethods.openjpeg_openjp2_opj_image_destroy(this.NativePtr);
        }

        #endregion

    }

}