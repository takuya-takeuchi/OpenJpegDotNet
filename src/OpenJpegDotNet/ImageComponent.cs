using System;

namespace OpenJpegDotNet
{

    /// <summary>
    /// Defines the image component. This class cannot be inherited.
    /// </summary>
    public sealed class ImageComponent : OpenJpegObject
    {

        #region Constructors
        
        internal ImageComponent(IntPtr ptr)
        {
            this.NativePtr = ptr;
        }

        #endregion

        #region Properties
        
        //data(opj_image_comp_t* comp)

        /// <summary>
        /// Get the alpha channel.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public ushort Alpha
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_comp_t_get_alpha(this.NativePtr);
            }
        }

        /// <summary>
        /// Get the image depth in bits.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint Bpp
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_comp_t_get_bpp(this.NativePtr);
            }
        }

        /// <summary>
        /// Get the image component data.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public IntPtr Data
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_comp_t_get_data(this.NativePtr);
            }
        }

        /// <summary>
        /// Get the horizontal separation of a sample of ith component with respect to the reference grid.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint Dx
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_comp_t_get_dx(this.NativePtr);
            }
        }

        /// <summary>
        /// Get the vertical separation of a sample of ith component with respect to the reference grid.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint Dy
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_comp_t_get_dy(this.NativePtr);
            }
        }

        /// <summary>
        /// Get the number of division by 2 of the out image compared to the original size of image.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint Factor
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_comp_t_get_factor(this.NativePtr);
            }
        }

        /// <summary>
        /// Get the data height.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint Height
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_comp_t_get_h(this.NativePtr);
            }
        }

        /// <summary>
        /// Get the precision.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint Precision
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_comp_t_get_prec(this.NativePtr);
            }
        }

        /// <summary>
        /// Get the number of decoded resolution.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint ResolutionDecoded
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_comp_t_get_resno_decoded(this.NativePtr);
            }
        }

        /// <summary>
        /// Get the value to indicate whether data with signed or unsigned.
        /// </summary>
        /// <remarks><code>true</code> if data with signed; otherwise, <code>false</code>.</remarks>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public bool Signed
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_comp_t_get_sgnd(this.NativePtr) == 1u;
            }
        }

        /// <summary>
        /// Get the data width.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint Width
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_comp_t_get_w(this.NativePtr);
            }
        }

        /// <summary>
        /// Get the x component offset compared to the whole image.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint X0
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_comp_t_get_x0(this.NativePtr);
            }
        }

        /// <summary>
        /// Get the y component offset compared to the whole image.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint Y0
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_comp_t_get_y0(this.NativePtr);
            }
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

            // need not to do
            // opj_image_comp_t could be from openjpeg_openjp2_opj_image_t_get_comps_by_index.
            // pointer must NOT dispose!!
        }

        #endregion

    }

}