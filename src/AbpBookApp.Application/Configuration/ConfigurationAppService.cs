using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AbpBookApp.Configuration.Dto;

namespace AbpBookApp.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AbpBookAppAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
