using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocusFileManager.AuthorizationHanlders.Requirements
{
    public class UserTXTNumberOfFilesRequirement : IAuthorizationRequirement
    {
        public int MaximumNumberOfTextFiles { get; set; }
        public UserTXTNumberOfFilesRequirement(int maximumNumberOfTextFiles)
        {
            MaximumNumberOfTextFiles = maximumNumberOfTextFiles;
        }
    }
}
