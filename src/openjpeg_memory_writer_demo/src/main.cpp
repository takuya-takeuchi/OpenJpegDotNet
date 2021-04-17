#include "main.hpp"

void main(uint8_t** argv, int argc)
{
	opj_cparameters_t parameters;
	opj_image_t *image = NULL;

	opj_set_default_encoder_parameters(&parameters);

    // set lossless
    parameters.tcp_numlayers = 1;
    parameters.tcp_rates[0] = 0;
    parameters.cp_disto_alloc = 1;

    const char* in_in_filename = "obama-240p.raw";
    const char* out_in_filename = "obama-240p.j2k";
    const bool planarConfiguration = false;
    const uint32_t samplesPerPixel = 3;
    const uint32_t width = 427;
    const uint32_t height = 240;
    const uint32_t bitsAllocated = 8;
    const bool isSigned = false;
    std::ifstream in_file(in_in_filename, std::ios::binary);

    // Stop eating new lines in binary mode!!!
    in_file.unsetf(std::ios::skipws);

    in_file.seekg(0, std::ios::end);
    const size_t in_fileSize = in_file.tellg();
    std::cout << "[Info] in_fileSize: " << in_fileSize << std::endl;
    in_file.seekg(0, std::ios::beg);

    // reserve capacity
    std::vector<uint8_t> vec;
    vec.reserve(in_fileSize);

    // read the data:
    vec.insert(vec.begin(),
               std::istream_iterator<uint8_t>(in_file),
               std::istream_iterator<uint8_t>());
    in_file.close();

	if (!frametoimage(vec.data(),
                      planarConfiguration,
                      OPJ_CLRSPC_SRGB,
                      samplesPerPixel,
                      width,
                      height,
                      bitsAllocated,
                      isSigned,
                      &parameters,
                      &image))
    {
        std::cout << "[Error] frametoimage" << std::endl;
        return;
    }

    size_t size = in_fileSize + 1024;
    uint8_t *buffer = new uint8_t[size];

    // Set up the information structure for OpenJPEG
    opj_stream_t *l_stream = NULL;
    opj_codec_t* l_codec = NULL;
    l_codec = opj_create_compress(OPJ_CODEC_J2K);

    opj_set_info_handler(l_codec, msg_callback, NULL);
    opj_set_warning_handler(l_codec, msg_callback, NULL);
    opj_set_error_handler(l_codec, msg_callback, NULL);

    if (!opj_setup_encoder(l_codec, &parameters, image))
    {
        std::cout << "[Error] opj_setup_encoder" << std::endl;
        opj_destroy_codec(l_codec);
        l_codec = NULL;
        return;
    }

    DecodeData mysrc((unsigned char*)buffer, size);
    l_stream = opj_stream_create_memory_stream(&mysrc, size, OPJ_FALSE);

    if(!opj_start_compress(l_codec,image,l_stream))
    {
        std::cout << "[Error] opj_start_compress" << std::endl;
        return;
    }

    if(!opj_encode(l_codec, l_stream))
    {
        std::cout << "[Error] opj_encode" << std::endl;
        return;
    }

    if(!opj_end_compress(l_codec, l_stream))
    {
        std::cout << "[Error] opj_end_compress" << std::endl;
        return;
    }

    opj_stream_destroy(l_stream); l_stream = NULL;
    opj_destroy_codec(l_codec); l_codec = NULL;
    opj_image_destroy(image); image = NULL;

    std::ofstream out_file(out_in_filename, std::ios::out | std::ios::binary);
    out_file.write((char*)&buffer[0], mysrc.offset);
    out_file.close();
}