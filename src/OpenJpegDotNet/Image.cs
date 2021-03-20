using System;
using System.Runtime.InteropServices;

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

        #region Properties

        /// <summary>
        /// Gets the horizontal offset from the origin of the reference grid to the left side of the image area.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint X0
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_get_x0(this.NativePtr);
            }
        }

        /// <summary>
        /// Gets the width of the reference grid.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint X1
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_get_x1(this.NativePtr);
            }
        }

        /// <summary>
        /// Gets the vertical offset from the origin of the reference grid to the top side of the image area.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint Y0
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_get_y0(this.NativePtr);
            }
        }

        /// <summary>
        /// Gets the height of the reference grid.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint Y1
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_get_y1(this.NativePtr);
            }
        }

        /// <summary>
        /// Gets the number of components in the image.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint NumberOfComponents
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_get_numcomps(this.NativePtr);
            }
        }

        /// <summary>
        /// Gets the color space.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public ColorSpace ColorSpace
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_get_color_space(this.NativePtr);
            }
        }

        /// <summary>
        /// Gets the image components.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public IntPtr Components
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_image_get_comps(this.NativePtr);
            }
        }

        /// <summary>
        /// Gets the 'restricted' ICC profile.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public byte[] IccProfile
        {
            get
            {
                this.ThrowIfDisposed();
                var length = NativeMethods.openjpeg_openjp2_opj_image_get_icc_profile_len(this.NativePtr);
                var buffer = NativeMethods.openjpeg_openjp2_opj_image_get_icc_profile_buf(this.NativePtr);
                if (buffer == IntPtr.Zero || length == 0)
                    return null;

                var icc = new byte[length];
                Marshal.Copy(buffer, icc, 0, (int)length);

                return icc;
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

            NativeMethods.openjpeg_openjp2_opj_image_destroy(this.NativePtr);
        }

        #endregion

    }

}