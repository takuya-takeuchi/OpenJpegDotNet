#ifndef _CPP_OPENJPEG_OPENJP2_OPENJPEG_MCT_H_
#define _CPP_OPENJPEG_OPENJP2_OPENJPEG_MCT_H_

#include "../export.hpp"
#include "../shared.hpp"

#include <string>

DLLEXPORT bool openjpeg_openjp2_opj_set_MCT(opj_cparameters_t* parameters,
                                            OPJ_FLOAT32* pEncodingMatrix,
                                            OPJ_INT32* p_dc_shift,
                                            const OPJ_UINT32 pNbComp)
{
    return ::opj_set_MCT(parameters, pEncodingMatrix, p_dc_shift, pNbComp);
}

#endif // _CPP_OPENJPEG_OPENJP2_OPENJPEG_MCT_H_