#ifndef _CPP_OPENJPEG_OPENJP2_OPENJPEG_IMAGE_H_
#define _CPP_OPENJPEG_OPENJP2_OPENJPEG_IMAGE_H_

#include "../export.hpp"
#include "../shared.hpp"

#pragma region opj_image_t

DLLEXPORT const uint32_t openjpeg_openjp2_opj_image_t_get_x0(opj_image_t* image)
{
    return image->x0;
}

DLLEXPORT void openjpeg_openjp2_opj_image_t_set_x0(opj_image_t* image, const uint32_t value)
{
    image->x0 = value;
}

DLLEXPORT const uint32_t openjpeg_openjp2_opj_image_t_get_y0(opj_image_t* image)
{
    return image->y0;
}

DLLEXPORT void openjpeg_openjp2_opj_image_t_set_y0(opj_image_t* image, const uint32_t value)
{
    image->y0 = value;
}

DLLEXPORT const uint32_t openjpeg_openjp2_opj_image_t_get_x1(opj_image_t* image)
{
    return image->x1;
}

DLLEXPORT void openjpeg_openjp2_opj_image_t_set_x1(opj_image_t* image, const uint32_t value)
{
    image->x1 = value;
}

DLLEXPORT const uint32_t openjpeg_openjp2_opj_image_t_get_y1(opj_image_t* image)
{
    return image->y1;
}

DLLEXPORT void openjpeg_openjp2_opj_image_t_set_y1(opj_image_t* image, const uint32_t value)
{
    image->y1 = value;
}

DLLEXPORT const uint32_t openjpeg_openjp2_opj_image_t_get_numcomps(opj_image_t* image)
{
    return image->numcomps;
}

DLLEXPORT void openjpeg_openjp2_opj_image_t_set_numcomps(opj_image_t* image, const uint32_t value)
{
    image->numcomps = value;
}

DLLEXPORT const OPJ_COLOR_SPACE openjpeg_openjp2_opj_image_t_get_color_space(opj_image_t* image)
{
    return image->color_space;
}

DLLEXPORT void openjpeg_openjp2_opj_image_t_set_color_space(opj_image_t* image, const OPJ_COLOR_SPACE value)
{
    image->color_space = value;
}

DLLEXPORT const opj_image_comp_t* openjpeg_openjp2_opj_image_t_get_comps(opj_image_t* image)
{
    return image->comps;
}

DLLEXPORT const OPJ_BYTE* openjpeg_openjp2_opj_image_t_get_icc_profile_buf(opj_image_t* image)
{
    return image->icc_profile_buf;
}

DLLEXPORT const uint32_t openjpeg_openjp2_opj_image_t_get_icc_profile_len(opj_image_t* image)
{
    return image->icc_profile_len;
}

#pragma endregion opj_image_t

#pragma region opj_image_cmptparm_t

DLLEXPORT const uint32_t openjpeg_openjp2_opj_image_cmptparm_t_get_dx(opj_image_cmptparm_t* parameters)
{
    return parameters->dx;
}

DLLEXPORT void openjpeg_openjp2_opj_image_cmptparm_t_set_dx(opj_image_cmptparm_t* parameters, const uint32_t value)
{
    parameters->dx = value;
}

DLLEXPORT const uint32_t openjpeg_openjp2_opj_image_cmptparm_t_get_dy(opj_image_cmptparm_t* parameters)
{
    return parameters->dy;
}

DLLEXPORT void openjpeg_openjp2_opj_image_cmptparm_t_set_dy(opj_image_cmptparm_t* parameters, const uint32_t value)
{
    parameters->dy = value;
}

DLLEXPORT const uint32_t openjpeg_openjp2_opj_image_cmptparm_t_get_w(opj_image_cmptparm_t* parameters)
{
    return parameters->w;
}

DLLEXPORT void openjpeg_openjp2_opj_image_cmptparm_t_set_w(opj_image_cmptparm_t* parameters, const uint32_t value)
{
    parameters->w = value;
}

DLLEXPORT const uint32_t openjpeg_openjp2_opj_image_cmptparm_t_get_h(opj_image_cmptparm_t* parameters)
{
    return parameters->h;
}

DLLEXPORT void openjpeg_openjp2_opj_image_cmptparm_t_set_h(opj_image_cmptparm_t* parameters, const uint32_t value)
{
    parameters->h = value;
}

DLLEXPORT const uint32_t openjpeg_openjp2_opj_image_cmptparm_t_get_x0(opj_image_cmptparm_t* parameters)
{
    return parameters->x0;
}

DLLEXPORT void openjpeg_openjp2_opj_image_cmptparm_t_set_x0(opj_image_cmptparm_t* parameters, const uint32_t value)
{
    parameters->x0 = value;
}

DLLEXPORT const uint32_t openjpeg_openjp2_opj_image_cmptparm_t_get_y0(opj_image_cmptparm_t* parameters)
{
    return parameters->y0;
}

DLLEXPORT void openjpeg_openjp2_opj_image_cmptparm_t_set_y0(opj_image_cmptparm_t* parameters, const uint32_t value)
{
    parameters->y0 = value;
}

DLLEXPORT const uint32_t openjpeg_openjp2_opj_image_cmptparm_t_get_prec(opj_image_cmptparm_t* parameters)
{
    return parameters->prec;
}

DLLEXPORT void openjpeg_openjp2_opj_image_cmptparm_t_set_prec(opj_image_cmptparm_t* parameters, const uint32_t value)
{
    parameters->prec = value;
}

DLLEXPORT const uint32_t openjpeg_openjp2_opj_image_cmptparm_t_get_bpp(opj_image_cmptparm_t* parameters)
{
    return parameters->bpp;
}

DLLEXPORT void openjpeg_openjp2_opj_image_cmptparm_t_set_bpp(opj_image_cmptparm_t* parameters, const uint32_t value)
{
    parameters->bpp = value;
}

DLLEXPORT const uint32_t openjpeg_openjp2_opj_image_cmptparm_t_get_sgnd(opj_image_cmptparm_t* parameters)
{
    return parameters->sgnd;
}

DLLEXPORT void openjpeg_openjp2_opj_image_cmptparm_t_set_sgnd(opj_image_cmptparm_t* parameters, const uint32_t value)
{
    parameters->sgnd = value;
}

#pragma endregion opj_image_cmptparm_t

DLLEXPORT void openjpeg_openjp2_opj_image_t_destroy(opj_image_t* image)
{
    ::opj_image_destroy(image);
}

DLLEXPORT const opj_image_t* openjpeg_openjp2_opj_image_tile_create(const uint32_t numcmpts,
                                                                    opj_image_cmptparm_t** cmptparms,
                                                                    const uint32_t cmptparms_len,
                                                                    const OPJ_COLOR_SPACE clrspc)
{
    auto tmp = std::vector<opj_image_cmptparm_t>(cmptparms_len);
    for (auto index = 0; index < cmptparms_len; index++) tmp[index] = (*cmptparms[index]);
    const auto ret = ::opj_image_tile_create(numcmpts, tmp.data(), clrspc);
    return ret;
}

#pragma region non-openjp2 functions

DLLEXPORT const opj_image_cmptparm_t* openjpeg_openjp2_opj_image_cmptparm_t_new()
{
    return new opj_image_cmptparm_t();
}

DLLEXPORT void openjpeg_openjp2_opj_image_cmptparm_t_delete(opj_image_cmptparm_t* parameters)
{
    delete parameters;
}

#pragma endregion non-openjp2 functions

#endif // _CPP_OPENJPEG_OPENJP2_OPENJPEG_IMAGE_H_