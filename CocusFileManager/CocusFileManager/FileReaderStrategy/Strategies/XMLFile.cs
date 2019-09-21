using CocusFileManager.FileList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CocusFileManager.FileReaderStrategy.Strategies
{
    public class XMLFile : IFileReader
    {
        private string _filePath = Directory.GetCurrentDirectory() + "\\FileRepository\\";
        private SupportedFileTypes _type;

        public XMLFile(SupportedFileTypes type, string fileName)
        {
            switch(type) {
                case SupportedFileTypes.XML:
                    _filePath += "XML\\";
                    break;
                default:
                    throw new Exception("Unsupported File Type");
            }

            _filePath += fileName;
        }

        public string GetFileContent()
        {
            if (String.IsNullOrEmpty(_filePath) || !File.Exists(_filePath))
                throw new FileNotFoundException();

            return File.ReadAllText(_filePath);
        }
    }
}
