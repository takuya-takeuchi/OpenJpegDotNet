#ifndef _CPP_OPENJPEG_OPENJP2_OPENJPEG_MCT_H_
#define _CPP_OPENJPEG_OPENJP2_OPENJPEG_MCT_H_

#include "../export.hpp"
#include "../shared.hpp"

#include <string>

DLLEXPORT bool openjpeg_openjp2_opj_set_MCT(opj_cparameters_t* parameters,
                                            float* pEncodingMatrix,
                                            int32_t* p_dc_shift,
                                            const uint32_t pNbComp)
{
    return ::opj_set_MCT(parameters, pEncodingMatrix, p_dc_shift, pNbComp);
}

#endif // _CPP_OPENJPEG_OPENJP2_OPENJPEG_MCT_H_