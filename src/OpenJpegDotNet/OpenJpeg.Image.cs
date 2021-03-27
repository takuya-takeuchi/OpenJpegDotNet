using System;
using System.IO;
using System.Linq;

namespace OpenJpegDotNet
{

    /// <summary>
    /// Provides the methods of OpenJpeg.
    /// </summary>
    public static partial class OpenJpeg
    {

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

    }

}