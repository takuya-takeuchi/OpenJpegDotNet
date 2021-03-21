using System;
using System.IO;

namespace OpenJpegDotNet
{

    ///// <summary>
    ///// Provides the utility methods.
    ///// </summary>
    //public static class Util
    //{

    //    #region Methods

    //    public static FileFormat InfileFormat(string filepath)
    //    {
    //        if (filepath == null)
    //            throw new ArgumentNullException(nameof(filepath));
    //        if (!File.Exists(filepath))
    //            throw new FileNotFoundException($"The specified {nameof(filepath)} does not exist.", filepath);

    //        var str = OpenJpeg.Encoding.GetBytes(filepath);
    //        var error = NativeMethods.openjpeg_openjp2_infile_format(str, (uint)str.Length, out var format);
    //        if (error != NativeMethods.ErrorType.OK)
    //        {
    //            // ToDo: throw proper exception
    //            switch (error)
    //            {
    //                case NativeMethods.ErrorType.GeneralFileIOError:
    //                    break;
    //                case NativeMethods.ErrorType.ImageFileInvalid:
    //                    break;
    //                case NativeMethods.ErrorType.ImageFileWrongExtension:
    //                    break;
    //            }
    //        }

    //        return format;
    //    }

    //    #endregion

    //}

}