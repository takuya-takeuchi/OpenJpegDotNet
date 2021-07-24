#ifndef _CPP_OPENJPEG_OPENJP2_OPENJPEG_THREAD_H_
#define _CPP_OPENJPEG_OPENJP2_OPENJPEG_THREAD_H_

#include "../export.hpp"
#include "../shared.hpp"

DLLEXPORT const bool openjpeg_openjp2_opj_has_thread_support()
{
    return ::opj_has_thread_support() == OPJ_TRUE;
}

DLLEXPORT const int32_t openjpeg_openjp2_opj_get_num_cpus()
{
    return ::opj_get_num_cpus();
}

#endif // _CPP_OPENJPEG_OPENJP2_OPENJPEG_THREAD_H_