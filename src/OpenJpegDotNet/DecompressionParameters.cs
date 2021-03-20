using System;

namespace OpenJpegDotNet
{

    /// <summary>
    /// Describes the decompression parameters. This class cannot be inherited.
    /// </summary>
    public sealed class DecompressionParameters : OpenJpegObject
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DecompressionParameters"/> class.
        /// </summary>
        public DecompressionParameters()
        {
            this.NativePtr = NativeMethods.openjpeg_openjp2_opj_opj_dparameters_t_new();
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

            NativeMethods.openjpeg_openjp2_opj_opj_dparameters_t_delete(this.NativePtr);
        }

        #endregion

    }

}