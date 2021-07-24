using System.Threading.Tasks;

namespace ViewJpeg2000.Services
{

    public interface IFileDownloadService
    {

        Task<byte[]> GetFileContent(string url);

    }

}
