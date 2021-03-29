#ifndef _CPP_OPENJPEG_OPENJP2_OPENJPEG_CONSTANT_H_
#define _CPP_OPENJPEG_OPENJP2_OPENJPEG_CONSTANT_H_

#include "../export.hpp"
#include "../shared.hpp"

#pragma region non-openjp2 functions

DLLEXPORT const uint32_t openjpeg_openjp2_opj_get_JPWL_MAX_NO_TILESPECS()
{
    return JPWL_MAX_NO_TILESPECS;
}

DLLEXPORT const uint32_t openjpeg_openjp2_opj_get_JPWL_MAX_NO_PACKSPECS()
{
    return JPWL_MAX_NO_PACKSPECS;
}

DLLEXPORT const uint32_t openjpeg_openjp2_opj_get_JPWL_MAX_NO_MARKERS()
{
    return JPWL_MAX_NO_MARKERS;
}

DLLEXPORT const uint32_t openjpeg_openjp2_opj_get_JPWL_EXPECTED_COMPONENTS()
{
    return JPWL_EXPECTED_COMPONENTS;
}

DLLEXPORT const uint32_t openjpeg_openjp2_opj_get_JPWL_MAXIMUM_TILES()
{
    return JPWL_MAXIMUM_TILES;
}

DLLEXPORT const uint32_t openjpeg_openjp2_opj_get_JPWL_MAXIMUM_HAMMING()
{
    return JPWL_MAXIMUM_HAMMING;
}

DLLEXPORT const uint32_t openjpeg_openjp2_opj_get_JPWL_MAXIMUM_EPB_ROOM()
{
    return JPWL_MAXIMUM_EPB_ROOM;
}

#pragma endregion non-openjp2 functions

#endif // _CPP_OPENJPEG_OPENJP2_OPENJPEG_CONSTANT_H_