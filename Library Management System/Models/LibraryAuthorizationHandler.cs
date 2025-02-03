using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class LibraryAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement)
        {
            var user = context.User;
            var isAdmin = user.HasClaim(c => c.Type == "AccessLevel" && c.Value == AccessLevel.Administrator.ToString());

            switch (requirement.Name)
            {
                case UserOperations.CreateMember:
                case UserOperations.UpdateMember:
                case UserOperations.DeleteMember:
                    if (isAdmin)
                        context.Succeed(requirement);
                    break;

                case UserOperations.ViewMember:
                    if (isAdmin || user.HasClaim(c => c.Type == "AccessLevel" && c.Value == AccessLevel.Basic.ToString()))
                        context.Succeed(requirement);
                    break;

                case UserOperations.ManageLibrarians:
                    // Only administrators can manage other librarians
                    if (isAdmin)
                        context.Succeed(requirement);
                    break;
            }

            return Task.CompletedTask;
        }
    }

}
