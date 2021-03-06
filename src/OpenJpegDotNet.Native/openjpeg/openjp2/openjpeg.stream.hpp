#ifndef _CPP_OPENJPEG_OPENJP2_OPENJPEG_STREAM_H_
#define _CPP_OPENJPEG_OPENJP2_OPENJPEG_STREAM_H_

#include "../export.hpp"
#include "../shared.hpp"

DLLEXPORT void openjpeg_openjp2_opj_stream_destroy(opj_stream_t* p_stream)
{
    ::opj_stream_destroy(p_stream);
}

DLLEXPORT const opj_stream_t* openjpeg_openjp2_opj_stream_default_create(const bool p_is_read_stream)
{
    const auto b = p_is_read_stream ? OPJ_TRUE : OPJ_FALSE;
    return ::opj_stream_default_create(b);
}

DLLEXPORT const opj_stream_t* openjpeg_openjp2_opj_stream_create(const uint64_t p_buffer_size,
                                                                 const bool p_is_read_stream)
{
    const auto b = p_is_read_stream ? OPJ_TRUE : OPJ_FALSE;
    return ::opj_stream_create(p_buffer_size, b);
}

DLLEXPORT void openjpeg_openjp2_opj_stream_set_read_function(opj_stream_t* p_stream,
                                                             const opj_stream_read_fn p_function)
{
    ::opj_stream_set_read_function(p_stream, p_function);
}

DLLEXPORT void openjpeg_openjp2_opj_stream_set_write_function(opj_stream_t* p_stream,
                                                              const opj_stream_write_fn p_function)
{
    ::opj_stream_set_write_function(p_stream, p_function);
}

DLLEXPORT void openjpeg_openjp2_opj_stream_set_skip_function(opj_stream_t* p_stream,
                                                             const opj_stream_skip_fn p_function)
{
    ::opj_stream_set_skip_function(p_stream, p_function);
}

DLLEXPORT void openjpeg_openjp2_opj_stream_set_seek_function(opj_stream_t* p_stream,
                                                             const opj_stream_seek_fn p_function)
{
    ::opj_stream_set_seek_function(p_stream, p_function);
}

DLLEXPORT void openjpeg_openjp2_opj_stream_set_user_data(opj_stream_t* p_stream,
                                                         void* p_data,
                                                         const opj_stream_free_user_data_fn p_function)
{
    ::opj_stream_set_user_data(p_stream, p_data, p_function);
}

DLLEXPORT void openjpeg_openjp2_opj_stream_set_user_data_length(opj_stream_t* p_stream,
                                                                const uint64_t data_length)
{
    ::opj_stream_set_user_data_length(p_stream, data_length);
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