using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ConventionsAPI.Auth
{
    public class HasRoleHandler : AuthorizationHandler<HasRoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasRoleRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"))
                return Task.CompletedTask;

            var roles = context.User.FindAll(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Select(x => x.Value);

            if (roles != null && roles.Any(s => s == requirement.Role))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
