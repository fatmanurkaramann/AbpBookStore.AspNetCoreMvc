using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpBookApp.EntityFrameworkCore;
using AbpBookApp.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace AbpBookApp.Web.Tests
{
    [DependsOn(
        typeof(AbpBookAppWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class AbpBookAppWebTestModule : AbpModule
    {
        public AbpBookAppWebTestModule(AbpBookAppEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpBookAppWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(AbpBookAppWebMvcModule).Assembly);
        }
    }
}