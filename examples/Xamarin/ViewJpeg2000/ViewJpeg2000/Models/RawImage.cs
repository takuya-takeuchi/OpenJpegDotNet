namespace ViewJpeg2000.Models
{

    public sealed class RawImage
    {

        #region Constructors

        public RawImage(byte[] image, int width, int height, int channel)
        {
            this.Image = image;
            this.Width = width;
            this.Height = height;
            this.Channel = channel;

        }

        #endregion

        #region Properties

        public byte[] Image
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

        public int Channel
        {
            get;
        }

        #endregion

    }

}
