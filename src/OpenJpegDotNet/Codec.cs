using System;

namespace OpenJpegDotNet
{

    /// <summary>
    /// Describes the JPEG2000 codec V2. This class cannot be inherited.
    /// </summary>
    public sealed class Codec : OpenJpegObject
    {

        #region Constructors

        internal Codec(IntPtr ptr) :
            base(true)
        {
            this.NativePtr = ptr;
        }

        #endregion

    }

}