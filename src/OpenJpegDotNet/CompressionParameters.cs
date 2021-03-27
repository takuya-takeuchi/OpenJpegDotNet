using System;

namespace OpenJpegDotNet
{

    /// <summary>
    /// Defines the compression parameters. This class cannot be inherited.
    /// </summary>
    public sealed class CompressionParameters : OpenJpegObject
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CompressionParameters"/> class.
        /// </summary>
        public CompressionParameters()
        {
            this.NativePtr = NativeMethods.openjpeg_openjp2_opj_cparameters_t_new();
        }

        #endregion

        #region Properties

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

            NativeMethods.openjpeg_openjp2_opj_cparameters_t_delete(this.NativePtr);
        }

        #endregion

    }

}