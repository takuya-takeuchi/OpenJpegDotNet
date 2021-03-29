using System;
using System.IO;

namespace OpenJpegDotNet
{

    /// <summary>
    /// Provides the methods of OpenJpeg.
    /// </summary>
    public static partial class OpenJpeg
    {

        /// <summary>
        /// Sets the MCT matrix to use.
        /// </summary>
        /// <param name="parameters">The <see cref="CompressionParameters"/> to change.</param>
        /// <param name="encodingMatrix">The encoding matrix.</param>
        /// <param name="dcShift">The dc shift coefficients to use.</param>
        /// <param name="components">The number of components of the image.</param>
        /// <returns><code>true</code> if the parameters could be set; otherwise, <code>false</code>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parameters"/>, <paramref name="encodingMatrix"/> or <paramref name="dcShift"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="parameters"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of <paramref name="encodingMatrix"/> must be <paramref name="components"/> x <paramref name="components"/> or less. Or The length of <paramref name="dcShift"/> must be <paramref name="components"/> or less</exception>
        public static bool SetMCT(CompressionParameters parameters,
                                  float[] encodingMatrix,
                                  int[] dcShift,
                                  uint components)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));
            if (encodingMatrix == null)
                throw new ArgumentNullException(nameof(encodingMatrix));
            if (dcShift == null)
                throw new ArgumentNullException(nameof(dcShift));

            parameters.ThrowIfDisposed();

            var matrixSize = components * components;
            var dcShiftSize = components;
            if (!(encodingMatrix.Length <= matrixSize))
                throw new ArgumentOutOfRangeException($"{nameof(encodingMatrix)}", $"The length of {nameof(encodingMatrix)} must be {nameof(components)} x {nameof(components)} or less.");
            if (!(dcShift.Length <= dcShiftSize))
                throw new ArgumentOutOfRangeException($"{nameof(dcShift)}", $"The length of {nameof(dcShift)} must be {nameof(components)} or less.");

            return NativeMethods.openjpeg_openjp2_opj_set_MCT(parameters.NativePtr, encodingMatrix, dcShift, components);
        }

    }

}