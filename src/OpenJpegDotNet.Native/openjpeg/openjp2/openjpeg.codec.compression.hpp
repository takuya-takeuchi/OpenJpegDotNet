#ifndef _CPP_OPENJPEG_OPENJP2_OPENJPEG_CODEC_COMPRESSION_H_
#define _CPP_OPENJPEG_OPENJP2_OPENJPEG_CODEC_COMPRESSION_H_

#include "../export.hpp"
#include "../shared.hpp"

#include <string>

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

#endif // _CPP_OPENJPEG_OPENJP2_OPENJPEG_CODEC_COMPRESSION_H_