using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpBookApp.Authorization;

namespace AbpBookApp
{
    [DependsOn(
        typeof(AbpBookAppCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AbpBookAppApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AbpBookAppAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AbpBookAppApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
