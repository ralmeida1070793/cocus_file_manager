using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CocusFileManager.FileList
{
    public class FileLister
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FileLister(
            IHostingEnvironment hostingEnvironment,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<string> getFiles(SupportedFileTypes type)
        {
            var folderPath = Directory.GetCurrentDirectory() + "\\FileRepository\\";

            switch (type)
            {
                case SupportedFileTypes.PLAIN_TEXT:
                    folderPath += "PlainText\\";
                    break;
                case SupportedFileTypes.ENCRYPTED_TEXT:
                    folderPath += "EncryptedText\\";
                    break;
                default:
                    throw new Exception("Unsupported File Type");
            }

            List<string> result = new List<string>();
            foreach(string file in Directory.EnumerateFiles(folderPath)) {
                FileInfo fileInfo = new FileInfo(file);

                if (type == SupportedFileTypes.PLAIN_TEXT && fileInfo.Extension.ToLower() == ".txt")
                {
                    result.Add(fileInfo.Name);
                }
            }

            return result;
        }
    }
}
