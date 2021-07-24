using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OpenJpegDotNet
{

    /// <summary>
    /// Defines the raw bitmap image data. This class cannot be inherited.
    /// </summary>
    public sealed class RawBitmap : OpenJpegObject
    {

        #region Constructors

        internal RawBitmap(IList<byte> data, int width, int height, int channel)
        {
            this.Data = new ReadOnlyCollection<byte>(data);
            this.Width = width;
            this.Height = height;
            this.Channel = channel;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the number of channel, of this <see cref="RawBitmap"/>.
        /// </summary>
        /// <returns>The number of channel, of this <see cref="RawBitmap"/>.</returns>
        public int Channel
        {
            get;
        }

        /// <summary>
        /// Gets the pixel data of this <see cref="RawBitmap"/>.
        /// </summary>
        /// <returns>The pixel data.</returns>
        public IReadOnlyCollection<byte> Data
        {
            get;
        }

        /// <summary>
        /// Gets the height, in pixels, of this <see cref="RawBitmap"/>.
        /// </summary>
        /// <returns>The height, in pixels, of this <see cref="RawBitmap"/>.</returns>
        public int Height
        {
            get;
        }

        /// <summary>
        /// Gets the width, in pixels, of this <see cref="RawBitmap"/>.
        /// </summary>
        /// <returns>The width, in pixels, of this <see cref="RawBitmap"/>.</returns>
        public int Width
        {
            get;
        }

        #endregion

    }

}