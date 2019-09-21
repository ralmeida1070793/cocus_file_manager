using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocusFileManager.FileEncryptionStrategy.EncryptionStrategies
{
    public class XorStrategy : IEncryptionStrategy
    {
        private int Key;

        public string Decrypt(string content)
        {
            StringBuilder szInputStringBuild = new StringBuilder(content);
            StringBuilder szOutStringBuild = new StringBuilder(content.Length);
            char Textch;
            for (int iCount = 0; iCount < content.Length; iCount++)
            {
                Textch = szInputStringBuild[iCount];
                Textch = (char)(Textch ^ this.Key);
                szOutStringBuild.Append(Textch);
            }
            return szOutStringBuild.ToString();
        }

        public string Encrypt(string content)
        {
            StringBuilder szInputStringBuild = new StringBuilder(content);
            StringBuilder szOutStringBuild = new StringBuilder(content.Length);
            char Textch;
            for (int iCount = 0; iCount < content.Length; iCount++)
            {
                Textch = szInputStringBuild[iCount];
                Textch = (char)(Textch ^ this.Key);
                szOutStringBuild.Append(Textch);
            }
            return szOutStringBuild.ToString();
        }

        public void SetEncryptionKey(int key)
        {
            this.Key = key;
        }
    }
}
