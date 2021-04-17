#ifndef _CPP_OPENJPEG_OPENJP2_OPENJPEG_CODEC_COMPRESSION_H_
#define _CPP_OPENJPEG_OPENJP2_OPENJPEG_CODEC_COMPRESSION_H_

#include "../export.hpp"
#include "../shared.hpp"

#pragma region opj_cparameters_t

DLLEXPORT const void openjpeg_openjp2_opj_cparameters_t_get_tcp_distoratio(opj_cparameters_t* parameters,
                                                                           float** value,
                                                                           uint32_t* len)
{
   * value = &parameters->tcp_distoratio[0];
   * len = 100;
}

DLLEXPORT int32_t openjpeg_openjp2_opj_cparameters_t_set_tcp_distoratio(opj_cparameters_t* parameters,
                                                                        float* value,
                                                                        const uint32_t len)
{
    if (len != 100) return ERR_GENERAL_OUT_OF_RANGE;
    memcpy(parameters->tcp_distoratio, value, sizeof(float)*  100);
    return ERR_OK;
}

DLLEXPORT const void openjpeg_openjp2_opj_cparameters_t_get_tcp_rates(opj_cparameters_t* parameters,
                                                                      float** value,
                                                                      uint32_t* len)
{
   * value = &parameters->tcp_rates[0];
   * len = 100;
}

DLLEXPORT int32_t openjpeg_openjp2_opj_cparameters_t_set_tcp_rates(opj_cparameters_t* parameters,
                                                                   float* value,
                                                                   const uint32_t len)
{
    if (len != 100) return ERR_GENERAL_OUT_OF_RANGE;
    memcpy(parameters->tcp_rates, value, sizeof(float)*  100);
    return ERR_OK;
}

DLLEXPORT const void openjpeg_openjp2_opj_cparameters_t_get_POC(opj_cparameters_t* parameters,
                                                                opj_poc_t** value,
                                                                uint32_t* len)
{
   * value = &parameters->POC[0];
   * len = 32;
}

DLLEXPORT int32_t openjpeg_openjp2_opj_cparameters_t_set_POC(opj_cparameters_t* parameters,
                                                             opj_poc_t* value,
                                                             const uint32_t len)
{
    if (len != 32) return ERR_GENERAL_OUT_OF_RANGE;
    memcpy(parameters->POC, value, sizeof(opj_poc_t)*  32);
    return ERR_OK;
}

DLLEXPORT const void openjpeg_openjp2_opj_cparameters_t_get_jpwl_hprot_TPH(opj_cparameters_t* parameters,
                                                                           int** value,
                                                                           uint32_t* len)
{
   * value = &parameters->jpwl_hprot_TPH[0];
   * len = JPWL_MAX_NO_TILESPECS;
}

DLLEXPORT int32_t openjpeg_openjp2_opj_cparameters_t_set_jpwl_hprot_TPH(opj_cparameters_t* parameters,
                                                                        int* value,
                                                                        const uint32_t len)
{
    if (len != JPWL_MAX_NO_TILESPECS) return ERR_GENERAL_OUT_OF_RANGE;
    memcpy(parameters->jpwl_hprot_TPH, value, sizeof(int)*  JPWL_MAX_NO_TILESPECS);
    return ERR_OK;
}

DLLEXPORT const void openjpeg_openjp2_opj_cparameters_t_get_jpwl_hprot_TPH_tileno(opj_cparameters_t* parameters,
                                                                                  int** value,
                                                                                  uint32_t* len)
{
   * value = &parameters->jpwl_hprot_TPH_tileno[0];
   * len = JPWL_MAX_NO_TILESPECS;
}

DLLEXPORT int32_t openjpeg_openjp2_opj_cparameters_t_set_jpwl_hprot_TPH_tileno(opj_cparameters_t* parameters,
                                                                               int* value,
                                                                               const uint32_t len)
{
    if (len != JPWL_MAX_NO_TILESPECS) return ERR_GENERAL_OUT_OF_RANGE;
    memcpy(parameters->jpwl_hprot_TPH_tileno, value, sizeof(int)*  JPWL_MAX_NO_TILESPECS);
    return ERR_OK;
}

DLLEXPORT const void openjpeg_openjp2_opj_cparameters_t_get_jpwl_sens_TPH(opj_cparameters_t* parameters,
                                                                          int** value,
                                                                          uint32_t* len)
{
   * value = &parameters->jpwl_sens_TPH[0];
   * len = JPWL_MAX_NO_TILESPECS;
}

DLLEXPORT int32_t openjpeg_openjp2_opj_cparameters_t_set_jpwl_sens_TPH(opj_cparameters_t* parameters,
                                                                       int* value,
                                                                       const uint32_t len)
{
    if (len != JPWL_MAX_NO_TILESPECS) return ERR_GENERAL_OUT_OF_RANGE;
    memcpy(parameters->jpwl_sens_TPH, value, sizeof(int)*  JPWL_MAX_NO_TILESPECS);
    return ERR_OK;
}

DLLEXPORT const void openjpeg_openjp2_opj_cparameters_t_get_jpwl_sens_TPH_tileno(opj_cparameters_t* parameters,
                                                                                 int** value,
                                                                                 uint32_t* len)
{
   * value = &parameters->jpwl_sens_TPH_tileno[0];
   * len = JPWL_MAX_NO_TILESPECS;
}

DLLEXPORT int32_t openjpeg_openjp2_opj_cparameters_t_set_jpwl_sens_TPH_tileno(opj_cparameters_t* parameters,
                                                                              int* value,
                                                                              const uint32_t len)
{
    if (len != JPWL_MAX_NO_TILESPECS) return ERR_GENERAL_OUT_OF_RANGE;
    memcpy(parameters->jpwl_sens_TPH_tileno, value, sizeof(int)*  JPWL_MAX_NO_TILESPECS);
    return ERR_OK;
}

DLLEXPORT const void openjpeg_openjp2_opj_cparameters_t_get_jpwl_pprot(opj_cparameters_t* parameters,
                                                                       int** value,
                                                                       uint32_t* len)
{
   * value = &parameters->jpwl_pprot[0];
   * len = JPWL_MAX_NO_PACKSPECS;
}

DLLEXPORT int32_t openjpeg_openjp2_opj_cparameters_t_set_jpwl_pprot(opj_cparameters_t* parameters,
                                                                    int* value,
                                                                    const uint32_t len)
{
    if (len != JPWL_MAX_NO_PACKSPECS) return ERR_GENERAL_OUT_OF_RANGE;
    memcpy(parameters->jpwl_pprot, value, sizeof(int)*  JPWL_MAX_NO_PACKSPECS);
    return ERR_OK;
}

DLLEXPORT const void openjpeg_openjp2_opj_cparameters_t_get_jpwl_pprot_packno(opj_cparameters_t* parameters,
                                                                              int** value,
                                                                              uint32_t* len)
{
   * value = &parameters->jpwl_pprot_packno[0];
   * len = JPWL_MAX_NO_PACKSPECS;
}

DLLEXPORT int32_t openjpeg_openjp2_opj_cparameters_t_set_jpwl_pprot_packno(opj_cparameters_t* parameters,
                                                                           int* value,
                                                                           const uint32_t len)
{
    if (len != JPWL_MAX_NO_PACKSPECS) return ERR_GENERAL_OUT_OF_RANGE;
    memcpy(parameters->jpwl_pprot_packno, value, sizeof(int)*  JPWL_MAX_NO_PACKSPECS);
    return ERR_OK;
}

DLLEXPORT const void openjpeg_openjp2_opj_cparameters_t_get_jpwl_pprot_tileno(opj_cparameters_t* parameters,
                                                                              int** value,
                                                                              uint32_t* len)
{
   * value = &parameters->jpwl_pprot_tileno[0];
   * len = JPWL_MAX_NO_PACKSPECS;
}

DLLEXPORT int32_t openjpeg_openjp2_opj_cparameters_t_set_jpwl_pprot_tileno(opj_cparameters_t* parameters,
                                                                           int* value,
                                                                           const uint32_t len)
{
    if (len != JPWL_MAX_NO_PACKSPECS) return ERR_GENERAL_OUT_OF_RANGE;
    memcpy(parameters->jpwl_pprot_tileno, value, sizeof(int)*  JPWL_MAX_NO_PACKSPECS);
    return ERR_OK;
}

DLLEXPORT const void openjpeg_openjp2_opj_cparameters_t_get_prch_init(opj_cparameters_t* parameters,
                                                                      int** value,
                                                                      uint32_t* len)
{
   * value = &parameters->prch_init[0];
   * len = OPJ_J2K_MAXRLVLS;
}

DLLEXPORT int32_t openjpeg_openjp2_opj_cparameters_t_set_prch_init(opj_cparameters_t* parameters,
                                                                   int* value,
                                                                   const uint32_t len)
{
    if (len != OPJ_J2K_MAXRLVLS) return ERR_GENERAL_OUT_OF_RANGE;
    memcpy(parameters->prch_init, value, sizeof(int)*  OPJ_J2K_MAXRLVLS);
    return ERR_OK;
}

DLLEXPORT const void openjpeg_openjp2_opj_cparameters_t_get_prcw_init(opj_cparameters_t* parameters,
                                                                      int** value,
                                                                      uint32_t* len)
{
   * value = &parameters->prcw_init[0];
   * len = OPJ_J2K_MAXRLVLS;
}

DLLEXPORT int32_t openjpeg_openjp2_opj_cparameters_t_set_prcw_init(opj_cparameters_t* parameters,
                                                                   int* value,
                                                                   const uint32_t len)
{
    if (len != OPJ_J2K_MAXRLVLS) return ERR_GENERAL_OUT_OF_RANGE;
    memcpy(parameters->prcw_init, value, sizeof(int)*  OPJ_J2K_MAXRLVLS);
    return ERR_OK;
}

DLLEXPORT const OPJ_CINEMA_MODE openjpeg_openjp2_opj_cparameters_t_get_cp_cinema(opj_cparameters_t* parameters)
{
    return parameters->cp_cinema;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_cp_cinema(opj_cparameters_t* parameters, const OPJ_CINEMA_MODE value)
{
    parameters->cp_cinema = value;
}

DLLEXPORT const OPJ_PROG_ORDER openjpeg_openjp2_opj_cparameters_t_get_prog_order(opj_cparameters_t* parameters)
{
    return parameters->prog_order;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_prog_order(opj_cparameters_t* parameters, const OPJ_PROG_ORDER value)
{
    parameters->prog_order = value;
}

DLLEXPORT const OPJ_RSIZ_CAPABILITIES openjpeg_openjp2_opj_cparameters_t_get_cp_rsiz(opj_cparameters_t* parameters)
{
    return parameters->cp_rsiz;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_cp_rsiz(opj_cparameters_t* parameters, const OPJ_RSIZ_CAPABILITIES value)
{
    parameters->cp_rsiz = value;
}

DLLEXPORT const OPJ_UINT16 openjpeg_openjp2_opj_cparameters_t_get_rsiz(opj_cparameters_t* parameters)
{
    return parameters->rsiz;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_rsiz(opj_cparameters_t* parameters, const OPJ_UINT16 value)
{
    parameters->rsiz = value;
}

DLLEXPORT const OPJ_UINT32 openjpeg_openjp2_opj_cparameters_t_get_numpocs(opj_cparameters_t* parameters)
{
    return parameters->numpocs;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_numpocs(opj_cparameters_t* parameters, const OPJ_UINT32 value)
{
    parameters->numpocs = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_cblockh_init(opj_cparameters_t* parameters)
{
    return parameters->cblockh_init;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_cblockh_init(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->cblockh_init = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_cblockw_init(opj_cparameters_t* parameters)
{
    return parameters->cblockw_init;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_cblockw_init(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->cblockw_init = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_cod_format(opj_cparameters_t* parameters)
{
    return parameters->cod_format;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_cod_format(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->cod_format = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_cp_disto_alloc(opj_cparameters_t* parameters)
{
    return parameters->cp_disto_alloc;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_cp_disto_alloc(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->cp_disto_alloc = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_cp_fixed_alloc(opj_cparameters_t* parameters)
{
    return parameters->cp_fixed_alloc;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_cp_fixed_alloc(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->cp_fixed_alloc = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_cp_fixed_quality(opj_cparameters_t* parameters)
{
    return parameters->cp_fixed_quality;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_cp_fixed_quality(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->cp_fixed_quality = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_cp_tdx(opj_cparameters_t* parameters)
{
    return parameters->cp_tdx;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_cp_tdx(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->cp_tdx = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_cp_tdy(opj_cparameters_t* parameters)
{
    return parameters->cp_tdy;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_cp_tdy(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->cp_tdy = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_cp_tx0(opj_cparameters_t* parameters)
{
    return parameters->cp_tx0;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_cp_tx0(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->cp_tx0 = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_cp_ty0(opj_cparameters_t* parameters)
{
    return parameters->cp_ty0;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_cp_ty0(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->cp_ty0 = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_csty(opj_cparameters_t* parameters)
{
    return parameters->csty;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_csty(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->csty = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_decod_format(opj_cparameters_t* parameters)
{
    return parameters->decod_format;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_decod_format(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->decod_format = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_image_offset_x0(opj_cparameters_t* parameters)
{
    return parameters->image_offset_x0;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_image_offset_x0(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->image_offset_x0 = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_image_offset_y0(opj_cparameters_t* parameters)
{
    return parameters->image_offset_y0;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_image_offset_y0(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->image_offset_y0 = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_index_on(opj_cparameters_t* parameters)
{
    return parameters->index_on;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_index_on(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->index_on = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_irreversible(opj_cparameters_t* parameters)
{
    return parameters->irreversible;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_irreversible(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->irreversible = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_jpwl_hprot_MH(opj_cparameters_t* parameters)
{
    return parameters->jpwl_hprot_MH;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_jpwl_hprot_MH(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->jpwl_hprot_MH = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_jpwl_sens_addr(opj_cparameters_t* parameters)
{
    return parameters->jpwl_sens_addr;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_jpwl_sens_addr(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->jpwl_sens_addr = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_jpwl_sens_MH(opj_cparameters_t* parameters)
{
    return parameters->jpwl_sens_MH;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_jpwl_sens_MH(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->jpwl_sens_MH = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_jpwl_sens_range(opj_cparameters_t* parameters)
{
    return parameters->jpwl_sens_range;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_jpwl_sens_range(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->jpwl_sens_range = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_jpwl_sens_size(opj_cparameters_t* parameters)
{
    return parameters->jpwl_sens_size;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_jpwl_sens_size(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->jpwl_sens_size = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_max_comp_size(opj_cparameters_t* parameters)
{
    return parameters->max_comp_size;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_max_comp_size(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->max_comp_size = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_max_cs_size(opj_cparameters_t* parameters)
{
    return parameters->max_cs_size;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_max_cs_size(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->max_cs_size = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_mode(opj_cparameters_t* parameters)
{
    return parameters->mode;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_mode(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->mode = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_numresolution(opj_cparameters_t* parameters)
{
    return parameters->numresolution;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_numresolution(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->numresolution = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_res_spec(opj_cparameters_t* parameters)
{
    return parameters->res_spec;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_res_spec(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->res_spec = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_roi_compno(opj_cparameters_t* parameters)
{
    return parameters->roi_compno;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_roi_compno(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->roi_compno = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_roi_shift(opj_cparameters_t* parameters)
{
    return parameters->roi_shift;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_roi_shift(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->roi_shift = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_subsampling_dx(opj_cparameters_t* parameters)
{
    return parameters->subsampling_dx;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_subsampling_dx(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->subsampling_dx = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_subsampling_dy(opj_cparameters_t* parameters)
{
    return parameters->subsampling_dy;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_subsampling_dy(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->subsampling_dy = value;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_cparameters_t_get_tcp_numlayers(opj_cparameters_t* parameters)
{
    return parameters->tcp_numlayers;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_tcp_numlayers(opj_cparameters_t* parameters, const int32_t value)
{
    parameters->tcp_numlayers = value;
}

DLLEXPORT const bool openjpeg_openjp2_opj_cparameters_t_get_jpip_on(opj_cparameters_t* parameters)
{
    return parameters->jpip_on == OPJ_TRUE;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_jpip_on(opj_cparameters_t* parameters, const bool value)
{
    parameters->jpip_on = value ? OPJ_TRUE : OPJ_FALSE;
}

DLLEXPORT const bool openjpeg_openjp2_opj_cparameters_t_get_jpwl_epc_on(opj_cparameters_t* parameters)
{
    return parameters->jpwl_epc_on == OPJ_TRUE;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_jpwl_epc_on(opj_cparameters_t* parameters, const bool value)
{
    parameters->jpwl_epc_on = value ? OPJ_TRUE : OPJ_FALSE;
}

DLLEXPORT const bool openjpeg_openjp2_opj_cparameters_t_get_tile_size_on(opj_cparameters_t* parameters)
{
    return parameters->tile_size_on == OPJ_TRUE;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_tile_size_on(opj_cparameters_t* parameters, const bool value)
{
    parameters->tile_size_on = value ? OPJ_TRUE : OPJ_FALSE;
}

DLLEXPORT const int8_t openjpeg_openjp2_opj_cparameters_t_get_tcp_mct(opj_cparameters_t* parameters)
{
    return parameters->tcp_mct;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_tcp_mct(opj_cparameters_t* parameters, const int8_t value)
{
    parameters->tcp_mct = value;
}

DLLEXPORT const int8_t openjpeg_openjp2_opj_cparameters_t_get_tp_flag(opj_cparameters_t* parameters)
{
    return parameters->tp_flag;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_tp_flag(opj_cparameters_t* parameters, const int8_t value)
{
    parameters->tp_flag = value;
}

DLLEXPORT const int8_t openjpeg_openjp2_opj_cparameters_t_get_tp_on(opj_cparameters_t* parameters)
{
    return parameters->tp_on;
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_set_tp_on(opj_cparameters_t* parameters, const int8_t value)
{
    parameters->tp_on = value;
}

#pragma endregion opj_cparameters_t

#pragma region functions

DLLEXPORT const opj_codec_t* openjpeg_openjp2_opj_create_compress(const CODEC_FORMAT format)
{
    return ::opj_create_compress(format);
}

DLLEXPORT const bool openjpeg_openjp2_opj_setup_encoder(opj_codec_t* p_codec,
                                                        opj_cparameters_t* parameters,
                                                        opj_image_t* image)
{
    return ::opj_setup_encoder(p_codec, parameters, image) == OPJ_TRUE;
}

DLLEXPORT const bool openjpeg_openjp2_opj_start_compress(opj_codec_t* p_codec,
                                                         opj_image_t* p_image,
                                                         opj_stream_t* p_stream)
{
    return ::opj_start_compress(p_codec, p_image, p_stream) == OPJ_TRUE;
}

DLLEXPORT const bool openjpeg_openjp2_opj_end_compress(opj_codec_t* p_codec,
                                                       opj_stream_t* p_stream)
{
    return ::opj_end_compress(p_codec, p_stream) == OPJ_TRUE;
}

DLLEXPORT const bool openjpeg_openjp2_opj_encode(opj_codec_t* p_codec,
                                                 opj_stream_t* p_stream)
{
    return ::opj_encode(p_codec, p_stream) == OPJ_TRUE;
}

DLLEXPORT void openjpeg_openjp2_opj_set_default_encoder_parameters(opj_cparameters_t* parameters)
{
    ::opj_set_default_encoder_parameters(parameters);
}

#pragma endregion functions

#pragma region non-openjp2 functions

DLLEXPORT const opj_cparameters_t* openjpeg_openjp2_opj_cparameters_t_new()
{
    return new opj_cparameters_t();
}

DLLEXPORT void openjpeg_openjp2_opj_cparameters_t_delete(opj_cparameters_t* parameters)
{
    delete parameters;
}

#pragma endregion non-openjp2 functions

#endif // _CPP_OPENJPEG_OPENJP2_OPENJPEG_CODEC_COMPRESSION_H_