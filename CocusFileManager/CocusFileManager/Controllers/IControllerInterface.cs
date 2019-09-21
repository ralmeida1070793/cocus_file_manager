using CocusFileManager.FileList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocusFileManager.Controllers
{
    public interface IControllerInterface
    {
        List<string> getAvailableFiles(SupportedFileTypes fileType);
        string getFileContent(string file);
        List<string> getAvailableEncryptedFiles(SupportedFileTypes fileType);
        string getEncryptedFileContent(string file);
    }
}
