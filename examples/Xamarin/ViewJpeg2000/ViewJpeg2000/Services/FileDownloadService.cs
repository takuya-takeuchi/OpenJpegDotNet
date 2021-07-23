using System;
using System.Net;
using System.Threading.Tasks;

namespace ViewJpeg2000.Services
{

    public sealed class FileDownloadService : IFileDownloadService
    {

        #region IFileDownloadService Members

        public async Task<byte[]> GetFileContent(string url)
        {
            var webClient = new WebClient();
            return await webClient.DownloadDataTaskAsync(new Uri(url));
        }

        #endregion

    }

}
