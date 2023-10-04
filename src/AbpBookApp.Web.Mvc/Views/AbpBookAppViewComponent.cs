using Abp.AspNetCore.Mvc.ViewComponents;

namespace AbpBookApp.Web.Views
{
    public abstract class AbpBookAppViewComponent : AbpViewComponent
    {
        protected AbpBookAppViewComponent()
        {
            LocalizationSourceName = AbpBookAppConsts.LocalizationSourceName;
        }
    }
}
