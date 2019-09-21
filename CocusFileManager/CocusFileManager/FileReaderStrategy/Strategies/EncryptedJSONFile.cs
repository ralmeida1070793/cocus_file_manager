using CocusFileManager.FileEncryptionStrategy;
using CocusFileManager.FileList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CocusFileManager.FileReaderStrategy.Strategies
{
    public class EncryptedJSONFile : IFileReader
    {
        private string _filePath = Directory.GetCurrentDirectory() + "\\FileRepository\\";
        private SupportedFileTypes _type;

        public EncryptedJSONFile(SupportedFileTypes type, string fileName)
        {
            switch(type) {
                case SupportedFileTypes.ENCRYPTED_JSON:
                    _filePath += "EncryptedJSON\\";
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

            var encryptionContext = EncryptionContext._getInstance();
            return encryptionContext.Decrypt(File.ReadAllText(_filePath));
        }
    }
}
