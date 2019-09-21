using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocusFileManager.FileReaderStrategy
{
    public class ReaderContext
    {
        private static ReaderContext _instance = null;
        private IFileReader _strategy;

        public static ReaderContext _getInstance()
        {
            if (_instance == null)
            {
                _instance = new ReaderContext();
            }

            return _instance;
        }

        private ReaderContext()
        { }

        public void setContext(IFileReader strategy)
        {
            this._strategy = strategy;
        }
        
        public string GetFileContent()
        {
            return this._strategy.GetFileContent();
        }
    }
}
