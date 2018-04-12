using System.Threading.Tasks;
using MZC.Configuration.Dto;

namespace MZC.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}