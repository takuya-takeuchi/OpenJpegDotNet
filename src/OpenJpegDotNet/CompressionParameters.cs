using System;
using System.Runtime.InteropServices;

namespace OpenJpegDotNet
{

    /// <summary>
    /// Defines the compression parameters. This class cannot be inherited.
    /// </summary>
    public sealed class CompressionParameters : OpenJpegObject
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CompressionParameters"/> class.
        /// </summary>
        public CompressionParameters()
        {
            this.NativePtr = NativeMethods.openjpeg_openjp2_opj_cparameters_t_new();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Sets or get the error protection methods for Tile Part Headers (0,1,16,32,37-128).
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is invalid length.</exception>
        public int[] JpwlHeaderProtectionTilePartHeader
        {
            get
            {
                this.ThrowIfDisposed();

                unsafe
                {
                    NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_jpwl_hprot_TPH(this.NativePtr, out var value, out var len);
                    var result = new int[(int)len];
                    Marshal.Copy((IntPtr)value, result, 0, result.Length);
                    return result;
                }
            }
            set
            {
                this.ThrowIfDisposed();
                var error = NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_jpwl_hprot_TPH(this.NativePtr, value, (uint)value.Length);
                if (error == NativeMethods.ErrorType.GeneralOutOfRange)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} is invalid length.");
            }
        }

        /// <summary>
        /// Sets or get the tile number of header protection specification (>=0).
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is invalid length.</exception>
        public int[] JpwlHeaderProtectionTilePartHeaderTileNumber
        {
            get
            {
                this.ThrowIfDisposed();

                unsafe
                {
                    NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_jpwl_hprot_TPH_tileno(this.NativePtr, out var value, out var len);
                    var result = new int[(int)len];
                    Marshal.Copy((IntPtr)value, result, 0, result.Length);
                    return result;
                }
            }
            set
            {
                this.ThrowIfDisposed();
                var error = NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_jpwl_hprot_TPH_tileno(this.NativePtr, value, (uint)value.Length);
                if (error == NativeMethods.ErrorType.GeneralOutOfRange)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} is invalid length.");
            }
        }

        /// <summary>
        /// Sets or get the error protection methods for packets (0,1,16,32,37-128).
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is invalid length.</exception>
        public int[] JpwlPacketProtection
        {
            get
            {
                this.ThrowIfDisposed();

                unsafe
                {
                    NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_jpwl_pprot(this.NativePtr, out var value, out var len);
                    var result = new int[(int)len];
                    Marshal.Copy((IntPtr)value, result, 0, result.Length);
                    return result;
                }
            }
            set
            {
                this.ThrowIfDisposed();
                var error = NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_jpwl_pprot(this.NativePtr, value, (uint)value.Length);
                if (error == NativeMethods.ErrorType.GeneralOutOfRange)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} is invalid length.");
            }
        }

        /// <summary>
        /// Sets or get the packet number of packet protection specification (>=0).
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is invalid length.</exception>
        public int[] JpwlPacketProtectionPacketNumber
        {
            get
            {
                this.ThrowIfDisposed();

                unsafe
                {
                    NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_jpwl_pprot_packno(this.NativePtr, out var value, out var len);
                    var result = new int[(int)len];
                    Marshal.Copy((IntPtr)value, result, 0, result.Length);
                    return result;
                }
            }
            set
            {
                this.ThrowIfDisposed();
                var error = NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_jpwl_pprot_packno(this.NativePtr, value, (uint)value.Length);
                if (error == NativeMethods.ErrorType.GeneralOutOfRange)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} is invalid length.");
            }
        }

        /// <summary>
        /// Sets or get the tile number of packet protection specification (>=0).
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is invalid length.</exception>
        public int[] JpwlPacketProtectionTileNumber
        {
            get
            {
                this.ThrowIfDisposed();

                unsafe
                {
                    NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_jpwl_pprot_tileno(this.NativePtr, out var value, out var len);
                    var result = new int[(int)len];
                    Marshal.Copy((IntPtr)value, result, 0, result.Length);
                    return result;
                }
            }
            set
            {
                this.ThrowIfDisposed();
                var error = NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_jpwl_pprot_tileno(this.NativePtr, value, (uint)value.Length);
                if (error == NativeMethods.ErrorType.GeneralOutOfRange)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} is invalid length.");
            }
        }

        /// <summary>
        /// Sets or get the sensitivity methods for Tile Part Headers (-1=no,0-7).
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is invalid length.</exception>
        public int[] JpwlSensitivityTilePartHeader
        {
            get
            {
                this.ThrowIfDisposed();

                unsafe
                {
                    NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_jpwl_sens_TPH(this.NativePtr, out var value, out var len);
                    var result = new int[(int)len];
                    Marshal.Copy((IntPtr)value, result, 0, result.Length);
                    return result;
                }
            }
            set
            {
                this.ThrowIfDisposed();
                var error = NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_jpwl_sens_TPH(this.NativePtr, value, (uint)value.Length);
                if (error == NativeMethods.ErrorType.GeneralOutOfRange)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} is invalid length.");
            }
        }

        /// <summary>
        /// Sets or get the tile number of sensitivity specification (>=0).
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is invalid length.</exception>
        public int[] JpwlSensitivityTilePartHeaderTileNo
        {
            get
            {
                this.ThrowIfDisposed();

                unsafe
                {
                    NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_jpwl_sens_TPH_tileno(this.NativePtr, out var value, out var len);
                    var result = new int[(int)len];
                    Marshal.Copy((IntPtr)value, result, 0, result.Length);
                    return result;
                }
            }
            set
            {
                this.ThrowIfDisposed();
                var error = NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_jpwl_sens_TPH_tileno(this.NativePtr, value, (uint)value.Length);
                if (error == NativeMethods.ErrorType.GeneralOutOfRange)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} is invalid length.");
            }
        }

        ///// <summary>
        ///// Sets or get the .
        ///// </summary>
        ///// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        ///// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is invalid length.</exception>
        //public opj_poc_t[] POC
        //{
        //    get
        //    {
        //        this.ThrowIfDisposed();

        //        unsafe
        //        {
        //            NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_POC(this.NativePtr, out var value, out var len);
        //            var result = new int[(int)len];
        //            Marshal.Copy((IntPtr)value, result, 0, result.Length);
        //            return result;
        //        }
        //    }
        //    set
        //    {
        //        this.ThrowIfDisposed();
        //        var error = NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_POC(this.NativePtr, value, (uint)value.Length);
        //        if (error == NativeMethods.ErrorType.GeneralOutOfRange)
        //            throw new ArgumentOutOfRangeException($"{nameof(value)} is invalid length.");
        //    }
        //}

        /// <summary>
        /// Sets or get the initial precinct height.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is invalid length.</exception>
        public int[] PrecinctHeightInitial
        {
            get
            {
                this.ThrowIfDisposed();

                unsafe
                {
                    NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_prch_init(this.NativePtr, out var value, out var len);
                    var result = new int[(int)len];
                    Marshal.Copy((IntPtr)value, result, 0, result.Length);
                    return result;
                }
            }
            set
            {
                this.ThrowIfDisposed();
                var error = NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_prch_init(this.NativePtr, value, (uint)value.Length);
                if (error == NativeMethods.ErrorType.GeneralOutOfRange)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} is invalid length.");
            }
        }

        /// <summary>
        /// Sets or get the initial precinct width.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is invalid length.</exception>
        public int[] PrecinctWidthInitial
        {
            get
            {
                this.ThrowIfDisposed();

                unsafe
                {
                    NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_prcw_init(this.NativePtr, out var value, out var len);
                    var result = new int[(int)len];
                    Marshal.Copy((IntPtr)value, result, 0, result.Length);
                    return result;
                }
            }
            set
            {
                this.ThrowIfDisposed();
                var error = NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_prcw_init(this.NativePtr, value, (uint)value.Length);
                if (error == NativeMethods.ErrorType.GeneralOutOfRange)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} is invalid length.");
            }
        }

        /// <summary>
        /// Sets or get the different PSNR (Peak signal-to-noise ratio) for successive layers.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is invalid length.</exception>
        public float[] TcpDistoratio
        {
            get
            {
                this.ThrowIfDisposed();

                unsafe
                {
                    NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_tcp_distoratio(this.NativePtr, out var value, out var len);
                    var result = new float[(int)len];
                    Marshal.Copy((IntPtr)value, result, 0, result.Length);
                    return result;
                }
            }
            set
            {
                this.ThrowIfDisposed();
                var error = NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_tcp_distoratio(this.NativePtr, value, (uint)value.Length);
                if (error == NativeMethods.ErrorType.GeneralOutOfRange)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} is invalid length.");
            }
        }

        /// <summary>
        /// Sets or get the rates of layers - might be subsequently limited by the max_cs_size field.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is invalid length.</exception>
        public float[] TcpRates
        {
            get
            {
                this.ThrowIfDisposed();

                unsafe
                {
                    NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_tcp_rates(this.NativePtr, out var value, out var len);
                    var result = new float[(int)len];
                    Marshal.Copy((IntPtr)value, result, 0, result.Length);
                    return result;
                }
            }
            set
            {
                this.ThrowIfDisposed();
                var error = NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_tcp_rates(this.NativePtr, value, (uint)value.Length);
                if (error == NativeMethods.ErrorType.GeneralOutOfRange)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} is invalid length.");
            }
        }

        /// <summary>
        /// Sets or get the initial code block height.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int CodeBlockHeightInitial
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_cblockh_init(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_cblockh_init(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the initial code block width.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int CodeBlockWidthInitial
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_cblockw_init(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_cblockw_init(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the output file format.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int CodingFormat
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_cod_format(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_cod_format(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the Digital Cinema compliance.
        /// </summary>
        /// <remarks>if 0 not compliant, 1 is compliant.</remarks>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        [Obsolete]
        public CinemaMode CodingParameterCinema
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_cp_cinema(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_cp_cinema(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the RSIZ.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public ushort RegionSize
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_rsiz(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_rsiz(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the allocation by rate/distortion.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int CodingParameterDistortionAllocation
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_cp_disto_alloc(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_cp_disto_alloc(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the allocation by fixed layer.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int CodingParameterFixedAllocation
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_cp_fixed_alloc(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_cp_fixed_alloc(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the add fixed quality.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int CodingParameterFixedQuality
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_cp_fixed_quality(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_cp_fixed_quality(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the regions size
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        [Obsolete]
        public RegionSizeCapabilities CodingParameterRegionSize
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_cp_rsiz(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_cp_rsiz(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the XTsiz.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int CodingParameterTdx
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_cp_tdx(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_cp_tdx(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the YTsiz.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int CodingParameterTdy
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_cp_tdy(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_cp_tdy(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the XTOsiz.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int CodingParameterTx0
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_cp_tx0(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_cp_tx0(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the YTOsiz.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int CodingParameterTy0
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_cp_ty0(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_cp_ty0(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the coding style.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int CodingStyle
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_csty(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_csty(this.NativePtr, value);
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
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_decod_format(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_decod_format(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the subimage encoding: origin image offset in x direction.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int ImageOffsetX0
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_image_offset_x0(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_image_offset_x0(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the subimage encoding: origin image offset in y direction.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int ImageOffsetY0
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_image_offset_y0(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_image_offset_y0(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the index generation.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        [Obsolete]
        public int IndexOn
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_index_on(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_index_on(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the value to indicate whether irreversible or not for compression.
        /// </summary>
        /// <remarks><code>true</code> if use the irreversible DWT 9-7; otherwise, use lossless compression is <code>false</code>.</remarks>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public bool Irreversible
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_irreversible(this.NativePtr) == 1;
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_irreversible(this.NativePtr, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Sets or get the error protection method for Main Header (0,1,16,32,37-128).
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int JpwlHeaderProtectionMainHeader
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_jpwl_hprot_MH(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_jpwl_hprot_MH(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the sensitivity addressing size (0=auto/2/4 bytes).
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int JpwlSensitivityAddressing
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_jpwl_sens_addr(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_jpwl_sens_addr(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the sensitivity method for Main Header (-1=no,0-7).
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int JpwlSensitivityMainHeader
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_jpwl_sens_MH(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_jpwl_sens_MH(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the sensitivity range (0-3).
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int JpwlSensitivityRange
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_jpwl_sens_range(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_jpwl_sens_range(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the enables writing of ESD, (0=no/1/2 bytes).
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int JpwlSensitivitySize
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_jpwl_sens_size(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_jpwl_sens_size(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the maximum size (in bytes) for each component.
        /// </summary>
        /// <remarks>Component size limitation is not considered if 0.</remarks>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int MaximumComponentSize
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_max_comp_size(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_max_comp_size(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the maximum size (in bytes) for the whole codestream.
        /// </summary>
        /// <remarks>If 0, codestream size limitation is not considered If it does not comply with <see cref="TcpRates"/>, <see cref="MaximumCodestreamSize"/> prevails and a warning is issued.</remarks>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int MaximumCodestreamSize
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_max_cs_size(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_max_cs_size(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the mode switch (codeblock coding style).
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int Mode
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_mode(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_mode(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the number of progression order changes (POC).
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public uint NumProgressionOrderChanges
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_numpocs(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_numpocs(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the number of resolutions.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int NumResolution
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_numresolution(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_numresolution(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the progression order.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public ProgressionOrder ProgressionOrder
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_prog_order(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_prog_order(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the number of precinct size specifications.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int ResSpec
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_res_spec(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_res_spec(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the region of interest: affected component in [0..3], -1 means no ROI.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int RegionOfInterestComponent
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_roi_compno(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_roi_compno(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the region of interest: upshift value.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int RegionOfInterestShift
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_roi_shift(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_roi_shift(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the subsampling value for dx.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int SubsamplingDx
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_subsampling_dx(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_subsampling_dx(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the subsampling value for dy.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int SubsamplingDy
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_subsampling_dy(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_subsampling_dy(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the number of layers.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public int TcpNumLayers
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_tcp_numlayers(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_tcp_numlayers(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get whether enables JPIP indexing.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public bool JpipOn
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_jpip_on(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_jpip_on(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get whether enables writing of EPC in MH, thus activating JPWL.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public bool JpwlEpcOn
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_jpwl_epc_on(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_jpwl_epc_on(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the MCT (multiple component transform).
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public sbyte TcpMCT
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_tcp_mct(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_tcp_mct(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get whether enables size of tile.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public bool TileSizeOn
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_tile_size_on(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_tile_size_on(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the flag for Tile part generation.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public sbyte TilePartFlag
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_tp_flag(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_tp_flag(this.NativePtr, value);
            }
        }

        /// <summary>
        /// Sets or get the Tile part generation.
        /// </summary>
        /// <exception cref="ObjectDisposedException">This object is disposed.</exception>
        public sbyte TilePartOn
        {
            get
            {
                this.ThrowIfDisposed();
                return NativeMethods.openjpeg_openjp2_opj_cparameters_t_get_tp_on(this.NativePtr);
            }
            set
            {
                this.ThrowIfDisposed();
                NativeMethods.openjpeg_openjp2_opj_cparameters_t_set_tp_on(this.NativePtr, value);
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

            NativeMethods.openjpeg_openjp2_opj_cparameters_t_delete(this.NativePtr);
        }

        #endregion

    }

}