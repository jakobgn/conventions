using System;
using Microsoft.AspNetCore.Authorization;

namespace ConventionsAPI.Auth
{
    public class HasRoleRequirement : IAuthorizationRequirement
    {
        public string Role { get; }

        public HasRoleRequirement(string scope)
        {
            Role = scope ?? throw new ArgumentNullException(nameof(scope));
        }
    }
}