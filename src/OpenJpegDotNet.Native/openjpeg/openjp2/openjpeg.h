#ifndef _CPP_OPENJPEG_OPENJP2_OPENJPEG_H_
#define _CPP_OPENJPEG_OPENJP2_OPENJPEG_H_

#include "../export.hpp"
#include "../shared.hpp"
#include <random>

/*
==========================================================
   openjpeg version
==========================================================
*/
DLLEXPORT std::string* openjpeg_openjp2_opj_version()
{
    const auto str = ::opj_version();
    return new std::string(str);
}

/*
==========================================================
   image functions definitions
==========================================================
*/

DLLEXPORT void openjpeg_openjp2_opj_image_destroy(opj_image_t* image)
{
    ::opj_image_destroy(image);
}

/*
==========================================================
   stream functions definitions
==========================================================
*/

DLLEXPORT void openjpeg_openjp2_opj_stream_destroy(opj_stream_t* p_stream)
{
    ::opj_stream_destroy(p_stream);
}

DLLEXPORT const opj_stream_t* openjpeg_openjp2_opj_stream_create_default_file_stream(const char *fname,
                                                                                     const uint32_t fname_len,
                                                                                     const bool p_is_read_stream)
{
    const auto str = std::string(fname, fname_len);
    const auto b = p_is_read_stream ? OPJ_TRUE : OPJ_FALSE; 
    return ::opj_stream_create_default_file_stream(str.c_str(), b);
}

/*
==========================================================
   codec functions definitions
==========================================================
*/

DLLEXPORT const opj_codec_t* openjpeg_openjp2_opj_create_decompress(const CODEC_FORMAT format)
{
    return ::opj_create_decompress(format);
}

DLLEXPORT void openjpeg_openjp2_opj_destroy_codec(opj_codec_t* p_codec)
{
    ::opj_destroy_codec(p_codec);
}

DLLEXPORT void openjpeg_openjp2_opj_set_default_decoder_parameters(opj_dparameters_t* parameters)
{
    ::opj_set_default_decoder_parameters(parameters);
}

DLLEXPORT const bool openjpeg_openjp2_opj_setup_decoder(opj_codec_t* p_codec,
                                                        opj_dparameters_t *parameters)
{
    return ::opj_setup_decoder(p_codec, parameters) == OPJ_TRUE;
}

DLLEXPORT const bool openjpeg_openjp2_opj_read_header(opj_stream_t *p_stream,
                                                      opj_codec_t *p_codec,
                                                      opj_image_t **p_image)
{
    return ::opj_read_header(p_stream, p_codec, p_image) == OPJ_TRUE;
}

/* COMPRESSION FUNCTIONS*/

DLLEXPORT const opj_codec_t* openjpeg_openjp2_opj_create_compress(const CODEC_FORMAT format)
{
    return ::opj_create_compress(format);
}

/* NOT OFFICIAL FUNCTIONS */
DLLEXPORT const opj_dparameters_t* openjpeg_openjp2_opj_opj_dparameters_t_new()
{
    return new opj_dparameters_t();
}

DLLEXPORT void openjpeg_openjp2_opj_opj_dparameters_t_delete(opj_dparameters_t* parameters)
{
    delete parameters;
}

#endif // _CPP_OPENJPEG_OPENJP2_OPENJPEG_H_