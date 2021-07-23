using System.Threading.Tasks;

namespace ViewJpeg2000.Services
{

    public interface IFileAccessService
    {

        Task<byte[]> GetFileContent();

    }

}
