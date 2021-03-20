#ifndef _CPP_OPENJPEG_OPENJP2_OBJ_DECOMPRESS_H_
#define _CPP_OPENJPEG_OPENJP2_OBJ_DECOMPRESS_H_

#include "../export.hpp"
#include "../shared.hpp"

#include <string>

#ifdef _WIN32
#include <windows.h>
#define strcasecmp _stricmp
#define strncasecmp _strnicmp
#else
#include <strings.h>
#include <sys/time.h>
#include <sys/resource.h>
#include <sys/times.h>
#endif /* _WIN32 */

// https://github.com/uclouvain/openjpeg/blob/version.2.1/src/bin/common/format_defs.h
#ifndef _OPJ_FORMAT_DEFS_H_
#define _OPJ_FORMAT_DEFS_H_

#define J2K_CFMT 0
#define JP2_CFMT 1
#define JPT_CFMT 2

#define PXM_DFMT 10
#define PGX_DFMT 11
#define BMP_DFMT 12
#define YUV_DFMT 13
#define TIF_DFMT 14
#define RAW_DFMT 15 /* MSB / Big Endian */
#define TGA_DFMT 16
#define PNG_DFMT 17
#define RAWL_DFMT 18 /* LSB / Little Endian */

#endif /* _OPJ_FORMAT_DEFS_H_ */

// https://github.com/uclouvain/openjpeg/blob/v2.4.0/src/bin/jp2/opj_decompress.c#L427
int get_file_format(const char *filename)
{
    unsigned int i;
    static const char *extension[] = {"pgx", "pnm", "pgm", "ppm", "bmp", "tif", "raw", "rawl", "tga", "png", "j2k", "jp2", "jpt", "j2c", "jpc" };
    static const int format[] = { PGX_DFMT, PXM_DFMT, PXM_DFMT, PXM_DFMT, BMP_DFMT, TIF_DFMT, RAW_DFMT, RAWL_DFMT, TGA_DFMT, PNG_DFMT, J2K_CFMT, JP2_CFMT, JPT_CFMT, J2K_CFMT, J2K_CFMT };
    const char * ext = strrchr(filename, '.');
    if (ext == NULL) {
        return -1;
    }
    ext++;
    if (*ext) {
        for (i = 0; i < sizeof(format) / sizeof(*format); i++) {
            if (strcasecmp(ext, extension[i]) == 0) {
                return format[i];
            }
        }
    }

    return -1;
}

// https://github.com/uclouvain/openjpeg/blob/v2.4.0/src/bin/jp2/opj_decompress.c#L493
#define JP2_RFC3745_MAGIC "\x00\x00\x00\x0c\x6a\x50\x20\x20\x0d\x0a\x87\x0a"
#define JP2_MAGIC "\x0d\x0a\x87\x0a"
/* position 45: "\xff\x52" */
#define J2K_CODESTREAM_MAGIC "\xff\x4f\xff\x51"

DLLEXPORT int32_t openjpeg_openjp2_infile_format(const char *fname,
                                                 const uint32_t fname_len,
                                                 int32_t* format)
{
    FILE *reader;
    const char *s, *magic_s;
    int ext_format, magic_format;
    unsigned char buf[12];
    OPJ_SIZE_T l_nb_read;

    std::string str(fname, fname_len);
    reader = fopen(str.c_str(), "rb");

    if (reader == NULL) {
        return ERR_GENERAL_FILE_IO;
    }

    memset(buf, 0, 12);
    l_nb_read = fread(buf, 1, 12, reader);
    fclose(reader);
    if (l_nb_read != 12) {
        return ERR_IMAGE_FILE_INVALID;
    }

    ext_format = get_file_format(fname);

    if (ext_format == JPT_CFMT) {
        return JPT_CFMT;
    }

    if (memcmp(buf, JP2_RFC3745_MAGIC, 12) == 0 || memcmp(buf, JP2_MAGIC, 4) == 0) {
        magic_format = JP2_CFMT;
        magic_s = ".jp2";
    } else if (memcmp(buf, J2K_CODESTREAM_MAGIC, 4) == 0) {
        magic_format = J2K_CFMT;
        magic_s = ".j2k or .jpc or .j2c";
    } else {
        return ERR_IMAGE_FILE_INVALID;
    }

    if (magic_format == ext_format) {
        *format = ext_format;
        return ERR_OK;
    }

    // s = fname + strlen(fname) - 4;

    // fputs("\n===========================================\n", stderr);
    // fprintf(stderr, "The extension of this file is incorrect.\n"
    //         "FOUND %s. SHOULD BE %s\n", s, magic_s);
    // fputs("===========================================\n", stderr);

    return ERR_IMAGE_FILE_WRONG_EXTENSION;
}

#endif // _CPP_OPENJPEG_OPENJP2_OBJ_DECOMPRESS_H_