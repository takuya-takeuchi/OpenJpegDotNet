using System;
using System.Linq;

namespace OpenJpegDotNet
{
    
    public static partial class OpenJpeg
    {

        /// <summary>
        /// Create an image.
        /// </summary>
        /// <param name="components">The number of components.</param>
        /// <param name="componentsParameters">The components parameters.</param>
        /// <param name="colorSpace">The image color space.</param>
        /// <returns>A new <see cref="Image"/>.</returns>
        public static Image ImageCreate(uint components,
                                        ImageComponentParameters[] componentsParameters,
                                        ColorSpace colorSpace)
        {
            if (componentsParameters == null)
                throw new ArgumentNullException(nameof(componentsParameters));

            foreach (var componentsParameter in componentsParameters)
                componentsParameter.ThrowIfDisposed();

            var pointers = componentsParameters.Select(parameters => parameters.NativePtr).ToArray();
            var ret = NativeMethods.openjpeg_openjp2_opj_image_create(components, pointers, (uint)pointers.Length, colorSpace);
            return ret != IntPtr.Zero ? new Image(ret) : null;
        }

        /// <summary>
        /// Creates an image without allocating memory for the image.
        /// </summary>
        /// <param name="components">The number of components.</param>
        /// <param name="componentsParameters">The components parameters.</param>
        /// <param name="colorSpace">The image color space.</param>
        /// <returns>A new <see cref="Image"/>.</returns>
        public static Image ImageTileCreate(uint components,
                                            ImageComponentParameters[] componentsParameters,
                                            ColorSpace colorSpace)
        {
            if (componentsParameters == null)
                throw new ArgumentNullException(nameof(componentsParameters));

            foreach (var componentsParameter in componentsParameters)
                componentsParameter.ThrowIfDisposed();

            var pointers = componentsParameters.Select(parameters => parameters.NativePtr).ToArray();
            var ret = NativeMethods.openjpeg_openjp2_opj_image_tile_create(components, pointers, (uint)pointers.Length, colorSpace);
            return ret != IntPtr.Zero ? new Image(ret) : null;
        }
        
        /// <summary>
        /// Allocates new memory buffer for <see cref="ImageComponent.Data"/>.
        /// </summary>
        /// <param name="size">The number of bytes to allocate.</param>
        /// <returns>The new pointer to indicate allocated memory buffer if success; otherwise, <see cref="IntPtr.Zero"/>.</returns>
        public static IntPtr ImageDataAlloc(long size)
        {
            return NativeMethods.openjpeg_openjp2_opj_image_data_alloc(size);
        }

        /// <summary>
        /// Unallocates memory buffer for <see cref="ImageComponent.Data"/>.
        /// </summary>
        /// <param name="ptr">The pointer to indicate allocated memory buffer by <see cref="ImageDataAlloc"/>.</param>
        public static void ImageDataFree(IntPtr ptr)
        {
            NativeMethods.openjpeg_openjp2_opj_image_data_free(ptr);
        }

    }

}