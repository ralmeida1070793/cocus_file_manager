﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocusFileManager.FileList;
using CocusFileManager.FileReaderStrategy;
using CocusFileManager.FileReaderStrategy.Strategies;
using CocusFileManager.Users.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CocusFileManager.Controllers
{
    [Route("api/json")]
    [ApiController]
    public class JSONFilesController : ControllerBase, IControllerInterface
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        const SupportedFileTypes FILE_TYPE = SupportedFileTypes.JSON;
        const SupportedFileTypes ENCRYPTED_FILES = SupportedFileTypes.ENCRYPTED_JSON;

        public JSONFilesController(
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
        [Authorize(Roles = "Admin, User")]
        [Authorize(Policy = "MaximumUserJSONFilesAccess")]
        [HttpGet]
        public string getFileContent(string file)
        {
            ReaderContext context = ReaderContext._getInstance();
            context.setContext(new JSONFile(FILE_TYPE, file));

            return context.GetFileContent();
        }

        [Route("encrypted")]
        [HttpGet]
        public List<string> getAvailableEncryptedFiles(SupportedFileTypes fileType)
        {
            FileLister fileLister = new FileLister(_hostingEnvironment, _httpContextAccessor);
            return fileLister.getFiles(ENCRYPTED_FILES);
        }

        [Route("encrypted/file")]
        [HttpGet]
        public string getEncryptedFileContent(string file)
        {
            ReaderContext context = ReaderContext._getInstance();
            context.setContext(new EncryptedJSONFile(ENCRYPTED_FILES, file));

            return context.GetFileContent();
        }
    }
}