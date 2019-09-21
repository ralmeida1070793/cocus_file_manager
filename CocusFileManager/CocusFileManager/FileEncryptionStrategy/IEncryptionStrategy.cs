using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocusFileManager.FileEncryptionStrategy
{
    public interface IEncryptionStrategy
    {
        void SetEncryptionKey(int key);
        string Encrypt(string content);
        string Decrypt(string content);
    }
}
