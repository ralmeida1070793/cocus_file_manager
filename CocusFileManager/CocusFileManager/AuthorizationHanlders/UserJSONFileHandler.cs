using CocusFileManager.AuthorizationHanlders.Requirements;
using CocusFileManager.Users.Helpers;
using CocusFileManager.Users.Model;
using CocusFileManager.Users.Services;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocusFileManager.AuthorizationHanlders
{
    public class UserJSONFileHandler : AuthorizationHandler<UserJSONNumberOfFilesRequirement>
    {
        protected override Task HandleRequirementAsync(
               AuthorizationHandlerContext context,
               UserJSONNumberOfFilesRequirement requirement)
        {
            var _userService = new UserService();

            var user = _userService.GetById(Int32.Parse(context.User.Identity.Name));

            if (user.Role == Role.Admin || user.AccessedJSONFiles <= requirement.MaximumNumberOfJSONFiles)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
