using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MZC.Authorization;

namespace MZC
{
    [DependsOn(
        typeof(MZCCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MZCApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MZCAuthorizationProvider>();
        }

        public override void Initialize()
        {
            Assembly thisAssembly = typeof(MZCApplicationModule).GetAssembly();
            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                //Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg.AddProfiles(thisAssembly);
            });
        }
    }
}