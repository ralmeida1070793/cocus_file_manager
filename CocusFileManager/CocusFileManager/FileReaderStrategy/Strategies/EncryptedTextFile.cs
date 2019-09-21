using CocusFileManager.FileEncryptionStrategy;
using CocusFileManager.FileList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CocusFileManager.FileReaderStrategy.Strategies
{
    public class EncryptedTextFile : IFileReader
    {
        private string _filePath = Directory.GetCurrentDirectory() + "\\FileRepository\\";
        private SupportedFileTypes _type;

        public EncryptedTextFile(SupportedFileTypes type, string fileName)
        {
            switch(type) {
                case SupportedFileTypes.ENCRYPTED_TEXT:
                    _filePath += "EncryptedText\\";
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
            var result = encryptionContext.Decrypt(File.ReadAllText(_filePath));

            using (StreamWriter outputFile = new StreamWriter(Path.Combine("c:\\Files", "camoes_enc.txt")))
            {
                outputFile.Write(result);
            }

            return result;
        }
    }
}
