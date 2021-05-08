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

        public int Channel
        {
            get;
        }

        public IReadOnlyCollection<byte> Data
        {
            get;
        }

        public int Width
        {
            get;
        }

        public int Height
        {
            get;
        }

        #endregion

    }

}