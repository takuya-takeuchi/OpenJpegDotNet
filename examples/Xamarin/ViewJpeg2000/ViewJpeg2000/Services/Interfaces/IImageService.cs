using ViewJpeg2000.Models;

namespace ViewJpeg2000.Services.Interfaces
{

    public interface IImageService
    {

        DetectResult Detect(byte[] file);

    }

}