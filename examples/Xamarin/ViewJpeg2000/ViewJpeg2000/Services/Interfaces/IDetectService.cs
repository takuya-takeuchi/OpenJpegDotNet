using ViewJpeg2000.Models;

namespace ViewJpeg2000.Services.Interfaces
{

    public interface IDetectService
    {

        DetectResult Detect(byte[] file);

    }

}