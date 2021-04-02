﻿using System;
using System.IO;

namespace OpenJpegDotNet
{

    /// <summary>
    /// Provides the methods of OpenJpeg.
    /// </summary>
    public static partial class OpenJpeg
    {

        /// <summary>
        /// Creates an abstract stream.
        /// </summary>
        /// <param name="isReadStream">The value whether the stream is a read stream.</param>
        /// <returns>The <see cref="Stream"/>.</returns>
        public static Stream StreamDefaultCreate(bool isReadStream)
        {
            var ret = NativeMethods.openjpeg_openjp2_opj_stream_default_create(isReadStream);
            return new Stream(ret);
        }

        /// <summary>
        /// Creates an abstract stream with a specific buffer size.
        /// </summary>
        /// <param name="bufferSize">The size of the chunk used to stream.</param>
        /// <param name="isReadStream">The value whether the stream is a read stream.</param>
        /// <returns>The <see cref="Stream"/>.</returns>
        public static Stream StreamCreate(ulong bufferSize, bool isReadStream)
        {
            var ret = NativeMethods.openjpeg_openjp2_opj_stream_create(bufferSize, isReadStream);
            return new Stream(ret);
        }

        /// <summary>
        /// Create a stream from a file identified with its filename with default parameters.
        /// </summary>
        /// <param name="filepath">The filename of the file to input to stream.</param>
        /// <param name="isReadStream">The value whether the stream is a read stream.</param>
        /// <returns>The <see cref="Stream"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="filepath"/> is null.</exception>
        /// <exception cref="FileNotFoundException">The specified path does not exist.</exception>
        public static Stream StreamCreateDefaultFileStream(string filepath, bool isReadStream)
        {
            if (filepath == null)
                throw new ArgumentNullException(nameof(filepath));
            if (isReadStream && !File.Exists(filepath))
                throw new FileNotFoundException($"The specified {nameof(filepath)} does not exist.", filepath);

            var str = Encoding.GetBytes(filepath);
            var ret = NativeMethods.openjpeg_openjp2_opj_stream_create_default_file_stream(str, (uint)str.Length, isReadStream);
            return new Stream(ret);
        }

        /// <summary>
        /// Create a stream from a file identified with its filename with a specific buffer size.
        /// </summary>
        /// <param name="filepath">The filename of the file to input to stream.</param>
        /// <param name="bufferSize">The size of the chunk used to stream.</param>
        /// <param name="isReadStream">The value whether the stream is a read stream.</param>
        /// <returns>The <see cref="Stream"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="filepath"/> is null.</exception>
        /// <exception cref="FileNotFoundException">The specified path does not exist.</exception>
        public static Stream StreamCreateFileStream(string filepath, ulong bufferSize, bool isReadStream)
        {
            if (filepath == null)
                throw new ArgumentNullException(nameof(filepath));
            if (isReadStream && !File.Exists(filepath))
                throw new FileNotFoundException($"The specified {nameof(filepath)} does not exist.", filepath);

            var str = Encoding.GetBytes(filepath);
            var ret = NativeMethods.openjpeg_openjp2_opj_stream_create_file_stream(str, (uint)str.Length, bufferSize, isReadStream);
            return new Stream(ret);
        }

    }

}