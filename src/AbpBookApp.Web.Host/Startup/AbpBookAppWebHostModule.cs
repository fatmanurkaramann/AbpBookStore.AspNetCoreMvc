using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpBookApp.Configuration;

namespace AbpBookApp.Web.Host.Startup
{
    [DependsOn(
       typeof(AbpBookAppWebCoreModule))]
    public class AbpBookAppWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AbpBookAppWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpBookAppWebHostModule).GetAssembly());
        }
    }
}
