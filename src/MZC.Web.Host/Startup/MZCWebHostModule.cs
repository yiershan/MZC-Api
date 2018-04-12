using System.Reflection;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MZC.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MZC.Web.Host.Startup
{
    [DependsOn(
       typeof(MZCWebCoreModule))]
    public class MZCWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MZCWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MZCWebHostModule).GetAssembly());
        }
    }
}
