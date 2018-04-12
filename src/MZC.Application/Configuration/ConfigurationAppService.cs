using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MZC.Configuration.Dto;

namespace MZC.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MZCAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
