using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace AbpBookApp.Web.Views
{
    public abstract class AbpBookAppRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected AbpBookAppRazorPage()
        {
            LocalizationSourceName = AbpBookAppConsts.LocalizationSourceName;
        }
    }
}
