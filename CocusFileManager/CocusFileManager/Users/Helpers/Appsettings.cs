using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocusFileManager.Users.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int MaximumTextFilesForUser { get; set; }
        public int MaximumXMLFilesForUser { get; set; }
        public int MaximumJSONFilesForUser { get; set; }

    }
}
