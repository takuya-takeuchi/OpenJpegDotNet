using System;

namespace OpenJpegDotNet
{

    /// <summary>
    /// Defines the component parameters. This class cannot be inherited.
    /// </summary>
    public sealed class ImageComponentParameters : OpenJpegObject
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageComponentParameters"/> class.
        /// </summary>
        public ImageComponentParameters()
        {
            this.NativePtr = NativeMethods.openjpeg_openjp2_opj_image_cmptparm_t_new();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Sets or get the image depth in bits.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint Bpp
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_cmptparm_t_get_bpp(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_image_cmptparm_t_set_bpp(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the horizontal separation of a sample of ith component with respect to the reference grid.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint Dx
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_cmptparm_t_get_dx(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_image_cmptparm_t_set_dx(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the vertical separation of a sample of ith component with respect to the reference grid.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint Dy
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_cmptparm_t_get_dy(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_image_cmptparm_t_set_dy(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the data height.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint Height
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_cmptparm_t_get_h(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_image_cmptparm_t_set_h(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the precision.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint Precision
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_cmptparm_t_get_prec(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_image_cmptparm_t_set_prec(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the value to indicate whether data with signed or unsigned.
        /// </summary>
        /// <remarks><code>true</code> if data with signed; otherwise, <code>false</code>.</remarks>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public bool Signed
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_cmptparm_t_get_sgnd(this.NativePtr) == 1u;
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_image_cmptparm_t_set_sgnd(this.NativePtr, value ? 1u : 0u);
            }
        }

        /// <summary>
        /// Sets or get the data width.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint Width
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_cmptparm_t_get_w(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_image_cmptparm_t_set_w(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the x component offset compared to the whole image.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint X0
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_cmptparm_t_get_x0(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_image_cmptparm_t_set_x0(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the y component offset compared to the whole image.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint Y0
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_cmptparm_t_get_y0(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_image_cmptparm_t_set_y0(this.NativePtr, value);
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

            NativeMethods.openjpeg_openjp2_opj_image_cmptparm_t_delete(this.NativePtr);
        }

        #endregion

    }

}