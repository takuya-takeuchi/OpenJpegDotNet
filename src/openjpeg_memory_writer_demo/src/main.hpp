#include <openjpeg-2.4/openjpeg.h>

#include <cstdint>
#include <string>
#include <iostream>
#include <fstream>
#include <string.h>
#include <vector>

struct DecodeData
{
public:
    DecodeData(unsigned char* src_data, OPJ_SIZE_T src_size) :
        src_data(src_data), src_size(src_size), offset(0) {
    }
    unsigned char* src_data;
    OPJ_SIZE_T     src_size;
    OPJ_SIZE_T     offset;
};

opj_stream_t* OPJ_CALLCONV opj_stream_create_memory_stream(DecodeData* p_mem, OPJ_INT32 p_size, bool p_is_read_stream);
void msg_callback(const char* msg, void* f);

OPJ_SIZE_T opj_read_from_memory(void * p_buffer, OPJ_SIZE_T p_nb_bytes, DecodeData* p_file);
OPJ_SIZE_T opj_write_to_memory (void * p_buffer, OPJ_SIZE_T p_nb_bytes, DecodeData* p_file);
OPJ_OFF_T opj_skip_from_memory (OPJ_OFF_T p_nb_bytes, DecodeData * p_file);
OPJ_BOOL opj_seek_from_memory (OPJ_OFF_T p_nb_bytes, DecodeData * p_file);

OPJ_SIZE_T opj_read_from_memory(void * p_buffer, OPJ_SIZE_T nb_bytes, DecodeData* p_user_data)
{
    if (!p_user_data || !p_user_data->src_data || p_user_data->src_size == 0) {
        return -1;
    }
    // Reads at EOF return an error code.
    if (p_user_data->offset >= p_user_data->src_size) {
        return -1;
    }
    OPJ_SIZE_T bufferLength = p_user_data->src_size - p_user_data->offset;
    OPJ_SIZE_T readlength = nb_bytes < bufferLength ? nb_bytes : bufferLength;
    memcpy(p_buffer, &p_user_data->src_data[p_user_data->offset], readlength);
    p_user_data->offset += readlength;
    return readlength;
}

OPJ_SIZE_T opj_write_to_memory (void * p_buffer, OPJ_SIZE_T nb_bytes, DecodeData* p_user_data)
{
    std::cout << "[Info] opj_write_to_memory: nb_bytes=" << nb_bytes << std::endl;
    if (!p_user_data || !p_user_data->src_data || p_user_data->src_size == 0) {
        return -1;
    }
    // Writes at EOF return an error code.
    if (p_user_data->offset >= p_user_data->src_size) {
        return -1;
    }
    OPJ_SIZE_T bufferLength = p_user_data->src_size - p_user_data->offset;
    OPJ_SIZE_T writeLength = nb_bytes < bufferLength ? nb_bytes : bufferLength;
    memcpy(&p_user_data->src_data[p_user_data->offset], p_buffer, writeLength);
    p_user_data->offset += writeLength;
    return writeLength;
}

OPJ_OFF_T opj_skip_from_memory (OPJ_OFF_T nb_bytes, DecodeData * p_user_data)
{
    std::cout << "[Info] opj_skip_from_memory: nb_bytes=" << nb_bytes << std::endl;
    if (!p_user_data || !p_user_data->src_data || p_user_data->src_size == 0) {
        return -1;
    }
    // Offsets are signed and may indicate a negative skip. Do not support this
    // because of the strange return convention where either bytes skipped or
    // -1 is returned. Following that convention, a successful relative seek of
    // -1 bytes would be required to to give the same result as the error case.
    if (nb_bytes < 0) {
        return -1;
    }

	// check overflow
	if (/* (nb_bytes > 0) && */(p_user_data->offset > std::numeric_limits<OPJ_SIZE_T>::max() - nb_bytes))
		return -1;

	OPJ_SIZE_T newoffset = p_user_data->offset + nb_bytes;

	// skipped past eof?
	if(newoffset > p_user_data->src_size) {
		// number of actual skipped bytes
		nb_bytes = p_user_data->src_size - p_user_data->offset;
		p_user_data->offset = p_user_data->src_size;
	}
	else {
		p_user_data->offset = newoffset;
	}
	return nb_bytes;
}

OPJ_BOOL opj_seek_from_memory (OPJ_OFF_T nb_bytes, DecodeData * p_user_data)
{
    std::cout << "[Info] opj_seek_from_memory: nb_bytes=" << nb_bytes << std::endl;
    if (!p_user_data || !p_user_data->src_data || p_user_data->src_size == 0) {
        return OPJ_FALSE;
    }

	// backwards?
	if(nb_bytes < 0)
		return OPJ_FALSE;

	p_user_data->offset = std::min((OPJ_SIZE_T) nb_bytes, p_user_data->src_size);
    return OPJ_TRUE;
}

opj_stream_t* OPJ_CALLCONV opj_stream_create_memory_stream(DecodeData* p_mem,OPJ_INT32 p_size, bool p_is_read_stream)
{
	opj_stream_t* l_stream = NULL;
	if (! p_mem)
		return NULL;

	l_stream = opj_stream_create(p_size,p_is_read_stream);
	if (!l_stream)
		return NULL;

	opj_stream_set_user_data(l_stream, p_mem, NULL);
	opj_stream_set_user_data_length(l_stream, p_mem->src_size);
	opj_stream_set_read_function(l_stream,(opj_stream_read_fn) opj_read_from_memory);
	opj_stream_set_write_function(l_stream, (opj_stream_write_fn) opj_write_to_memory);
	opj_stream_set_skip_function(l_stream, (opj_stream_skip_fn) opj_skip_from_memory);
	opj_stream_set_seek_function(l_stream, (opj_stream_seek_fn) opj_seek_from_memory);
	return l_stream;
}

void msg_callback(const char* msg, void* f)
{
    std::cout << msg << std::endl;
}

bool frametoimage(const uint8_t *framePointer,
                  const bool planarConfiguration,
                  COLOR_SPACE photometricInterpretation,
                  const int samplesPerPixel,
                  const int width,
                  const int height,
                  const int bitsAllocated,
                  const bool isSigned,
                  opj_cparameters_t *parameters,
                  opj_image_t **ret_image)
{
	uint8_t bytesAllocated = bitsAllocated / 8;
	// uint32_t PixelWidth = bytesAllocated * samplesPerPixel;

	if (bitsAllocated % 8 != 0)
		return false;

	opj_image_t *image = NULL;
	opj_image_cmptparm_t *cmptparm = new opj_image_cmptparm_t[samplesPerPixel];
	memset(cmptparm, 0, samplesPerPixel * sizeof(opj_image_cmptparm_t));

	int subsampling_dx = parameters->subsampling_dx;
	int subsampling_dy = parameters->subsampling_dy;

	for (int i = 0; i < samplesPerPixel; i++)
	{
		cmptparm[i].prec = bitsAllocated;
		cmptparm[i].bpp = bitsAllocated;
		cmptparm[i].sgnd = (isSigned) ? 1 : 0;
		cmptparm[i].dx = (OPJ_INT32)subsampling_dx;
		cmptparm[i].dy = (OPJ_INT32)subsampling_dy;
		cmptparm[i].w = width;
		cmptparm[i].h = height;
	}

	COLOR_SPACE colorspace = photometricInterpretation;

	image = opj_image_create(samplesPerPixel, cmptparm, colorspace);

	// set image offset and reference grid
	image->x0 = (OPJ_INT32)parameters->image_offset_x0;
	image->y0 = (OPJ_INT32)parameters->image_offset_y0;
	image->x1 =	!image->x0 ? (OPJ_INT32)(width - 1)  * (OPJ_INT32)subsampling_dx + 1 : image->x0 + (OPJ_INT32)(width - 1)  * (OPJ_INT32)subsampling_dx + 1;
	image->y1 =	!image->y0 ? (OPJ_INT32)(height - 1) * (OPJ_INT32)subsampling_dy + 1 : image->y0 + (OPJ_INT32)(height - 1) * (OPJ_INT32)subsampling_dy + 1;

	if(bytesAllocated == 1)
	{
		if(planarConfiguration == false)
		{
			for(int i = 0; i < samplesPerPixel; i++)
		    {
				OPJ_INT32 *target = image->comps[i].data;
				const uint8_t *source = &framePointer[i * bytesAllocated];
				for (unsigned int pos = 0; pos < height * width; pos++)
				{
					*target = (isSigned) ? (int8_t) *source : *source;
					target++;
					source += samplesPerPixel;
				}
			}
		}
		else
		{
			for(int i = 0; i < samplesPerPixel; i++)
		    {
				OPJ_INT32 *target = image->comps[i].data;
				const uint8_t *source = &framePointer[i * height * width * bytesAllocated];
				for (unsigned int pos = 0; pos < height * width; pos++)
				{
					*target =  (isSigned) ? (int8_t) *source : *source;
					target++;
					source++;
				}
			}
		}
	}
	else if(bytesAllocated == 2)
	{
		if(planarConfiguration == false)
		{
			for(int i = 0; i < samplesPerPixel; i++)
		    {
				OPJ_INT32 *target = image->comps[i].data;
				const uint16_t *source = (uint16_t *) &framePointer[i * bytesAllocated];
				for (unsigned int pos = 0; pos < height * width; pos++)
				{
					*target =  (isSigned) ? (int16_t) *source : *source;
					target++;
					source += samplesPerPixel;
				}
			}
		}
		else
		{
			for(int i = 0; i < samplesPerPixel; i++)
		    {
				OPJ_INT32 *target = image->comps[i].data;
				const uint16_t *source = (uint16_t *) &framePointer[i * height * width * bytesAllocated];
				for (unsigned int pos = 0; pos < height * width; pos++)
				{
					*target =  (isSigned) ? (int16_t) *source : *source;
					target++;
					source++;
				}
			}
		}
	}
	else if(bytesAllocated == 4)
	{
		if(planarConfiguration == false)
		{
			for(int i = 0; i < samplesPerPixel; i++)
		    {
				OPJ_INT32 *target = image->comps[i].data;
				const uint32_t *source = (uint32_t *) &framePointer[i * bytesAllocated];
				for (unsigned int pos = 0; pos < height * width; pos++)
				{
					*target =  (isSigned) ? (int32_t) *source : *source;
					target++;
					source += samplesPerPixel;
				}
			}
		}
		else
		{
			for(int i = 0; i < samplesPerPixel; i++)
		    {
				OPJ_INT32 *target = image->comps[i].data;
				const uint32_t *source = (uint32_t *) &framePointer[i * height * width * bytesAllocated];
				for (unsigned int pos = 0; pos < height * width; pos++)
				{
					*target =  (isSigned) ? (int32_t) *source : *source;
					target++;
					source++;
				}
			}
		}
	}
	delete [] cmptparm;

	*ret_image = image;
	return true;
}