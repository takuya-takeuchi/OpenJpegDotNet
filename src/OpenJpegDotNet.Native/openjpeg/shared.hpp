#ifndef _CPP_SHARED_H_
#define _CPP_SHARED_H_

#define OPJ_STATIC
#include <openjpeg-2.4/openjpeg.h>

#include <cstdint>

enum struct float_types : int32_t
{
    Float = 0,
    Double,
};

#define ERR_OK                                                            0x00000000

// schedule_list
#define ERR_SCHEDULELIST_ERROR                                                0x7B000000
#define ERR_SCHEDULELIST_TYPE_NOT_SUPPORT          -(ERR_SCHEDULELIST_ERROR | 0x00000001)

// updater
#define ERR_UPDATER_ERROR                                           0x7C000000
#define ERR_UPDATER_TYPE_NOT_SUPPORT          -(ERR_UPDATER_ERROR | 0x00000001)

// ising
#define ERR_ISING_ERROR                                         0x7D000000
#define ERR_ISING_TYPE_NOT_SUPPORT          -(ERR_ISING_ERROR | 0x00000001)

// graph
#define ERR_GRAPH_ERROR                                         0x7E000000
#define ERR_GRAPH_TYPE_NOT_SUPPORT          -(ERR_GRAPH_ERROR | 0x00000001)

// float
#define ERR_FLOAT_ERROR                                         0x7F000000
#define ERR_FLOAT_TYPE_NOT_SUPPORT          -(ERR_FLOAT_ERROR | 0x00000001)

#endif