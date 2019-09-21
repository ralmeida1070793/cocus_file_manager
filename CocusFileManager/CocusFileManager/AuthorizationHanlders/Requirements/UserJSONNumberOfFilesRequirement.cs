using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocusFileManager.AuthorizationHanlders.Requirements
{
    public class UserJSONNumberOfFilesRequirement : IAuthorizationRequirement
    {
        public int MaximumNumberOfJSONFiles { get; set; }
        public UserJSONNumberOfFilesRequirement(int maximumNumberOfJSONFiles)
        {
            MaximumNumberOfJSONFiles = maximumNumberOfJSONFiles;
        }
    }
}
