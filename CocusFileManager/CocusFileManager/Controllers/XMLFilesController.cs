using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocusFileManager.FileList;
using CocusFileManager.FileReaderStrategy;
using CocusFileManager.FileReaderStrategy.Strategies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CocusFileManager.Controllers
{
    [Route("api/xml")]
    [ApiController]
    public class XMLFilesController : ControllerBase, IControllerInterface
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        const SupportedFileTypes FILE_TYPE = SupportedFileTypes.XML;

        public XMLFilesController(
            IHostingEnvironment hostingEnvironment,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        [Route("")]
        [HttpGet]
        public List<string> getAvailableFiles(SupportedFileTypes fileType)
        {
            FileLister fileLister = new FileLister(_hostingEnvironment, _httpContextAccessor);
            return fileLister.getFiles(FILE_TYPE);
        }

        [Route("file")]
        [HttpGet]
        public string getFileContent(string file)
        {
            ReaderContext context = ReaderContext._getInstance();
            context.setContext(new XMLFile(FILE_TYPE, file));

            return context.GetFileContent();
        }

        public List<string> getAvailableEncryptedFiles(SupportedFileTypes fileType)
        {
            throw new NotImplementedException();
        }

        public string getEncryptedFileContent(string file)
        {
            throw new NotImplementedException();
        }
    }
}