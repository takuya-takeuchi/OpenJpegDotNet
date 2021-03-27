#ifndef _CPP_OPENJPEG_OPENJP2_OPENJPEG_IMAGE_H_
#define _CPP_OPENJPEG_OPENJP2_OPENJPEG_IMAGE_H_

#include "../export.hpp"
#include "../shared.hpp"

#include <string>

#pragma region opj_image_t

DLLEXPORT const OPJ_UINT32 openjpeg_openjp2_opj_image_get_x0(opj_image* image)
{
    return image->x0;
}

DLLEXPORT const OPJ_UINT32 openjpeg_openjp2_opj_image_get_y0(opj_image* image)
{
    return image->y0;
}

DLLEXPORT const OPJ_UINT32 openjpeg_openjp2_opj_image_get_x1(opj_image* image)
{
    return image->x1;
}

DLLEXPORT const OPJ_UINT32 openjpeg_openjp2_opj_image_get_y1(opj_image* image)
{
    return image->y1;
}

DLLEXPORT const OPJ_UINT32 openjpeg_openjp2_opj_image_get_numcomps(opj_image* image)
{
    return image->numcomps;
}
DLLEXPORT const OPJ_COLOR_SPACE openjpeg_openjp2_opj_image_get_color_space(opj_image* image)
{
    return image->color_space;
}

DLLEXPORT const opj_image_comp_t* openjpeg_openjp2_opj_image_get_comps(opj_image* image)
{
    return image->comps;
}

DLLEXPORT const OPJ_BYTE* openjpeg_openjp2_opj_image_get_icc_profile_buf(opj_image* image)
{
    return image->icc_profile_buf;
}

DLLEXPORT const OPJ_UINT32 openjpeg_openjp2_opj_image_get_icc_profile_len(opj_image* image)
{
    return image->icc_profile_len;
}

#pragma endregion opj_image_t

DLLEXPORT void openjpeg_openjp2_opj_image_destroy(opj_image_t* image)
{
    ::opj_image_destroy(image);
}

#endif // _CPP_OPENJPEG_OPENJP2_OPENJPEG_IMAGE_H_