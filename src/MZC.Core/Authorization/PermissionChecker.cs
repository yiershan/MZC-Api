using Abp.Authorization;
using MZC.Authorization.Roles;
using MZC.Authorization.Users;

namespace MZC.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
