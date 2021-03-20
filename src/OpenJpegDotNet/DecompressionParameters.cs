using System;

namespace OpenJpegDotNet
{

    /// <summary>
    /// Describes the decompression parameters. This class cannot be inherited.
    /// </summary>
    public sealed class DecompressionParameters : OpenJpegObject
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DecompressionParameters"/> class.
        /// </summary>
        public DecompressionParameters()
        {
            this.NativePtr = NativeMethods.openjpeg_openjp2_opj_opj_dparameters_t_new();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Sets or get the output file format.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int CodingFormat
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_dparameters_t_get_cod_format(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_dparameters_t_set_cod_format(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the maximum number of quality layers to decode.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint CodingParameterLayer
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_dparameters_t_get_cp_layer(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_dparameters_t_set_cp_layer(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the number of highest resolution levels to be discarded.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint CodingParameterReduce
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_dparameters_t_get_cp_reduce(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_dparameters_t_set_cp_reduce(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the input file format.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int DecodingFormat
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_dparameters_t_get_decod_format(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_dparameters_t_set_decod_format(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the decoding area left boundary.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint DecodingAreaX0
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_dparameters_t_get_DA_x0(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_dparameters_t_set_DA_x0(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the decoding area right boundary.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint DecodingAreaX1
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_dparameters_t_get_DA_x1(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_dparameters_t_set_DA_x1(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the decoding area up boundary.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint DecodingAreaY0
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_dparameters_t_get_DA_y0(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_dparameters_t_set_DA_y0(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the decoding area bottom boundary.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint DecodingAreaY1
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_dparameters_t_get_DA_y1(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_dparameters_t_set_DA_y1(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the flags.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint Flags
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_dparameters_t_get_flags(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_dparameters_t_set_flags(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get whether activates the JPWL correction capabilities for JPWL (wireless applications).
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public bool JpwlCorrect
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_dparameters_t_get_jpwl_correct(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_dparameters_t_set_jpwl_correct(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the expected number of components for JPWL (wireless applications).
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int JpwlExpectedComponents
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_dparameters_t_get_jpwl_exp_comps(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_dparameters_t_set_jpwl_exp_comps(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the maximum number of tiles for JPWL (wireless applications).
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int JpwlMaxTiles
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_dparameters_t_get_jpwl_max_tiles(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_dparameters_t_set_jpwl_max_tiles(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the number of blocks of tile to decode.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint NumberBlockTileToDecide
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_dparameters_t_get_nb_tile_to_decode(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_dparameters_t_set_nb_tile_to_decode(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the tile number of the decoded tile.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint TileIndex
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_dparameters_t_get_tile_index(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_dparameters_t_set_tile_index(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get whether enables verbose mode.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public bool VerboseMode
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_dparameters_t_get_m_verbose(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_dparameters_t_set_m_verbose(this.NativePtr, value);
            }
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

            NativeMethods.openjpeg_openjp2_opj_opj_dparameters_t_delete(this.NativePtr);
        }

        #endregion

    }

}