using System;
using System.Drawing;
using System.Drawing.Imaging;
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

        #region Methods

        /// <summary>
        /// Converts this <see cref="Image"/> to a GDI+ <see cref="Bitmap"/>.
        /// </summary>
        /// <returns>A <see cref="Bitmap"/> that represents the converted <see cref="Image"/>.</returns>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="NotSupportedException">This object is not supported.</exception>
        public Bitmap ToBitmap()
        {
            this.ThrowIfDisposed();

            var ret = NativeMethods.openjpeg_openjp2_extensions_imagetobmp(this.NativePtr,
                                                                           false,
                                                                           out var planes,
                                                                           out var width,
                                                                           out var height,
                                                                           out var channel,
                                                                           out var pixel);
            if (ret != NativeMethods.ErrorType.OK)
            {
                if (planes != IntPtr.Zero)
                    NativeMethods.stdlib_free(planes);

                throw new NotSupportedException("This object is not supported.");
            }

            if (channel != 3 && channel != 1)
            {
                if (planes != IntPtr.Zero)
                    NativeMethods.stdlib_free(planes);

                throw new NotSupportedException("This object is not supported.");
            }

            Bitmap bitmap = null;
            BitmapData bitmapData = null;

            try
            {

                switch (pixel)
                {
                    case 8:
                        switch (channel)
                        {
                            case 1:
                                {
                                    bitmap = new Bitmap((int)width, (int)height, PixelFormat.Format8bppIndexed);
                                    var rect = new Rectangle(0, 0, (int)width, (int)height);
                                    bitmapData = bitmap.LockBits(rect, ImageLockMode.WriteOnly, bitmap.PixelFormat);
                                    var scan0 = bitmapData.Scan0;
                                    var stride = bitmapData.Stride;
                                    for (var y = 0; y < height; y++)
                                    {
                                        var src = IntPtr.Add(planes, (int)(y * width));
                                        var dest = IntPtr.Add(scan0, y * stride);
                                        NativeMethods.cstd_memcpy(dest, src, (int)width);
                                    }
                                }
                                break;
                            case 3:
                                {
                                    bitmap = new Bitmap((int)width, (int)height, PixelFormat.Format24bppRgb);
                                    var rect = new Rectangle(0, 0, (int)width, (int)height);
                                    bitmapData = bitmap.LockBits(rect, ImageLockMode.WriteOnly, bitmap.PixelFormat);
                                    var scan0 = bitmapData.Scan0;
                                    var stride = bitmapData.Stride;

                                    unsafe
                                    {
                                        var pSrc = (byte*)planes;
                                        var pDest = (byte*)scan0;
                                        var gap = stride - width * channel;
                                        var size = width * height;
                                        for (var y = 0; y < height; y++)
                                        {
                                            for (var x = 0; x < width; x++)
                                            {
                                                pDest[2] = pSrc[0];
                                                pDest[1] = pSrc[0 + size];
                                                pDest[0] = pSrc[0 + size * 2];

                                                pSrc += 1;
                                                pDest += channel;
                                            }

                                            pDest += gap;
                                        }
                                    }
                                }
                                break;
                        }

                        break;
                    default:
                        throw new NotSupportedException("This object is not supported.");
                }
            }
            catch
            {
                if (bitmap != null && bitmapData != null)
                    bitmap.UnlockBits(bitmapData);
                bitmap?.Dispose();
                bitmap = null;
                bitmapData = null;
            }
            finally
            {
                if (planes != IntPtr.Zero)
                    NativeMethods.stdlib_free(planes);

                if (bitmap != null && bitmapData != null)
                    bitmap.UnlockBits(bitmapData);
            }

            return bitmap;
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