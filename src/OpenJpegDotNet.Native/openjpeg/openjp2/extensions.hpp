#ifndef _CPP_OPENJPEG_OPENJP2_EXTENSIONS_H_
#define _CPP_OPENJPEG_OPENJP2_EXTENSIONS_H_

#include "../export.hpp"
#include "../shared.hpp"

#include <string>

// https://github.com/uclouvain/openjpeg/blob/v2.4.0/src/bin/jp2/convert.c
DLLEXPORT int32_t openjpeg_openjp2_extensions_imagetobmp(opj_image_t * image,
                                                         bool big_endian,
                                                         uint8_t** planes,
                                                         uint32_t* out_w,
                                                         uint32_t* out_h,
                                                         uint32_t* out_c,
                                                         uint32_t* out_p)
{
    // FILE *rawFile = NULL;
    // size_t res;
    unsigned int compno, numcomps;
    int w, h, fails;
    int line, row, curr, mask;
    int *ptr;
    unsigned char uc;
    (void)big_endian;

    if ((image->numcomps * image->x1 * image->y1) == 0)
    {
        // fprintf(stderr, "\nError: invalid raw image parameters\n");
        return 1;
    }

    numcomps = image->numcomps;

    if (numcomps > 4)
    {
        numcomps = 4;
    }

    for (compno = 1; compno < numcomps; ++compno)
    {
        if (image->comps[0].dx != image->comps[compno].dx)
        {
            break;
        }
        if (image->comps[0].dy != image->comps[compno].dy)
        {
            break;
        }
        if (image->comps[0].prec != image->comps[compno].prec)
        {
            break;
        }
        if (image->comps[0].sgnd != image->comps[compno].sgnd)
        {
            break;
        }
    }

    if (compno != numcomps)
    {
        // fprintf(stderr, "imagetoraw_common: All components shall have the same subsampling, same bit depth, same sign.\n");
        // fprintf(stderr, "\tAborting\n");
        return 1;
    }

    if (image->comps[0].prec <= 8)
    {
        *out_w = image->comps[0].w;
        *out_h = image->comps[0].h;
        *out_c = compno;
        *out_p = 8;
    }
    else if (image->comps[compno].prec <= 16)
    {
        *out_w = image->comps[0].w;
        *out_h = image->comps[0].h;
        *out_c = compno;
        *out_p = 16;
    }
    else
    {
        goto fin;
    }

    auto buf = (uint8_t*)calloc(*out_c, *out_w * *out_h * compno);
    *planes = buf;
    size_t cur_buf = 0;

    // rawFile = fopen(outfile, "wb");
    // if (!rawFile)
    // {
    //     // fprintf(stderr, "Failed to open %s for writing !!\n", outfile);
    //     return 1;
    // }

    fails = 1;
    // fprintf(stdout, "Raw image characteristics: %d components\n", image->numcomps);

    for (compno = 0; compno < image->numcomps; compno++)
    {
        // fprintf(stdout, "Component %u characteristics: %dx%dx%d %s\n", compno,
        //         image->comps[compno].w,
        //         image->comps[compno].h, image->comps[compno].prec,
        //         image->comps[compno].sgnd == 1 ? "signed" : "unsigned");

        w = (int)image->comps[compno].w;
        h = (int)image->comps[compno].h;

        if (image->comps[compno].prec <= 8)
        {
            if (image->comps[compno].sgnd == 1)
            {
                mask = (1 << image->comps[compno].prec) - 1;
                ptr = image->comps[compno].data;
                for (line = 0; line < h; line++)
                {
                    for (row = 0; row < w; row++)
                    {
                        curr = *ptr;
                        if (curr > 127)
                        {
                            curr = 127;
                        }
                        else if (curr < -128)
                        {
                            curr = -128;
                        }
                        uc = (unsigned char)(curr & mask);
                        // res = fwrite(&uc, 1, 1, rawFile);
                        buf[cur_buf++] = uc;
                        // if (res < 1)
                        // {
                        //     fprintf(stderr, "failed to write 1 byte for %s\n", outfile);
                        //     goto fin;
                        // }
                        ptr++;
                    }
                }
            }
            else if (image->comps[compno].sgnd == 0)
            {
                mask = (1 << image->comps[compno].prec) - 1;
                ptr = image->comps[compno].data;
                for (line = 0; line < h; line++)
                {
                    for (row = 0; row < w; row++)
                    {
                        curr = *ptr;
                        if (curr > 255)
                        {
                            curr = 255;
                        }
                        else if (curr < 0)
                        {
                            curr = 0;
                        }
                        uc = (unsigned char)(curr & mask);
                        buf[cur_buf++] = uc;
                        // res = fwrite(&uc, 1, 1, rawFile);
                        // if (res < 1)
                        // {
                        //     fprintf(stderr, "failed to write 1 byte for %s\n", outfile);
                        //     goto fin;
                        // }
                        ptr++;
                    }
                }
            }
        }
        else if (image->comps[compno].prec <= 16)
        {
            if (image->comps[compno].sgnd == 1)
            {
                union {
                    signed short val;
                    signed char vals[2];
                } uc16;
                mask = (1 << image->comps[compno].prec) - 1;
                ptr = image->comps[compno].data;
                for (line = 0; line < h; line++)
                {
                    for (row = 0; row < w; row++)
                    {
                        curr = *ptr;
                        if (curr > 32767)
                        {
                            curr = 32767;
                        }
                        else if (curr < -32768)
                        {
                            curr = -32768;
                        }
                        uc16.val = (signed short)(curr & mask);
                        // res = fwrite(uc16.vals, 1, 2, rawFile);
                        buf[cur_buf++] = uc16.vals[0];
                        buf[cur_buf++] = uc16.vals[1];
                        // if (res < 2)
                        // {
                        //     fprintf(stderr, "failed to write 2 byte for %s\n", outfile);
                        //     goto fin;
                        // }
                        ptr++;
                    }
                }
            }
            else if (image->comps[compno].sgnd == 0)
            {
                union {
                    unsigned short val;
                    unsigned char vals[2];
                } uc16;
                mask = (1 << image->comps[compno].prec) - 1;
                ptr = image->comps[compno].data;
                for (line = 0; line < h; line++)
                {
                    for (row = 0; row < w; row++)
                    {
                        curr = *ptr;
                        if (curr > 65535)
                        {
                            curr = 65535;
                        }
                        else if (curr < 0)
                        {
                            curr = 0;
                        }
                        uc16.val = (unsigned short)(curr & mask);
                        // res = fwrite(uc16.vals, 1, 2, rawFile);
                        buf[cur_buf++] = uc16.vals[0];
                        buf[cur_buf++] = uc16.vals[1];
                        // if (res < 2)
                        // {
                        //     fprintf(stderr, "failed to write 2 byte for %s\n", outfile);
                        //     goto fin;
                        // }
                        ptr++;
                    }
                }
            }
        }
        else if (image->comps[compno].prec <= 32)
        {
            // fprintf(stderr, "More than 16 bits per component not handled yet\n");
            goto fin;
        }
        else
        {
            // fprintf(stderr, "Error: invalid precision: %d\n", image->comps[compno].prec);
            goto fin;
        }
    }
    fails = 0;
fin:
    // fclose(rawFile);
    return fails;
}

#endif // _CPP_OPENJPEG_OPENJP2_OBJ_DECOMPRESS_H_