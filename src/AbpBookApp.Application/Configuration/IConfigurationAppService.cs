using System.Threading.Tasks;
using AbpBookApp.Configuration.Dto;

namespace AbpBookApp.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
