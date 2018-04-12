using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MZC.Controllers
{
    public abstract class MZCControllerBase: AbpController
    {
        protected MZCControllerBase()
        {
            LocalizationSourceName = MZCConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}