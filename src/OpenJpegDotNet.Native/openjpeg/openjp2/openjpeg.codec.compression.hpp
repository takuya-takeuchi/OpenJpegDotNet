#ifndef _CPP_OPENJPEG_OPENJP2_OPENJPEG_CODEC_COMPRESSION_H_
#define _CPP_OPENJPEG_OPENJP2_OPENJPEG_CODEC_COMPRESSION_H_

#include "../export.hpp"
#include "../shared.hpp"

#include <string>

#pragma region opj_cparameters_t

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