#ifndef _CPP_OPENJPEG_OPENJP2_OPENJPEG_EVENT_H_
#define _CPP_OPENJPEG_OPENJP2_OPENJPEG_EVENT_H_

#include "../export.hpp"
#include "../shared.hpp"

DLLEXPORT void openjpeg_openjp2_opj_set_info_handler(opj_codec_t * p_codec,
                                                     const opj_msg_callback p_function,
                                                     void * p_user_data)
{
    ::opj_set_info_handler(p_codec, p_function, p_user_data);
}

DLLEXPORT void openjpeg_openjp2_opj_set_warning_handler(opj_codec_t * p_codec,
                                                        const opj_msg_callback p_function,
                                                        void * p_user_data)
{
    ::opj_set_warning_handler(p_codec, p_function, p_user_data);
}

DLLEXPORT void openjpeg_openjp2_opj_set_error_handler(opj_codec_t * p_codec,
                                                      const opj_msg_callback p_function,
                                                      void * p_user_data)
{
    ::opj_set_error_handler(p_codec, p_function, p_user_data);
}

#endif // _CPP_OPENJPEG_OPENJP2_OPENJPEG_EVENT_H_