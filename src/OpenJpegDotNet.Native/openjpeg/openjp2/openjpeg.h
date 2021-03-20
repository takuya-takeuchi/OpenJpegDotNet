#ifndef _CPP_OPENJPEG_OPENJP2_OPENJPEG_H_
#define _CPP_OPENJPEG_OPENJP2_OPENJPEG_H_

#include "../export.hpp"
#include "../shared.hpp"
#include <random>

DLLEXPORT const char* openjpeg_openjp2_opj_version()
{
    return ::opj_version();
}

#endif // _CPP_OPENJPEG_OPENJP2_OPENJPEG_H_