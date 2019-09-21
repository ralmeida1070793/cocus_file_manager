using CocusFileManager.FileEncryptionStrategy.EncryptionStrategies;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CocusFileManager.FileEncryptionStrategy
{
    public class EncryptionContext
    {
        private static EncryptionContext _instance = null;
        private IEncryptionStrategy _strategy;
        private static IConfiguration _settings;

        public static EncryptionContext _getInstance()
        {
            if (_instance == null)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                _settings = builder.Build();

                _instance = new EncryptionContext();
            }

            return _instance;
        }
        private EncryptionContext()
        {
            var strategy = (SupportedStrategies)Enum.Parse(typeof(SupportedStrategies), _settings["fileEncryption:strategy"]);
            switch (strategy)
            {
                case SupportedStrategies.Xor:
                    _strategy = new XorStrategy();
                    _strategy.SetEncryptionKey(Int32.Parse(_settings["fileEncryption:Key"]));

                    break;
                default:
                    throw new Exception("Strategy " + _settings["fileEncryption:strategy"] + "Strategy is Unkown");
            }

        }

        public string Decrypt(string content)
        {
            return _strategy.Decrypt(content);
        }

        public string Encrypt(string content)
        {
            return _strategy.Encrypt(content);
        }
    }
}
