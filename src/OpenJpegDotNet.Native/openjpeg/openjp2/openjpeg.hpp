#ifndef _CPP_OPENJPEG_OPENJP2_OPENJPEG_H_
#define _CPP_OPENJPEG_OPENJP2_OPENJPEG_H_

#include "../export.hpp"
#include "../shared.hpp"

DLLEXPORT std::string* openjpeg_openjp2_opj_version()
{
    const auto str = ::opj_version();
    return new std::string(str);
}

#endif // _CPP_OPENJPEG_OPENJP2_OPENJPEG_H_