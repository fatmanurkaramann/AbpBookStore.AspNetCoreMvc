using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AbpBookApp.Controllers
{
    public abstract class AbpBookAppControllerBase: AbpController
    {
        protected AbpBookAppControllerBase()
        {
            LocalizationSourceName = AbpBookAppConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
