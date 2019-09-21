using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocusFileManager.AuthorizationHanlders.Requirements
{
    public class UserXMLNumberOfFilesRequirement : IAuthorizationRequirement
    {
        public int MaximumNumberOfFiles { get; set; }
        public UserXMLNumberOfFilesRequirement(int maximumNumberOfFiles)
        {
            MaximumNumberOfFiles = maximumNumberOfFiles;
        }
    }
}
