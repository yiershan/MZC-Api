using System.Threading.Tasks;
using Abp.Application.Services;
using MZC.Authorization.Accounts.Dto;

namespace MZC.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
