#ifndef _CPP_SHARED_H_
#define _CPP_SHARED_H_

#define OPJ_STATIC
#include <openjpeg-2.4/openjpeg.h>

#include <cstdint>

#define ERR_OK                                                            0x00000000

// General
#define ERR_GENERAL_ERROR                                                 0x76000000
#define ERR_GENERAL_FILE_IO                         -(ERR_GENERAL_ERROR | 0x00000001)

// Image
#define ERR_IMAGE_ERROR                                                   0x77000000
#define ERR_IMAGE_FILE_INVALID                        -(ERR_IMAGE_ERROR | 0x00000001)
#define ERR_IMAGE_FILE_WRONG_EXTENSION                -(ERR_IMAGE_ERROR | 0x00000002)

#endif