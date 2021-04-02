#ifndef _CPP_OPENJPEG_OPENJP2_OPENJPEG_STREAM_H_
#define _CPP_OPENJPEG_OPENJP2_OPENJPEG_STREAM_H_

#include "../export.hpp"
#include "../shared.hpp"

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

DLLEXPORT const opj_stream_t* openjpeg_openjp2_opj_stream_create_file_stream(const char *fname,
                                                                             const uint32_t fname_len,
                                                                             const uint64_t p_buffer_size,
                                                                             const bool p_is_read_stream)
{
    const auto str = std::string(fname, fname_len);
    const auto b = p_is_read_stream ? OPJ_TRUE : OPJ_FALSE; 
    return ::opj_stream_create_file_stream(str.c_str(), p_buffer_size, b);
}

#endif // _CPP_OPENJPEG_OPENJP2_OPENJPEG_STREAM_H_