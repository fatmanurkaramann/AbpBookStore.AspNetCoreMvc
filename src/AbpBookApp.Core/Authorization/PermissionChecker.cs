using Abp.Authorization;
using AbpBookApp.Authorization.Roles;
using AbpBookApp.Authorization.Users;

namespace AbpBookApp.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
